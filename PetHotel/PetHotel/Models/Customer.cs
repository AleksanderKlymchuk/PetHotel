using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetHotel.Models
{
    public class Customer:Person
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int C_id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Zipcode { get; set; }
        public  Customer (int c_id,string firstname,string lastname,string address, string zipcode, string city,string email, string phone)
        :  base( c_id, firstname, lastname, phone)
        {

            this.C_id = C_id;
            this.City = City;
            this.Email = Email;
            this.Address = address;
            this.Zipcode = zipcode;
            


        }



    }
}