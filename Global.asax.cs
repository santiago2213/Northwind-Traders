using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Santiago_HW3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Santiago_HW3
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Employee"))
            {
                var role = new IdentityRole();

                role.Name = "Employee";

                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Administrator"))
            {
                var role = new IdentityRole();

                role.Name = "Administrator";

                roleManager.Create(role);

                var user = new ApplicationUser();
                user.Email = "adminuser1@test.com";
                user.UserName = "adminuser1@test.com";

                userManager.Create(user, "Test1234!");

                userManager.AddToRole(user.Id, "Administrator");
            }


            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}