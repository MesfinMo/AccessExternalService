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
                o.ClientId = "7fd9vbf3ms8rmo6nbvqb1euksv";
                o.ClientSecret = "1jb9lshlk8hdvatku6gj6crccipk23t2i66iic4o6r10nettgi26";
                o.Authority = "https://cognito-idp.us-east-1.amazonaws.com/us-east-1_Me0SZg8qw";
                o.ResponseType = "code";
                o.GetClaimsFromUserInfoEndpoint = true;

                o.Events = new OpenIdConnectEvents
                {
                    OnRedirectToIdentityProviderForSignOut = (context) =>
                    {
                        var logoutUri = $"https://clientcredential.auth.us-east-1.amazoncognito.com/logout?client_id=7fd9vbf3ms8rmo6nbvqb1euksv&logout_uri=http://localhost:36355";

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
