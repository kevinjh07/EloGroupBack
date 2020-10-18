using System;
using System.Text;
using AutoMapper;
using EloGroupBack.Configuration;
using EloGroupBack.Context;
using EloGroupBack.Helpers;
using EloGroupBack.Models;
using EloGroupBack.Models.Dto;
using EloGroupBack.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EloGroupBack
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
            var appSettingsSection = Configuration.GetSection("AppSettings");

            services.Configure<AppSettings>(appSettingsSection);

            services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder =>
                {
                    var allowedHosts = appSettingsSection.Get<AppSettings>().CorsOrigins.Split(";");
                    builder.WithOrigins(allowedHosts)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                }));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "EloGroup API", Version = "v1"});
            });

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("EloGroupContext")));

            services.AddIdentity<ApplicationUser, IdentityRole<int>>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(3);
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.User.AllowedUserNameCharacters = null;

                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
            });

            #region Mapper

            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new AutoMapperProfile()));

            services.AddSingleton(mappingConfig.CreateMapper());

            #endregion

            #region Jwt

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                var key = Encoding.ASCII.GetBytes(appSettingsSection.Get<AppSettings>().Secret);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            #endregion

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILeadService, LeadService>();
            services.AddScoped<IStatusLeadService, StatusLeadService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EloGroup API"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseCors("CorsPolicy");

            app.UseMvc(routes => routes.MapRoute(
                "default",
                "{controller}/{action=Index}/{id?}"));

            if (serviceProvider.GetRequiredService<ApplicationContext>().Database.ProviderName !=
                "Microsoft.EntityFrameworkCore.InMemory")
            {
                serviceProvider.GetRequiredService<ApplicationContext>().Database.Migrate();
            }

            CreateStatusLead(serviceProvider);
        }

        private void CreateStatusLead(IServiceProvider serviceProvider)
        {
            string[] statuses = {"Cliente em Potencial", "Dados Confirmados", "Reunião Agendada"};

            foreach (var status in statuses)
            {
                var statusLeadService = serviceProvider.GetRequiredService<IStatusLeadService>();
                if (statusLeadService.StatusLeadExists(status)) continue;
                var statusLead = new StatusLeadDto(status);
                statusLeadService.SaveStatusLead(statusLead);
            }
        }
    }
}