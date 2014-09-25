using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson5.Controllers
{
    public class SelectlistController : Controller
    {
        //
        // GET: /Selectlist/
        public ActionResult Index(string Countries)
        {
            List<SelectListItem> countries = new List<SelectListItem>();
         
            if (Session["countries"]==null)
            {

                
                countries.Add(new SelectListItem { Text = "China", Value = "CN" });
                countries.Add(new SelectListItem { Text = "Ukraine", Value = "UA" });
                Session["countries"]=countries;

            }
            else
            {

                countries = (List < SelectListItem >) Session["countries"];


            }
           


            foreach(SelectListItem li in countries)
            {
                if(li.Value==Countries)
                {

                    li.Selected = true;

                }


            }

            ViewBag.Countries = countries;
            ViewBag.CountryCode = Countries;
            return View();
        }
	}
}