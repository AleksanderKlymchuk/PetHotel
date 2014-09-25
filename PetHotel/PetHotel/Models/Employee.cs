using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetHotel.Models
{
    //inherit class from Person
    public class Employee:Person
    {

    //fields for storing data
        public int E_id { get; set; }
        public string Initials { get; set; }
        [StringLength(8), Required]
        public List<Reservation> Reservation { get; set; }


        //constructor that pass paramet to inherit's class constructor
        public Employee( int e_id,string firstname,string lastname, string initials,string phone, List< Reservation> reservation )
            : base(e_id, firstname, lastname, phone)
        {
            this.E_id = e_id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Initials = initials;
            this.Phone = phone;
            this.Reservation = reservation;




        }
         

        
        
     
     
     
    
    }
}