using GGAdvantage.Application.Interfaces;
using GGAdvantage.Common;
using GGAdvantage.Infrastructure;
using GGAdvantage.Persistence;
using GGAdvantage.Persistence.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace GGAdvantage.Web.Api
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
            services.AddControllers();
            // Add framework services.
            services.AddTransient<IDateTime, MachineDateTime>();

            // Add Identity
            services.AddIdentity<AppUser, IdentityRole<int>>(config => {
                config.Password.RequiredLength = 3;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.User.RequireUniqueEmail = false;
            }).AddEntityFrameworkStores<GGAdventageDbContext>();

            services.AddAuthentication()
                .AddCookie()
                .AddJwtBearer(config => {
                    config.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = Configuration["JwtSettings:Issuer"],
                        ValidAudience = Configuration["JwtSettings:Audience"],
                        //ValidateIssuer = false,
                        //ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSettings:Secret"]))
                    };
                
                });


            // Add DbContext using SQL Server Provider
            services.AddDbContext<GGAdventageDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    optionsBuilder => optionsBuilder.MigrationsAssembly("GGAdvantage.Migrations")
                )
            );

            // Add Repositories using SQL Server Provider
            services.AddTransient<IAuctionCurrentRealmAssocRepository, AuctionCurrentRealmAssocRepository>();
            services.AddTransient<IAuctionCurrentRepository, AuctionCurrentRepository>();
            services.AddTransient<IAuctionDailyStatisticRealmAssocRepository, AuctionDailyStatisticRealmAssocRepository>();
            services.AddTransient<IAuctionDailyStatisticRepository, AuctionDailyStatisticRepository>();
            services.AddTransient<IAuctionTimeLeftRepository, AuctionTimeLeftRepository>();
            services.AddTransient<IItemClassRepository, ItemClassRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IItemSubclassRepository, ItemSubclassRepository>();
            services.AddTransient<IRealmRepository, RealmRepository>();
            services.AddTransient<IRegionRepository, RegionRepository>();
            services.AddTransient<IMarketNotificationRepository, MarketNotificationRepository>();
            services.AddTransient<IMarketNotificationTypeRepository, MarketNotificationTypeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddCors(options => options.AddPolicy("Cors", builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            //services.AddIdentityCore<User>(options => { });

            //services.AddTransient<IUserStore<User>, UserRepository>();

            //services.AddAuthentication().AddCookie("gg-cookies", options => options.AccessDeniedPath = "/");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("Cors");
            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute("default",
                    "{culture=api}/{controller=Region}/{action=Index}/{id?}"
                );
            });
        }
    }
}
