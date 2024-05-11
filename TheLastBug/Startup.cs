using TheLastBug.Business.Services;
using TheLastBug.Business.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using IdentityServer4.Validation;
using FluentValidation.Results;
using TheLastBug.IdentityServer;
using TheLastBug.Domain.Contexts.AutoGenerated;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Http.Features;
using TheLastBug.Business.DTOs;
using AutoMapper;
using TheLastBug.Business.Mappers;
using TheLastBug.Business.Middleware;

namespace TheLastBug
{
    public class Startup
    {
        readonly string AllowSpecificOrigins = "corsPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            InjectServices(services);

            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile(new MappingProfile());
            });
            
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvc();

            services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<TheLastBugContext>(options => options.UseSqlServer(Configuration.GetConnectionString("default"), sqlServerOptions => sqlServerOptions.CommandTimeout(120)), ServiceLifetime.Transient);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Invoice API", Version = "v1" });
            });

            var origins = Configuration.GetSection("AllowedOrigins").Get<string[]>();
            services.AddCors(options =>
            {
                options.AddPolicy(AllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins(origins)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });

            services.AddHttpClient();
            var authority = Configuration.GetValue<string>("Authority");
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer("Bearer", options =>
               {
                   options.Authority = authority;
                   options.RequireHttpsMetadata = false;
                   options.Audience = "thelastbugAPI";
               });

            services.AddSignalR();

            var builderIS = services.AddIdentityServer(options =>
            {
                options.IssuerUri = authority;
            });

            builderIS.AddDeveloperSigningCredential(true);

            builderIS.AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
                .AddInMemoryApiResources(IdentityServerConfig.GetApis())
                .AddInMemoryClients(IdentityServerConfig.GetClients())
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>();

            services.AddMvc();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
                options.AddPolicy("UserPolicy", policy => policy.RequireRole("User"));
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Invoice API V1");
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(AllowSpecificOrigins);

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseIdentityServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors(AllowSpecificOrigins);
            });

        }
        private void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IUsuarioService, UsuariosService>();
            services.AddTransient<IPaisService, PaisService>();
            services.AddTransient<IRegionService, RegionService>();
            services.AddTransient<IComunaService, ComunaService>();
            services.AddTransient<IAyudaSocialService, AyudaSocialService>();
            services.AddTransient<ILogService, LogService>();
        }
    }
}
