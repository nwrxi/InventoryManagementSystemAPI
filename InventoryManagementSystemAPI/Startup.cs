using System;
using System.Text;
using InventoryManagementSystemAPI.Data;
using InventoryManagementSystemAPI.Data.Models;
using InventoryManagementSystemAPI.Data.Models.Seed;
using InventoryManagementSystemAPI.Data.Repositories;
using InventoryManagementSystemAPI.Data.Repositories.AccountManagement;
using InventoryManagementSystemAPI.Data.SecurityInterfaces;
using InventoryManagementSystemAPI.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace InventoryManagementSystemAPI
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

            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().WithExposedHeaders("WWW-Authenticate").AllowAnyMethod().WithOrigins("http://localhost:3000");
                    policy.AllowAnyHeader().WithExposedHeaders("WWW-Authenticate").AllowAnyMethod().WithOrigins("http://10.0.2.2:3000");
                });
            });
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("IsItemCreatorOrAdmin", policy =>
                {
                    policy.Requirements.Add(new IsCreatorOrAdmin());
                });
                opt.AddPolicy("IsAdmin", policy =>
                {
                    policy.Requirements.Add(new IsAdmin());
                });
            });
            services.AddTransient<IAuthorizationHandler, IsCreatorOrAdminHandler>();
            services.AddTransient<IAuthorizationHandler, IsAdminHandler>();

            services.AddControllers(opt =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                opt.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddAutoMapper(typeof(Startup));

            var builder = services.AddIdentityCore<User>();
            var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
            identityBuilder.AddRoles<IdentityRole>();
            identityBuilder.AddEntityFrameworkStores<DataContext>();
            identityBuilder.AddSignInManager<SignInManager<User>>();

         

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenSecretKey"]));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    //TODO: change for production
                    //We don't validate urls we are receiving or issuing tokens from
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IItemsRepository, SqlItemRepository>();
            services.AddScoped<IAccountRepository, JwtAccountRepository>();
            services.AddScoped<IUserAccessor, UserAccessor>();

            services.AddTransient<SeedRoles>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SeedRoles seed)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            seed.SeedAdminUser();
        }
    }
}
