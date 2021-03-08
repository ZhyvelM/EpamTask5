using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EpamTask5.Models
{
    public class CreateSaleViewModel
    {
        [Required(ErrorMessage = "EnterValue")]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "EnterValue")]
        [Display(Name = "Price")]
        [Min(1, ErrorMessage = "Value must be higher than 1")]
        public double Price { get; set; }

        [Required(ErrorMessage = "EnterValue")]
        [Display(Name = "ClientName")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "EnterValue")]
        [Display(Name = "Product")]
        public string Product { get; set; }

        [Required(ErrorMessage = "EnterValue")]
        [Display(Name = "SaleManager")]
        public string SaleManager { get; set; }
    }
}