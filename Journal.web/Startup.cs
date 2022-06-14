using Journal.web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.web
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
            services.AddControllersWithViews();

            services.AddRazorPages();

            services.AddHttpClient<IArticleTemplateService, ArticleTemplateService>();

            services.AddHttpClient<IAuthorRequestService, AuthorRequestService>();

            services.AddHttpClient<ICategoryRequestService, CategoryRequestService>();

            services.AddHttpClient<ICommentRequestService, CommentRequestService>();

            services.AddHttpClient<ITopicRequestService, TopicRequestService>();

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<TokenInjectionService>();

            services.AddHttpClient<IPaperRequestService, PaperRequestService>();

            services.AddHttpClient<IInstitutionRequestService, InstitutionRequestService>();

            services.AddHttpClient<IHopRequestService, HopRequestService>();

            services.AddHttpClient<INotificationRequestService, NotificationRequestService>();

            services.AddHttpClient<IEditDecisionService, EditDecisionService>();

            services.AddHttpClient<IEditorService, EditorService>();

            services.AddHttpClient<IReviewerService, ReviewerService>();

            services.AddHttpClient<IEditDecisionService, EditDecisionService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
           {
               options.SignInScheme = "Cookies";
               options.Authority = "https://localhost:5001";
               options.ClientId = "interactive";
               options.ClientSecret = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0";
               options.ResponseType = "code";
               options.Scope.Add("roles");
               options.Scope.Add("lastname");
               options.SaveTokens = true;
               options.GetClaimsFromUserInfoEndpoint = true;
               options.ClaimActions.MapUniqueJsonKey("role", "role", "role");
               options.TokenValidationParameters.NameClaimType = "name";
               options.TokenValidationParameters.RoleClaimType = "role";
               options.TokenValidationParameters.NameClaimType = "firstname";
               options.TokenValidationParameters.NameClaimType = "lastname";
               
           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>

            {
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                name: "Users",
                areaName: "Dashboards",
                pattern: "{area:exists}/{controller=dashboard}/{action=Index}/{id?}");

                endpoints.MapRazorPages();

            });

        }
    }
}
