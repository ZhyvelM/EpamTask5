using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EpamTask5.Models
{
    public class SaleFilter
    {
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Display(Name = "Client")]
        [MaxLength(25, ErrorMessage = "Max length for this field is 25")]
        public string ClientName { get; set; }

        [Display(Name = "Product")]
        [MaxLength(10, ErrorMessage = "Max length for this field is 10")]
        public string Product { get; set; }

        [Display(Name = "Manager")]
        [MaxLength(25, ErrorMessage = "Max length for this field is 25")]
        public string SaleManager { get; set; }

        [Display(Name = "Price")]
        [Range(0.0, Double.MaxValue, ErrorMessage = "The price must be greater than 0.")]
        public double Price { get; set; }
    }
}