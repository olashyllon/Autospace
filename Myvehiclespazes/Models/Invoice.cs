using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Myvehiclespazes.Models
{
    public class Invoice
    {
        
        public int InvoiceId { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime InvoiceDate { get; set; }
        
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }

        

       
    }
}