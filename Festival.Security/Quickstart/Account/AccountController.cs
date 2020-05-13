// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using Festival.Security.Models;
using IdentityModel;
using IdentityServer4.Events;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.Quickstart.UI
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        //sa usermanagerom registrujemo usere, dodajemo role i slicne stvari
        private readonly UserManager<ApplicationUser> _userManager;
        // sa signin managerom cemo samo loginovat usera
        private readonly SignInManager<ApplicationUser> _signInManager;
        // ovo dole su identity server 4 stvari koje ne kontam najbolje al su postavljene sve kako treba
        // nama za registraciju i role vise ne treba identity server 4 kolko sam mogao istrazit
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clientStore;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly IEventService _events;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IAuthenticationSchemeProvider schemeProvider,
            IEventService events)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _clientStore = clientStore;
            _schemeProvider = schemeProvider;
            _events = events;
        }

        /// <summary>
        /// Entry point into the login workflow
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            // build a model so we know what to show on the login page
            // ovo znas vec kako ide, samo sto su po defaultu oni napravili helper metode za pravljenje VM
            // mi bi obicno ovdje rekli var model = new LoginVM() al je manje vise isto
            var vm = await BuildLoginViewModelAsync(returnUrl);

            return View(vm);
        }

        /// <summary>
        /// Handle postback from username/password login
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInputModel model, string button)
        {
            // check if we are in the context of an authorization request
            // unutar ovog projekta u Config.cs postavljen je RedirectUri 
            // GetAuthorizedContext provjerava da li je returnUri s kojeg je dosao request unutar jedan od onih unutar Configa.cs
            // Ovo sprecava druge ljude da rucno odu na nas localhost:5000/Account/Login i da dobiju pristup

            var context = await _interaction.GetAuthorizationContextAsync(model.ReturnUrl);

            // the user clicked the "cancel" button
            // ovaj citav IF je jeben za skontat, al nece se nama ovo desavat
            // i da se desi postavljeno je ovo sve defaultno od Identity Servera da ih vraca odakle su dosli
            if (button != "login")
            {
                if (context != null)
                {
                    // if the user cancels, send a result back into IdentityServer as if they 
                    // denied the consent (even if this client does not require consent).
                    // this will send back an access denied OIDC error response to the client.
                    await _interaction.GrantConsentAsync(context, ConsentResponse.Denied);

                    // we can trust model.ReturnUrl since GetAuthorizationContextAsync returned non-null
                    if (await _clientStore.IsPkceClientAsync(context.ClientId))
                    {
                        // if the client is PKCE then we assume it's native, so this change in how to
                        // return the response is for better UX for the end user.
                        return this.LoadingPage("Redirect", model.ReturnUrl);
                    }

                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    // since we don't have a valid context, then we just go back to the home page
                    return Redirect("~/");
                }
            }


            // Ova if petlja ako je izvor uredu i ako nema gresaka validacijskih unutar ViewModela
            if (ModelState.IsValid)
            {

                // Ova funkcija je bukvalno za login od strane Microsoft Identitya
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberLogin, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    // Microsoft Identity funkcija koja vraca ApplicationUser objekat lika koji se ulogovao
                    var user = await _userManager.FindByNameAsync(model.Username);

                    //Ovo je od Identity Servera 4 da ga obavjestimo da je User uspjesno logovan i da mu da Token ili Cookies ili sta vec
                    await _events.RaiseAsync(new UserLoginSuccessEvent(user.UserName, user.Id, user.UserName, clientId: context?.ClientId));

                    //Ista provjera ko gora na prvom velikom ifu
                    // Provjeravamo da li je request pravi, validan 
                    if (context != null)
                    {
                        // Kod nas nece bit PKCE klijenata ovdje nece nikad uci
                        if (await _clientStore.IsPkceClientAsync(context.ClientId))
                        {
                            // if the client is PKCE then we assume it's native, so this change in how to
                            // return the response is for better UX for the end user.
                            return this.LoadingPage("Redirect", model.ReturnUrl);
                        }

                        // we can trust model.ReturnUrl since GetAuthorizationContextAsync returned non-null
                        // Uspjesno smo loginovali korisnika, dali mu Access Token i mozemo ga redirectat na Festival
                        return Redirect(model.ReturnUrl);
                    }

                    // request for a local page
                    // ovo je ako je los autorizaciji request tj. ako je context == null 
                    // vracamo ga odakle je dosao
                    if (Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    // Ako user nema return url vracamo ga na pocetnu stranicu nasu
                    // u ovom slucaju pocetnu od identity servera
                    else if (string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return Redirect("~/");
                    }
                    // ako skripta, bot ili slicno pokusaju nam loginovat throwa exception
                    else
                    {
                        // user might have clicked on a malicious link - should be logged
                        throw new Exception("invalid return URL");
                    }
                }
                // Ako malo bolje se zagledas ovo je bukvalno Else od onog gore Result.Succeded tj ako je pogresne kredencijale ukucao
                await _events.RaiseAsync(new UserLoginFailureEvent(model.Username, "invalid credentials", clientId: context?.ClientId));
                ModelState.AddModelError(string.Empty, AccountOptions.InvalidCredentialsErrorMessage);
            }

            // something went wrong, show form with error
            // Vracamo ga na nas Login View gdje mu izbacujemo Invalid username or passowrd
            // Pokusaj jednom pogresno ukucat i vidjeces da ce ti ovaj dio bacit
            var vm = await BuildLoginViewModelAsync(model);
            return View(vm);
        }


        /// <summary>
        /// Show logout page
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            // build a model so the logout page knows what to display
            // bukvalno prave viewmodel za onu glupost are you sure you want to logout
            // ako pogledas ja sam zakucao ShowLogoutPromt da je false tako da odma baca na logout
            var vm = await BuildLogoutViewModelAsync(logoutId);

            if (vm.ShowLogoutPrompt == false)
            {
                // if the request for logout was properly authenticated from IdentityServer, then
                // we don't need to show the prompt and can just log the user out directly.
                return await Logout(vm);
            }

            return View(vm);
        }

        /// <summary>
        /// Handle logout page postback
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(LogoutInputModel model)
        {
            // build a model so the logged out page knows what to display
            // Ovdje je ViewModel za You have been successfully logged out
            // Ja mislim da sam ja ovdje odma puko da vrate na pocetnu nasu, bukvalno se na 1 sekundu vidi taj view
            var vm = await BuildLoggedOutViewModelAsync(model.LogoutId);

            //User.Identity.IsAuthenticated nema veze ni sa Identityem, ni IS4 
            //ova funkcija iz System namespace i kaze da li je korisnik autentifikovan

            if (User?.Identity.IsAuthenticated == true)
            {
                // delete local authentication cookie
                // brise microsoft identity cookie
                await _signInManager.SignOutAsync();

                // raise the logout event
                // brise identity server 4 token
                await _events.RaiseAsync(new UserLogoutSuccessEvent(User.GetSubjectId(), User.GetDisplayName()));
            }

            // check if we need to trigger sign-out at an upstream identity provider
            // ovo je lupam ako smo implementirali Google ili Facebook login pa on ga baci na njihove API da se odjave
            // moze se ovo izbrisat skroz ili zakomentarisat
            if (vm.TriggerExternalSignout)
            {
                // build a return URL so the upstream provider will redirect back
                // to us after the user has logged out. this allows us to then
                // complete our single sign-out processing.
                string url = Url.Action("Logout", new { logoutId = vm.LogoutId });

                // this triggers a redirect to the external provider for sign-out
                return SignOut(new AuthenticationProperties { RedirectUri = url }, vm.ExternalAuthenticationScheme);
            }
            // Dzaba sto on baca na View Logged Out ako pogledas klasu AccountOptions odma ispod ovog kontrolera
            // Vidjeces da sam stavio da automatski redirekta nakon log outa
            return View("LoggedOut", vm);
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            //ovdje korsnici prvo dolaze popunjavaju formu tvoju i kliknom na Submit/RegistrujSe salje ih na funkciju ispod
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterInputVM model)
        {
            // provjeravamo da li su validni input podaci
            if (ModelState.IsValid)
            {
                //pravimo objekat naše klase koju možeš u Models naći unutar Security projekta
                //nasa klasa nema svojih propertya vec ih nasljedjuje od Identity klase koja ima npr Username, Email, PhoneNumber i sl
                var newUser = new ApplicationUser()
                {
                    Email = model.Email,
                    UserName = model.Username
                };

                //ovdje pravimo putem Identitya novog korisnika i ovdje drugi parametar je password
                //jer ova funkcija CreateAsync ce primit password, hashovat ga i spremit u bazu sa ostalim podacima
                var result = await _userManager.CreateAsync(newUser, model.Password);

                //ako je uspjesno spremljeno ovdje im kao dodjeljumemo rolu Guest
                //slozili smo se da nece se administratori moci registrovat tako da ce ovo uvijek ovako bit
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, "Guest");
                }

                // Ako je sve uspjelo treba vratit na View neki Uspjesna registracija ili redirectat na Homepage ?? veze nemam
                return Redirect("https://127.0.0.1:44330/");
            }
            // vracamo na registracioni View opet ako nesto nije bilo dobro I guess ? i ispisujemo greske
            return View("Register", model);

        }


        //Ovo su dole pomocne funkcije mozemo i mi napraviti helper za pravljanje ViewModela nasih
        //Ali ove imaju dosta Identity Server 4 gluposti, sto nama ne treba za Registraciju


        /*****************************************/
        /* helper APIs for the AccountController */
        /*****************************************/
        private async Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl)
        {
            var context = await _interaction.GetAuthorizationContextAsync(returnUrl);
            if (context?.IdP != null && await _schemeProvider.GetSchemeAsync(context.IdP) != null)
            {
                var local = context.IdP == IdentityServer4.IdentityServerConstants.LocalIdentityProvider;

                // this is meant to short circuit the UI and only trigger the one external IdP
                var vm = new LoginViewModel
                {
                    EnableLocalLogin = local,
                    ReturnUrl = returnUrl,
                    Username = context?.LoginHint,
                };

                if (!local)
                {
                    vm.ExternalProviders = new[] { new ExternalProvider { AuthenticationScheme = context.IdP } };
                }

                return vm;
            }

            var schemes = await _schemeProvider.GetAllSchemesAsync();

            var providers = schemes
                .Where(x => x.DisplayName != null ||
                            (x.Name.Equals(AccountOptions.WindowsAuthenticationSchemeName, StringComparison.OrdinalIgnoreCase))
                )
                .Select(x => new ExternalProvider
                {
                    DisplayName = x.DisplayName ?? x.Name,
                    AuthenticationScheme = x.Name
                }).ToList();

            var allowLocal = true;
            if (context?.ClientId != null)
            {
                var client = await _clientStore.FindEnabledClientByIdAsync(context.ClientId);
                if (client != null)
                {
                    allowLocal = client.EnableLocalLogin;

                    if (client.IdentityProviderRestrictions != null && client.IdentityProviderRestrictions.Any())
                    {
                        providers = providers.Where(provider => client.IdentityProviderRestrictions.Contains(provider.AuthenticationScheme)).ToList();
                    }
                }
            }

            return new LoginViewModel
            {
                AllowRememberLogin = AccountOptions.AllowRememberLogin,
                EnableLocalLogin = allowLocal && AccountOptions.AllowLocalLogin,
                ReturnUrl = returnUrl,
                Username = context?.LoginHint,
                ExternalProviders = providers.ToArray()
            };
        }

        private async Task<LoginViewModel> BuildLoginViewModelAsync(LoginInputModel model)
        {
            var vm = await BuildLoginViewModelAsync(model.ReturnUrl);
            vm.Username = model.Username;
            vm.RememberLogin = model.RememberLogin;
            return vm;
        }

        private async Task<LogoutViewModel> BuildLogoutViewModelAsync(string logoutId)
        {
            var vm = new LogoutViewModel { LogoutId = logoutId, ShowLogoutPrompt = AccountOptions.ShowLogoutPrompt };

            if (User?.Identity.IsAuthenticated != true)
            {
                // if the user is not authenticated, then just show logged out page
                vm.ShowLogoutPrompt = false;
                return vm;
            }

            var context = await _interaction.GetLogoutContextAsync(logoutId);
            if (context?.ShowSignoutPrompt == false)
            {
                // it's safe to automatically sign-out
                vm.ShowLogoutPrompt = false;
                return vm;
            }

            // show the logout prompt. this prevents attacks where the user
            // is automatically signed out by another malicious web page.
            return vm;
        }

        private async Task<LoggedOutViewModel> BuildLoggedOutViewModelAsync(string logoutId)
        {
            // get context information (client name, post logout redirect URI and iframe for federated signout)
            var logout = await _interaction.GetLogoutContextAsync(logoutId);

            var vm = new LoggedOutViewModel
            {
                AutomaticRedirectAfterSignOut = AccountOptions.AutomaticRedirectAfterSignOut,
                PostLogoutRedirectUri = logout?.PostLogoutRedirectUri,
                ClientName = string.IsNullOrEmpty(logout?.ClientName) ? logout?.ClientId : logout?.ClientName,
                SignOutIframeUrl = logout?.SignOutIFrameUrl,
                LogoutId = logoutId
            };

            if (User?.Identity.IsAuthenticated == true)
            {
                var idp = User.FindFirst(JwtClaimTypes.IdentityProvider)?.Value;
                if (idp != null && idp != IdentityServer4.IdentityServerConstants.LocalIdentityProvider)
                {
                    var providerSupportsSignout = await HttpContext.GetSchemeSupportsSignOutAsync(idp);
                    if (providerSupportsSignout)
                    {
                        if (vm.LogoutId == null)
                        {
                            // if there's no current logout context, we need to create one
                            // this captures necessary info from the current logged in user
                            // before we signout and redirect away to the external IdP for signout
                            vm.LogoutId = await _interaction.CreateLogoutContextAsync();
                        }

                        vm.ExternalAuthenticationScheme = idp;
                    }
                }
            }

            return vm;
        }
    }
}
