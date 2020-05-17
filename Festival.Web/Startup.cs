using Festival.Data.Models;
using Festival.Data.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace FestivalWebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();

            ConfigureDatabase(services);

            ConfigureSecurity(services);

            ConfigureRepositories(services);

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");


                endpoints.MapAreaControllerRoute(
                    name: "Guest",
                    areaName: "Guest",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IAccommodationRepository, AccommodationRepository>();
            services.AddScoped<IShopItemRepository, ShopItemRepository>();
            services.AddScoped<ITransferVehicleRepository, TransferVehicleRepository>();
            services.AddScoped<ITransferServiceRepository, TransferServiceRepository>();
            services.AddScoped<IStageRepository, StageRepository>();
            services.AddScoped<IPerformerRepository, PerformerRepository>();
            services.AddScoped<ISponzorRepository, SponsorRepository>();
            services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
            services.AddScoped<IPerformanceRepository, PerformanceRepository>();
            services.AddScoped<IAttendeeRepository, AttendeeRepository>();
            services.AddScoped<ITicketVoucherRepository, TicketVoucherRepository>();
            services.AddScoped<IPurchaseVoucherRepository, PurchaseVoucherRepository>();
            services.AddScoped<ITransferReservationRepository, TransferReservationRepository>();
        }

        private void ConfigureSecurity(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                options.SignInScheme = "Cookies";
                options.Authority = "http://localhost:5000";
                options.RequireHttpsMetadata = false;
                options.ClientId = "mvc";
                options.ClientSecret = "secret";
                options.ResponseType = "code";
                options.SaveTokens = true;
                options.MetadataAddress = "http://localhost:5000/.well-known/openid-configuration";
                options.GetClaimsFromUserInfoEndpoint = true;
                options.ClaimActions.MapUniqueJsonKey("roles", "roles");

            });

            services.AddAuthorization(option =>
            {
                option.AddPolicy("Admin", policy => policy.RequireClaim("roles", "Admin"));
                option.AddPolicy("Attendee", policy => policy.RequireClaim("roles", "Attendee"));

            });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            IdentityModelEventSource.ShowPII = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<FestivalContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("FestivalDatabase")));
        }
    }
}
