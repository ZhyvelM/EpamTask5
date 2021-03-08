using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EpamTask5.Models
{
    public class SaleViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Manager")]
        public string SaleManager { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Client")]
        public string ClientName { get; set; }

        [Display(Name = "Product")]
        public string Product { get; set; }

        [Min(0.1, ErrorMessage = "value must be more than 0")]
        [Display(Name = "Price")]
        public double Price { get; set; }
    }
}