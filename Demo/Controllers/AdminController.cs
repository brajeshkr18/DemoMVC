using Demo.Web.Helper;
using System.Web.Mvc;
using Utility;

namespace Demo.Controllers
{
    [CustomAuthorize]
    [RoleAuthorize(AppConstant.RoleAdmin,AppConstant.RoleSuperAdmin)]
    public class AdminController : Controller
    {
        // GET: Admin

        public ActionResult Dashboard()
        {
            return View();
        }
       
    }
}