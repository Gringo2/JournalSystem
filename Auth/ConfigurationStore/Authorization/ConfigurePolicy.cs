using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Configuration.Authorization
{
    public static class ConfigurePolicy
    {
        public static void AddPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Default",
                    policy => policy.Requirements.Add(new AccountRequirement()));
            });
            services.AddSingleton<IAuthorizationHandler, AccountRequirementHandler>();
        }
    }
}
