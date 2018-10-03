using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AES.Data;
using AES.Data.DataSources;
using AES.Data.Repositories;
using AES.Domains.WalmartApi;
using AES.Service.Products;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace WalmartWebapi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var tokenValidationParameters = new TokenValidationParameters
            {
                //ValidateIssuerSigningKey = false,
                //ValidateIssuer = true,
                //ValidIssuer = "https://cognito-idp.us-east-1.amazonaws.com/us-east-1_Me0SZg8qw/",
                //IssuerSigningKey = new X509SecurityKey(new X509Certificate2(certLocation)),
                ValidateAudience = false,
                
                
                
            };

            services.AddAuthentication(options =>
                    {
                        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                    .AddJwtBearer(options =>
                    {
                        options.Authority = "https://cognito-idp.us-east-1.amazonaws.com/us-east-1_Me0SZg8qw";
                        //options.Audience = "http://walmartwebapi-dev.us-east-1.elasticbeanstalk.com";
                        // options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = tokenValidationParameters;
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("WebUserReader", policy =>
                {
                    policy.RequireAssertion(async handler =>
                     {
                         var scopeClaim = handler.User.FindFirst("scope");
                         var scopes = scopeClaim?.Value.Split(' ');
                         var hasScope = scopes?.Where(scope => scope == "http://walmartwebapi-dev.us-east-1.elasticbeanstalk.com/walmart:search").Any() ?? false;
                         return await Task.FromResult(hasScope);
                     });
                });
            });
            services.AddTransient<IServiceContext, WalmartOpenApi>();
            services.AddTransient<IRepository<Item>, ItemRepository>();
            services.AddTransient<IRepository<ItemSearch>, SearchRepository>();
            services.AddTransient<IRepository<ItemRecommendation>, RecommendationRepository>();
            services.AddTransient<IProductService, ProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
