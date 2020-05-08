using Festival.Data.Models;
using Festival.Data.Repositories;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

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

           });
            services.AddControllersWithViews();
            services.AddDbContext<FestivalContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("FestivalDatabase")));

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
            IdentityModelEventSource.ShowPII = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
    }
}
