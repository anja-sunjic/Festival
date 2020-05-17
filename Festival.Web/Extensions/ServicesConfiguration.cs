using Festival.Data.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using Festival.Web.Helper;

namespace Festival.Web.Extensions
{
    public static class ServicesConfiguration
    {
        public static void AddRepositories(this IServiceCollection services)
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
            services.AddScoped<ILoggingRepository, LoggingRepository>();
            services.AddScoped<DblExceptionFilter>();
        }

        public static void AddSecurity(this IServiceCollection services)
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

    }
}
