using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetHotel.Infrastructure;

namespace PetHotel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<SelectListItem> Species = new List<SelectListItem>();
            Repository rep = new Repository();
            foreach (KeyValuePair<string,int> kvp in rep.Prices )
            {

                Species.Add(new SelectListItem { Text = kvp.Key, Value = kvp.Key });

            }
            
            ViewBag.R_e = Species;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}