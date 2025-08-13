using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.EntityFrameworkCore.DbContexts;

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
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));

                var context = new AppDbContext(optionsBuilder.Options);
                context.Database.Migrate();
                return context;
            }).AsSelf().InstancePerLifetimeScope();

            
        }

    }
}
