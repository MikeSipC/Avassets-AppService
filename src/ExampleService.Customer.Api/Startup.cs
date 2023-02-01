using System;
using System.Linq;
using Autofac;
using AutoMapper;
using ExampleService.Customer.Api.Helpers;
using ExampleService.Core;
using ExampleService.Infrastructure;
using MediatR;
using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using NSwag;
using NSwag.Generation.AspNetCore;

namespace ExampleService.Customer.Api
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
            services.AddCors();

            services.AddLogging();

            services.AddApplicationInsightsTelemetry();
            services.ConfigureTelemetryModule<DependencyTrackingTelemetryModule>((module, o) => { module.EnableSqlCommandTextInstrumentation = true; });

            if (bool.Parse(Configuration.GetSection("ApplicationInsightsConfig:TrackDependencyResponse").Value))
            {
                services.AddSingleton<ITelemetryInitializer, TrackDependencyResponse>();
            }

            services.AddAuthentication();

            services.AddMediatR(typeof(CoreModule).Assembly);
            services.AddMediatR(typeof(InfrastructureModule).Assembly);

            services.AddControllers()
                .AddNewtonsoftJson();
            services.AddApiVersioning(config =>
            {
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "VVVV";
                options.SubstitutionFormat = "VVVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddSingleton(provider => MapperConfigurationFactory(provider).CreateMapper());

            services.AddSingleton(Configuration.GetSection("ExampleConfig").Get<ExampleAppSettingsConfiguration>());

            services.AddHttpContextAccessor();

            services.AddOpenApiDocument(configure => { BaseConfigure(configure, "1.0"); });
        }

        private MapperConfiguration MapperConfigurationFactory(IServiceProvider provider)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AddMaps(typeof(Startup).Assembly);
                cfg.ConstructServicesUsing(type => ActivatorUtilities.CreateInstance(provider, type));
            });
            //config.AssertConfigurationIsValid();
            return config;
        }

        private void BaseConfigure(AspNetCoreOpenApiDocumentGeneratorSettings configure, string version)
        { 

            configure.DocumentName = version;
            configure.ApiGroupNames = new[] {version};

            configure.AddSecurity("JWT", Enumerable.Empty<string>(),
                new OpenApiSecurityScheme {Type = OpenApiSecuritySchemeType.ApiKey, Name = "Authorization", In = OpenApiSecurityApiKeyLocation.Header, Description = "Copy this into the value field: Bearer {token}"});
            configure.AddSecurity("Credentials", Enumerable.Empty<string>(),
                new OpenApiSecurityScheme {Type = OpenApiSecuritySchemeType.Basic, Name = "Authorization", In = OpenApiSecurityApiKeyLocation.Header, Description = "Default"});

            configure.PostProcess = document =>
            {
                document.Info.Version = version;
                document.Info.Title = "Example Avassets API";
                document.Info.Description = "A ASP.NET Core web API";
                document.Info.TermsOfService = "None";
                document.Info.Contact = new OpenApiContact
                {
                    Name = "Avanade Avassets",
                    Email = "ex@example.ex"
                };
            };
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(
                new CoreModule(
                    new[]
                    {
                        typeof(Startup).Assembly,
                        typeof(CoreModule).Assembly,
                        typeof(InfrastructureModule).Assembly
                    }
                ));
            builder.RegisterModule(new InfrastructureModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl =
                    new CacheControlHeaderValue
                    {
                        NoStore = true
                    };
                await next();
            });

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}