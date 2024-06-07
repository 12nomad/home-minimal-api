using HomeMinimalApi.Common.Auth.Enums;

namespace HomeMinimalApi.Common.Auth.Extensions;

public static class AuthExtension {
    public static IServiceCollection AddListingsAuthorization(this IServiceCollection services) {
        services.AddAuthorization(policies => {
            policies.AddPolicy(Policies.READ_ACCESS.ToString(), builder => builder.RequireClaim("scope", "listings:read"));
            policies.AddPolicy(Policies.WRITE_ACCESS.ToString(), builder => builder.RequireClaim("scope", "listings:write")
                                                                                    .RequireRole(Role.ADMIN.ToString())); // .RequireClaim("role", Role.ADMIN.ToString());  
        });
        return services;
    }
}