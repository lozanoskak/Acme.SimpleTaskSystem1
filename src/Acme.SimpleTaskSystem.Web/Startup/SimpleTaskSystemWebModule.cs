using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AspNetCore.SignalR;
using Abp.Dependency;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Acme.SimpleTaskSystem.Configuration;
using Acme.SimpleTaskSystem.EntityFrameworkCore;
using Acme.SimpleTaskSystem.EventHandlers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;


namespace Acme.SimpleTaskSystem.Web.Startup
{
    [DependsOn(
        typeof(SimpleTaskSystemApplicationModule), 
        typeof(SimpleTaskSystemEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    [DependsOn(typeof(AbpAspNetCoreSignalRModule))]
    public class SimpleTaskSystemWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public SimpleTaskSystemWebModule(IWebHostEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(SimpleTaskSystemConsts.ConnectionStringName);

            //IocManager.Register<ITransientDependency, TaskModifiedEventHandler>();

            Configuration.Navigation.Providers.Add<SimpleTaskSystemNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(SimpleTaskSystemApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SimpleTaskSystemWebModule).GetAssembly());

        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(SimpleTaskSystemWebModule).Assembly);
        }
    }
}
