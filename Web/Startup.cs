using System;
using System.Reflection;
using AutoMapper;
using Core;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.Swagger.Model;
using Swashbuckle.SwaggerGen.Generator;
using Web.Classes;
using Web.DummyData;
using Web.MappingProfiles;

namespace Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            if (env.IsEnvironment("Development"))
                builder.AddApplicationInsightsSettings(true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            services.AddAutoMapper();

            // Inject an implementation of ISwaggerProvider with defaulted settings applied
            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            });

            var mapperConfig = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
            services.AddSingleton(sp => mapperConfig.CreateMapper());

            // Add Identity Services & Stores
            services.AddIdentity<AppUser, IdentityRole>(config => {
                config.User.RequireUniqueEmail = true;
                config.Password.RequireNonAlphanumeric = false;
                config.Cookies.ApplicationCookie.AutomaticChallenge = false;
            })
                .AddEntityFrameworkStores<BaseContext>()
                .AddDefaultTokenProviders();

            // Add ApplicationDbContext.
            services.AddDbContext<BaseContext>(options =>
                options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"])
                );

            // Add DbSeeder
            services.AddSingleton<DbSeeder>();

            services.AddDbContext<BaseContext>(
                options => options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

            services.AddTransient<IStudentRepository<Student>, StudentRepository>();
            services.AddTransient<ICourseRepository<Course>, CourseRepository>();
            services.AddTransient<ITeacherRepository<Teacher>, TeacherRepository>();
            services.AddTransient<IGroupRepository<Group>, GroupRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, DbSeeder dbSeeder)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            //app.UseMvc();

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUi();

            // Add a custom Jwt Provider to generate Tokens
            app.UseJwtProvider();

            // Add the Jwt Bearer Header Authentication to validate Tokens
            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                RequireHttpsMetadata = false,
                
                TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = JwtProvider.SecurityKey,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = JwtProvider.Issuer,
                    ValidateIssuer = false,
                    ValidateAudience = false
                }
            });


            // Seed the Database (if needed)
            try
            {
                dbSeeder.SeedAsync().Wait();
            }
            catch (AggregateException e)
            {
                throw new Exception(e.ToString());
            }

            app.UseMvc();
        }
    }
}