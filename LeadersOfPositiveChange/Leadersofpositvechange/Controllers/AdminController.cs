//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

using System.Web.Mvc;

namespace Leadersofpositvechange.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private string ClassName = typeof(AdminController).Name;

        public AdminController()
        {

        }

        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }

    }
}