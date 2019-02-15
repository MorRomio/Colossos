using AuthSys.DataAccessLayer;
using AuthSys.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(AuthSys.Startup))]
namespace AuthSys
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
            CreateRolesAndUsers();
        }


        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

         //   try
         //   {

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                if (!roleManager.RoleExists("Admin"))
                {
                    // first we create Admin rool   
                    var roleAdmin = new IdentityRole();
                    roleAdmin.Name = "Admin";
                    roleManager.Create(roleAdmin);

                    //Create super user
                    var superUser = new ApplicationUser();
                    superUser.UserName = "MagiQ";
                    superUser.Email = "my_isis@hotmail.com";

                    string userPWD = "36Magiq";

                    var chkUser = userManager.Create(superUser, userPWD);

                    //Add default User to Role Admin   
                    if (chkUser.Succeeded)
                    {
                        var result1 = userManager.AddToRole(superUser.Id, "Admin");

                    }

                    // creating normal user role    
                    if (!roleManager.RoleExists("Employee"))
                    {
                        var normRole = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                        normRole.Name = "NormalUser";
                        roleManager.Create(normRole);
                    }
                }
          /*  } catch(Exception e)
            {
                Console.WriteLine(e);
            }*/
            
        }
    }
}
