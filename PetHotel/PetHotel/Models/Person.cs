using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetHotel.Models
{
    public class Person
    {
        //fields for storing data
        
        public int P_id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        [StringLength(8), Required]
        public string Phone { get; set; }
        //Constructor with parameters
        public Person(int p_id,string firstname,string lastname, string phone)
        {   
            this.P_id = p_id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Phone = phone;


        }

      


    }
}