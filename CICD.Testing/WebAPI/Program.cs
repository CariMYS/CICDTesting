using Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.Persistence.EntityFrameworkCore.Interfaces;
using Core.Persistence.EntityFrameworkCore;
using Persistence.EntityFrameworkCore;
using Core.CQRS;
using Core.CQRS.RequestHandler;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutofacPersistenceModule(builder.Configuration));
    containerBuilder.RegisterType<UnitOfWork>()
                    .As<IUnitOfWork>()
                    .InstancePerLifetimeScope();
    containerBuilder.RegisterType<Mediator>()
                    .As<IMediator>()
                    .InstancePerLifetimeScope();
    containerBuilder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
        .AsClosedTypesOf(typeof(IRequestHandler<,>))
        .InstancePerLifetimeScope();
    containerBuilder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
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
