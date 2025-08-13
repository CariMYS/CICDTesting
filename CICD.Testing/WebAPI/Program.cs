using Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.Persistence.EntityFrameworkCore.Interfaces;
using Core.Persistence.EntityFrameworkCore;
using Persistence.EntityFrameworkCore;
using Core.CQRS;
using Core.CQRS.RequestHandler;
using System.Reflection;
using Application.Interfaces.RepositoryInterfaces;
using Persistence.EntityFrameworkCore.DbContexts;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutofacPersistenceModule(builder.Configuration));
    containerBuilder.RegisterType<UnitOfWork<AppDbContext>>()
                    .As<IUnitOfWork>()
                    .InstancePerLifetimeScope();
    containerBuilder.RegisterType<Mediator>()
                    .As<IMediator>()
                    .InstancePerLifetimeScope();
    containerBuilder.RegisterAssemblyTypes(typeof(IProjectRepository).Assembly)
        .AsClosedTypesOf(typeof(IRequestHandler<,>))
        .InstancePerLifetimeScope();
    containerBuilder.RegisterAssemblyTypes(typeof(IProjectRepository).Assembly)
        .AsClosedTypesOf(typeof(INotificationHandler<>))
        .InstancePerLifetimeScope();
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
