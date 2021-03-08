using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ISaleService : IDisposable
    {
        void AddSale(SaleDTO saleDTO);
        IEnumerable<SaleDTO> GetAll();
        SaleDTO FindById(int id);
        void Delete(int id);
        void Update(SaleDTO saleDTO);
        IEnumerable<SaleDTO> GetOrdersByClientName(string name);
        IEnumerable<SaleDTO> GetOrdersByManagerName(string name);
    }
}
