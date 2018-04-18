using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Myvehiclespazes.Models
{
    public class Vehicle
    {
        
        public int VehicleId { get; set; }
        public string ModelName { get; set; }
        
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal DailyCost { get; set; }
       
        public string Brand { get; set; }
       
        public string Vin { get; set; }
        
        public bool Available { get; set; }

        
        public virtual ICollection<Rental> Rentals { get; set; }

        


    }
}