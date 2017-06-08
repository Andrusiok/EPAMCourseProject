using System.Data.Entity;
using BLL.Interfaces.Services;
using BLL.Interfaces.Entities;
using BLL;
using BLL.Services;
using DAL.Repositories;
using DAL.Interfaces.DTO;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Mvc.FilterBindingSyntax;
using ORM;
using DAL.Interfaces;
using DAL.Interfaces.Interfaces;
using DAL;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverWeb(this IKernel kernel) => Configure(kernel, true);

        public static void ConfigurateResolverConsole(this IKernel kernel) => Configure(kernel, false);

        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<DbContext>().To<BlogContext>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<BlogContext>().InSingletonScope();
            }

            kernel.Bind<IService<UserEntity>().To<UserService>();
            kernel.Bind<IRepository<DALUser>>().To<UserRepository>();
            kernel.Bind<IRepository<DALBlog>>().To<BlogRepository>();
            kernel.Bind<IRepository<DALLike>>().To<LikeRepository>();
            kernel.Bind<IRepository<DALPost>>().To<PostRepository>();
            kernel.Bind<IRepository<DALImage>>().To<ImageRepository>();
            kernel.Bind<IRepository<DALComment>>().To<CommentRepository>();
            kernel.Bind<IRepository<DALTag>>().To<TagRepository>();
        }

    }

}