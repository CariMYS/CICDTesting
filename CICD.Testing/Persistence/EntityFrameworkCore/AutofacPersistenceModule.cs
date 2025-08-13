using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.RepositoryInterfaces;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.EntityFrameworkCore.DbContexts;
using Persistence.EntityFrameworkCore.Repositories;

namespace Persistence.EntityFrameworkCore
{
    public class AutofacPersistenceModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public AutofacPersistenceModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var config = c.Resolve<IConfiguration>();
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));
                var context = new AppDbContext(optionsBuilder.Options);
                context.Database.Migrate();
                return context;
            }).As<AppDbContext>().InstancePerLifetimeScope();

            builder.RegisterType<EFTaskRepository>()
                .As<ITaskRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<EFTaskCommentRepository>()
                .As<ITaskCommentRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<EFProjectRepository>()
                .As<IProjectRepository>()
                .InstancePerLifetimeScope();
        }

    }
}
