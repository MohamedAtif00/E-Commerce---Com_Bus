using E_Commerce.Identity.Domain.Model.UserAggre;
using E_Commerce.Identity.Domain.Model.UserRoleAggre;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Api.seed
{
    public static class AdminSeeder
    {
        public static async Task SeedAdminUserAsync(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            // Retrieve the required services
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<UserRole>>();

            // Admin role name
            string adminRoleName = "Admin";

            // Admin credentials
            string adminEmail = "admin@example.com"; // Replace with valid email format if needed
            string adminPassword = "123";

            // Ensure the Admin role exists
            if (!await roleManager.RoleExistsAsync(adminRoleName))
            {
                var adminRole = new UserRole { Name = adminRoleName };
                var roleResult = await roleManager.CreateAsync(adminRole);
                if (!roleResult.Succeeded)
                {
                    throw new Exception("Failed to create admin role: " + string.Join(", ", roleResult.Errors.Select(e => e.Description)));
                }
            }

            // Check if the admin user already exists
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new E_Commerce.Identity.Domain.Model.UserAggre.User
                (
                    adminEmail,
                    "Admin",
                    "Admin"
                );

                adminUser.UserName = "Admin";

                // Create the admin user with the specified password
                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    // Assign the admin role to the user
                    var addToRoleResult = await userManager.AddToRoleAsync(adminUser, adminRoleName);
                    if (!addToRoleResult.Succeeded)
                    {
                        throw new Exception("Failed to assign admin role: " + string.Join(", ", addToRoleResult.Errors.Select(e => e.Description)));
                    }
                }
                else
                {
                    // Handle errors
                    throw new Exception("Failed to create admin user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }
        }

    }

}
