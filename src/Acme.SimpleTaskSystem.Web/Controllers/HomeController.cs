using Microsoft.AspNetCore.Mvc;

namespace Acme.SimpleTaskSystem.Web.Controllers
{
    public class HomeController : SimpleTaskSystemControllerBase
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Tasks");
        }

     
    }
}