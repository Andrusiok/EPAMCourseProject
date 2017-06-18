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
            context.SaveChanges();

            context.Users.Add(new User { Id = 1, Name = "Andrew", RoleId = 1, Password = "65e84be33532fb784c48129675f9eff3a682b27168c0ea744b2cf58ee02337c5" });
            context.Users.Add(new User { Id = 2, Name = "Mathew", RoleId = 2, Password = "65e84be33532fb784c48129675f9eff3a682b27168c0ea744b2cf58ee02337c5" });
            context.SaveChanges();
            context.Blogs.Add(new Blog { Id = 1 });
            context.Blogs.Add(new Blog { Id = 2 });
            context.SaveChanges();
        }
    }
}
