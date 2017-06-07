using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    class DbInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            base.Seed(context);
            context.Roles.Add(new Role { RoleId = 1, RoleName = "Admin" });
            context.Roles.Add(new Role { RoleId = 2, RoleName = "User" });

            context.Users.Add(new User { UserName = "Andrew", RoleId = 1, Password = "qwerty" });
            context.Users.Add(new User { UserName = "Mathew", RoleId = 2, Password = "qwerty" });
            context.Users.Add(new User { UserName = "Basil", RoleId = 2, Password = "qwerty" });
            context.Users.Add(new User { UserName = "Kate", RoleId = 2, Password = "qwerty" });
            context.Users.Add(new User { UserName = "Mate", RoleId = 2, Password = "qwerty" });
            context.SaveChanges();

        }
    }
}
