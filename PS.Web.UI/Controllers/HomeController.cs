using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PS.Web.UI.Controllers
{
    public partial class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page for islamic ";
            //this is a 
            return View();
        }

    }
}
