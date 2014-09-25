using PetHotel.Infrastructure;
using PetHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetHotel.Controllers
{
    public class ReservationController : Controller
    {
        //
        // GET: /Reservation/
        public ActionResult Index()
        {
            //instantiates the new object Repository and assigns the value to the viewbags that passed to view index. View Index displays all reservations within the table.
            Repository t = new Repository();
            ViewBag.R_1 = t.Reservations;
            ViewBag.R_2 = t.Prices;
            return View();
        }


        public ActionResult Invoice()
        {
            //instantiates the new object Repository and assigns the value to the viewbags that passed to view invoice. View invoice displays all invoices within the table.
           

            Repository t = new Repository();
            ViewBag.R_C = t.Reservations;
            ViewBag.P = t.Prices;
            return View();
        }

        public ActionResult listinvoice()
        {
            //instantiates the new object Repository and assigns the value to the viewbags that passed to view listinvoice. View listinvoice displays dropdownlist for Customer selection
           
            Repository t = new Repository();
            var B = t.Reservations.Select(r => r.Customer.FirstName + " " + r.Customer.LastName);

            ViewBag.R_e = new SelectList(B, "data");
            ViewBag.R_C = t.Reservations;
            ViewBag.P = t.Prices;
            ViewBag.name=null;

            return View();


        }
        public ActionResult GetInvoice(string data)
        {
            //instantiates the new object Repository and assigns the value  to the viewbags that passed to view listinvoice. Actually the viewbag return only one specific invoice 
           

            Repository t = new Repository();
           //query the reservation object in order to get first and last name of customer
            var B = t.Reservations.Select(r=>r.Customer.FirstName+" "+r.Customer.LastName);
            //create new list with first and last name values.
            ViewBag.R_e = new SelectList(B, "data");
            //returns viewbag with all reservation
            ViewBag.R_C = t.Reservations;
            //returns viewbag with prices 
            ViewBag.P = t.Prices;
            //substract the first name from recieved data in order to select a invoice based on last name
            data = data.Substring(data.IndexOf(" ")+1);
            var Invoice = t.Reservations.Where(r => r.Customer.LastName==data );
            //returns viewbag with one invoice
            ViewBag.name = Invoice;
           
            return View("listinvoice");

        }

        //Action to start reservation of room for pet that shows date from and to, and price for period 
        public ActionResult Makereservation(FormCollection collection)
        {
            //read dropdownlist from teh posted data
            var value = collection["R_e"];
            //creates new list Species 
            List<SelectListItem> Species = new List<SelectListItem>();
            //Instantiates new object of Repository class
            Repository repository = new Repository();
            //Loops through Price dictionary and adds species into list  *KeyValuePair is datatype of dictionary that defines key/value pair *
            foreach (KeyValuePair<string, int> kvp in repository.Prices)
            {

                Species.Add(new SelectListItem { Text = kvp.Key, Value = kvp.Key });

            }
            //Selected properties of selectlistitem class will set a true to passed value of action 
            foreach (SelectListItem li in Species)
            {

                if (li.Text ==value)
                {
                    li.Selected = true; 


                }

            }

            DateTime startDate= DateTime.Parse(collection["startDate"]);
            DateTime endDate=DateTime.Parse( collection["endDate"]);
            Dictionary<int, string> period = new Dictionary<int, string>();
            period.Add(1,collection["startDate"]);
            period.Add(2, collection["endDate"]);
           

            
            int price =repository.Prices[value];


            TimeSpan totaldays = interval(startDate,endDate);

            double totalPrice = totaldays.TotalDays * price;
            ViewBag.interval = period;
            ViewBag.total = totalPrice;
           


         
            
            ViewBag.Spe = Species;
            ViewBag.price = value;
            return View();
        }



        
         public TimeSpan interval(DateTime start,DateTime end)
        {
             TimeSpan totaldays=new TimeSpan();
             totaldays = end - start;
             return totaldays;
        }

        public ActionResult Price(FormCollection collection)
        {

            string oper = collection["operator"];
            var value = collection["Spe"];
            DateTime startDate = DateTime.Parse(collection["startDate"]);
            DateTime endDate = DateTime.Parse(collection["endDate"]);
            TimeSpan totaldays = interval(startDate, endDate);
            Repository repository = new Repository();
            int price =repository.Prices[value];
            double totalPrice = totaldays.TotalDays * price;
            Dictionary<int, string> period = new Dictionary<int, string>();
            period.Add(1, collection["startDate"]);
            period.Add(2, collection["endDate"]);
            List<SelectListItem> Species = new List<SelectListItem>();

            foreach (KeyValuePair<string, int> kvp in repository.Prices)
            {

                Species.Add(new SelectListItem { Text = kvp.Key, Value = kvp.Key });

            }

            if (oper == "CheckPrice")
            {
                ViewBag.Spe = Species;
                ViewBag.interval = period;
                ViewBag.total = totalPrice;
                ViewBag.from = collection["startDate"];
                ViewBag.to = collection["endDate"];
                return View("Makereservation");
            }
            else if(oper=="Continue")
            {
                ViewBag.specie = value;
                ViewBag.interval = period;
                ViewBag.total = totalPrice;
                ViewBag.from=startDate;
                ViewBag.to = endDate;



                return View("Customer");


            }


            return RedirectToAction("index");
         

        }
        public ActionResult Customer(FormCollection collection)
        {
            string firstname = "";
            string lastname = "";
            string address = "";
            string city = "";
            string zipcode = "";
            string email = "";
            string phone = "";
            string specie = "";
            string petname = "";
            DateTime birthday =DateTime.Today;
            DateTime from = DateTime.Today;
            DateTime to = DateTime.Today;
            if (collection["birthday"] != null)
            {
                birthday =DateTime.Parse(collection["birthday"]);

            }
            if (collection["species"] != null)
            {
                specie = collection["species"];

            }

            if (collection["PetName"]!=null)
            {
                petname = collection["PetName"];
            
            }
            if (collection["from"] != null)
            {
             
                from= DateTime.Parse(collection["from"]);
               

            }
            if (collection["to"] != null)
            {
                to = DateTime.Parse(collection["to"]);
              
            }

            
            if (collection["FirstName"]!=null)
            {

                firstname = collection["FirstName"];
            }
            if (collection["LastName"] != null)
            {

                lastname = collection["LastName"];
            }
            if (collection["Address"] != null)
            {

                address = collection["Address"];
            }
            if (collection["City"] != null)
            {

                city = collection["City"];
            }
            if (collection["Zipcode"] != null)
            {

                zipcode = collection["Zipcode"];
            }
            if (collection["Phone"] != null)
            {

                phone = collection["Phone"];
            }
            if (collection["Email"] != null)
            {

                email = collection["Email"];
            }

            Repository rep = new Repository();

            
            if (Session["rep.Reservation"]==null)
            {

                

                Session["rep.Reservation"] = rep.Reservations;
            }
            else
            {


                rep.Reservations = (List<Reservation>)Session["rep.Reservation"];


            }
            Customer customer = new Customer(4, firstname, lastname, address, zipcode, city, email, phone);
                Employee Employee3 = new Employee(2, "Admin", "Admin", "AA", "11111111", rep.Reservations);

                Reservation reservation = new Reservation(4, specie, petname, birthday, from, to, customer, Employee3);


                rep.Reservations.Add(reservation);

            ViewBag.R_1 = rep.Reservations;
            ViewBag.R_2 = rep.Prices;

            return View("index");
        }
       


       

	}
    
}