using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace PetHotel.Models
{
    public class Reservation
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int R_id { get; set; }
        public string Cpecie { get; set; }
        public string PetName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
       
        public  Reservation(int reservationId, string cpecie,string petName,DateTime birthday,DateTime startDate, DateTime endDate,Customer customer,Employee employee)
        {

            this.Birthday = birthday;
            this.Cpecie = cpecie;
            this.Customer = customer;
            this.StartDate = startDate;
            this.R_id = reservationId;
            this.PetName = petName;
            this.EndDate = endDate;
            this.Employee = employee;
        }


    }
}