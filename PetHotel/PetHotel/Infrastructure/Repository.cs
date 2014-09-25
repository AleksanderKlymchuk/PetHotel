using PetHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PetHotel.Infrastructure
{
    public class Repository
    {
        //creates dicitonary to store pet and price
        Dictionary<string, int> prices = new Dictionary<string, int>();
        public Dictionary<string, int> Prices { get { return prices; } }
        //creates list of reservations
        private  List<Reservation> reservations = new List<Reservation>();
        //Properties taht assign value to the list reservations
        public List<Reservation> Reservations { get { return reservations; } set { reservations = value; } }
        
       

        public Repository()
        {
            //add name and price to dictionary Price 
            prices.Add("Cat", 140);
            prices.Add("Dog", 180);
            prices.Add("Snake", 120);
            prices.Add("Guinea Pig", 75);
            prices.Add("Ganary", 60);
            prices.Add("Chinchilla", 80); 
            prices.Add(" Hamster", 80); 
            prices.Add("Rabit",80);
            prices.Add("Igunas",155);
            prices.Add(" Bird spider",90);
            //instantiates the new objects "customers" with parameters that are passed through costructor
            Customer customer1 = new Customer(1, "Oleksandr", "Klymchuk", "Ankjæer205", "8300", "Odder", "Olkly85@gmail.com", "22222222");
            Customer customer2 = new Customer(2, "Brian", "Smith", "Algade 108", "8000", "Aarhus", "brsm@xmail.dk", "45454545");
            Customer customer3 = new Customer(3, "Henril", "Nielsen", "Rosensgade 108", "8300", "Odder", "h_n@xmail.dk", "45454545");
            //instantiates the new objects "employee" with parameters that are passed through costructor
              Employee Employee1 = new Employee(1, "Bajrne", "Nielsen", "BN", "33333333",reservations );
              Employee Employee2 = new Employee(2, "Thomas", "Barde", "TB", "44444444",reservations );


              //instantiates the new objects "reservation" with parameters that are passed through costructor
              Reservation reservation1 = new Reservation(1, "Dog", "Hamlet",new DateTime(2007,10,2), new DateTime(2014, 9, 2), new DateTime(2014,9,20),customer1,Employee1);
              Reservation reservation2 = new Reservation (2, "Dog", "Samson",new DateTime(2004,6,5), new DateTime(2014, 9, 14), new DateTime(2014, 9, 21),customer2,Employee1);
              Reservation reservation3 = new Reservation(3, "Cat", "Darla",new DateTime(2009,1,3),new DateTime(2014, 9, 7), new DateTime(2014, 9, 10), customer3,Employee2);

          
            
             //add reservation to list reservation
              reservations.Add(reservation1);
              reservations.Add(reservation2);
              reservations.Add(reservation3);
             
        
        }
        

                 

        }

    }
