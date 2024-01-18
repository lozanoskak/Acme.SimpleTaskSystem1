using Abp.AspNetCore.SignalR;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;


namespace Acme.SimpleTaskSystem
{
    [DependsOn(
        typeof(SimpleTaskSystemCoreModule), 
        typeof(AbpAutoMapperModule),
        typeof(AbpAspNetCoreSignalRModule))]

    public class SimpleTaskSystemApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SimpleTaskSystemApplicationModule).GetAssembly());
        }
    }
}