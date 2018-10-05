using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AES.Configurations;
using AES.Data;
using AES.Data.DataSources;
using AES.Data.Repositories;
using AES.Domains.WalmartApi;
using AES.Service.Mappings;
using AES.Service.Products;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WalmartStore.Services;

namespace WalmartStore
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(options => {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect("AwsCognito", o =>
            {
                o.ClientId = Configuration.GetValue<string>("AwsCognitoOAuth:ClientId"); 
                o.ClientSecret = Configuration.GetValue<string>("AwsCognitoOAuth:ClientSecret"); 
                o.Authority = Configuration.GetValue<string>("AwsCognitoOAuth:Authority");
                o.ResponseType = "code";
                o.GetClaimsFromUserInfoEndpoint = true;

                o.Events = new OpenIdConnectEvents
                {
                    OnRedirectToIdentityProviderForSignOut = (context) =>
                    {
                        var logoutUri = $"{Configuration.GetValue<string>("AwsCognitoOAuth:LogoutEndpoint")}?client_id={Configuration.GetValue<string>("AwsCognitoOAuth:ClientId")}&logout_uri={Configuration.GetValue<string>("AwsCognitoOAuth:LogoutUri")}";

                        var postLogoutUri = context.Properties.RedirectUri;
                        if (!string.IsNullOrEmpty(postLogoutUri))
                        {
                            if (postLogoutUri.StartsWith("/"))
                            {
                                // transform to absolute
                                var request = context.Request;
                                postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
                            }
                            logoutUri += $"&returnTo={ Uri.EscapeDataString(postLogoutUri)}";
                        }

                        context.Response.Redirect(logoutUri);
                        context.HandleResponse();

                        return Task.CompletedTask;
                    }
                };
            });
            var cognitoSettings = Configuration.GetSection("AwsCognitoOAuth");
            services.Configure<AwsCognitoSettings>(Configuration.GetSection("AwsCognitoOAuth"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<IServiceContext, WalmartOpenApi>();
            services.AddTransient<IRepository<Item>, ItemRepository>();
            services.AddTransient<IRepository<ItemSearch>, SearchRepository>();
            services.AddTransient<IRepository<ItemRecommendation>, RecommendationRepository>();
            services.AddTransient<IProductService, ProductService>();
            //services.AddTransient<IWalmartStoreService, WalmartStoreService>();
            services.AddTransient<IWalmartStoreService, WalmartStoreWebapi>();
            services.AddSingleton<ITokenService, CognitoTokenService>();


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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
