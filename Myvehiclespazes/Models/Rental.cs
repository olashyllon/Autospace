using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using Myvehiclespazes.Controllers;

namespace Myvehiclespazes.Models
{
    public class Rental
    {
        public int RentalId { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RentalDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReturnDate { get; set; }
        public int VehicleId { get; set; }
        public int CustomerId { get; set; }
        public bool Returned { get; set; }
        public bool Invoiced { get; set; }

        public int Period

        {
            get
            {
                return ReturnDate.Subtract(RentalDate).Days;
            }
            
           
        }

        public decimal? RentalAmount
        {
            get
            {
                return Period * Vehicle.DailyCost;
            }


        }
        public virtual Customer Customer { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        

       

    }
}