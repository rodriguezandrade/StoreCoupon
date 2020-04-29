using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Core.Services;
using Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Data;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Repository.Repositories.Utils;
using AutoMapper;
using Core.Profiles;
using Core.Logger.Interface;
using Core.Logger;
using Repository.Models;
using System.Text;
using StoreCouponWeb.Utils.API_Documentation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace StoreCouponWeb.Extensions
{
    public static class MiddlewareServiceExtension
    {
        /// <summary>
        /// configure cors
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        /// <summary>
        /// IIS Integration
        /// </summary>
        /// <param name="services"></param>
        //public static void ConfigureIISIntegration(this IServiceCollection services)
        //{
        //    services.Configure<IISOptions>(options =>
        //    {

        //    });
        //}

        public static void VersioningConfiguration(this IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });
        }

        /// <summary>
        /// Swagger configuration
        /// </summary>
        /// <param name="services"></param>
        public static void SwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc(
                    "v1", new OpenApiInfo
                    {
                        Title = "Admin +Cupon API",
                        Version = "v1",
                        Description = "Web administrator app",
                        TermsOfService = new Uri("https://jearsoft.com"),
                        Contact = new OpenApiContact
                        {
                            Name = "®Jearsoft",
                            Email = "info@jearsoft.com",
                            Url = new Uri("https://jearsoft.com"),
                        },
                        License = new OpenApiLicense
                        {
                            Name = "+Cupon API LICX",
                            Url = new Uri("https://jearsoft.com"),
                        }
                    });

                setup.SwaggerDoc(
                    "v2", new OpenApiInfo
                    {
                        Title = "Mobile +Cupon API",
                        Version = "v2",
                        Description = "Mobile app",
                        TermsOfService = new Uri("https://jearsoft.com"),
                        Contact = new OpenApiContact
                        {
                            Name = "®Jearsoft",
                            Email = "info@jearsoft.com",
                            Url = new Uri("https://jearsoft.com"),
                        },
                        License = new OpenApiLicense
                        {
                            Name = "+Cupon API LICX",
                            Url = new Uri("https://jearsoft.com"),
                        }
                    });

                // This call remove version from parameter, without it we will have version as parameter 
                // for all endpoints in swagger UI
                setup.OperationFilter<RemoveVersionFromParameter>();

                // This make replacement of v{version:apiVersion} to real version of corresponding swagger doc.
                setup.DocumentFilter<ReplaceVersionWithExactValueInPath>();

                // Filter the methods per version and configure what request apply.
                setup.DocInclusionPredicate((version, desc) =>
                {
                    if (!desc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;
                    var versions = methodInfo.DeclaringType
                        .GetCustomAttributes(true)
                        .OfType<ApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions);

                    var maps = methodInfo
                        .GetCustomAttributes(true)
                        .OfType<MapToApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions)
                        .ToArray();

                    return versions.Any(v => $"v{v.ToString()}" == version)
                           && (!maps.Any() || maps.Any(v => $"v{v.ToString()}" == version));
                });

                // Configure Swagger to use the xml documentation file
                var xmlFile = Path.ChangeExtension(typeof(Startup).Assembly.Location, ".xml");
                setup.IncludeXmlComments(xmlFile);
            });
        }

        /// Mapper Configuration
        public static void AutoMapperConfiguration(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Profiles());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        ///Logger
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        ///Database configuration
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["SqlConnection:ConnectionString"];
            services.AddDbContext<RepositoryContext>(o => o
                .UseSqlServer(connectionString));
        }

        ///Inject all the interfaces with classes
        public static void ConfigureClassesWithInterfaces(this IServiceCollection services)
        {
            ///Wrappers
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            ///Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<ISubCategoryService, SubCategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IGeneralCategoryService, GeneralCategoryService>();
            services.AddScoped<ICouponService, CouponService>();
            services.AddScoped<IStoreCategoryService, StoreCategoryService>();
            services.AddScoped<IProductDetailService, ProductDetailService>();
            services.AddScoped<IUserDetailService, UserDetailService>();

            ///Repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IGeneralCategoryRepository, GeneralCategoryRepository>();
            services.AddScoped<ICouponRepository, CouponRepository>();
            services.AddScoped<IStoreCategoryRepository, StoreCategoryRepository>();
            services.AddScoped<IProductDetailRepository, ProductDetailRepository>();
            services.AddScoped<IUserDetailRepository, UserDetailRepository>();
        }

        ///Configure jwt authentication
        public static void ConfigureJWToken(this IServiceCollection services, IConfiguration config)
        {
            var appSettingsSection = config.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}