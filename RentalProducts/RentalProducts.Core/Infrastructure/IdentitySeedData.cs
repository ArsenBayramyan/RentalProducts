using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalProducts.Core.Infrastructure
{
    public static class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Parol123$";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                UserManager<IdentityUser> userManager = (UserManager<IdentityUser>)scope.ServiceProvider
                                                         .GetService(typeof(UserManager<IdentityUser>));

                IdentityUser user = await userManager.FindByNameAsync(adminUser);
                if (user == null)
                {
                    user = new IdentityUser("Admin");
                    await userManager.CreateAsync(user, adminPassword);
                }
            }
        }
    }
}
