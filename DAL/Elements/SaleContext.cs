using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SaleContext : DbContext
    {
        public SaleContext() : base("name=DbConnection")
        { }

        public virtual DbSet<Sale> Sales { get; set; }
    }
}
