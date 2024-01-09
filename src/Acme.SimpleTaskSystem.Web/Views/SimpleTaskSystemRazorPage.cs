using Abp.AspNetCore.Mvc.Views;

namespace Acme.SimpleTaskSystem.Web.Views
{
    public abstract class SimpleTaskSystemRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected SimpleTaskSystemRazorPage()
        {
            LocalizationSourceName = SimpleTaskSystemConsts.LocalizationSourceName;
        }
    }
}
