using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SaleDTO
    {
        public int Id { get; set; }
        public string SaleManager { get; set; }
        public DateTime Date { get; set; }
        public string ClientName { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
    }
}
