using AutoMapper;
using BL.Interfaces;
using DAL;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Elements
{
    public class SaleService : ISaleService
    {
        private bool _disposed = false;
        private IMapper _mapper;

        private IUnitOfWork Database { get; set; }

        public SaleService(IUnitOfWork uow)
        {
            Database = uow;
            _mapper = new Mapper(MapperConfig.Configure());
        }        

        ~SaleService() => Dispose(false);

        public void AddSale(SaleDTO saleDTO)
        {
            var sale = new Sale()
            {
                ClientName = saleDTO.ClientName,
                SaleManager = saleDTO.SaleManager,
                Price = saleDTO.Price,
                Product = saleDTO.Product,
                Date = saleDTO.Date
            };
            Database.Sales.Add(sale);
            Database.Save();
        }

        public void Delete(int id)
        {
            var sale = Database.Sales.Get(x => x.Id.Equals(id));
            Database.Sales.Delete(sale);
            Database.Save();
        }

        public SaleDTO FindById(int id)
        {
            return _mapper.Map<Sale,SaleDTO>(Database.Sales.Get(x => x.Id.Equals(id)));
        }

        public IEnumerable<SaleDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Sale>, IEnumerable<SaleDTO>>(Database.Sales.Get());
        }

        public IEnumerable<SaleDTO> GetOrdersByClientName(string name)
        {
            return _mapper.Map<IEnumerable<Sale>, IEnumerable<SaleDTO>>(Database.Sales.Get().Where(x => x.ClientName.Equals(name)));
        }

        public IEnumerable<SaleDTO> GetOrdersByManagerName(string name)
        {
            return _mapper.Map<IEnumerable<Sale>, IEnumerable<SaleDTO>>(Database.Sales.Get().Where(x => x.SaleManager.Equals(name)));
        }

        public void Update(SaleDTO saleDTO)
        {
            var sale = Database.Sales.Get(x => x.Id.Equals(saleDTO.Id));
            sale.Price = saleDTO.Price;
            sale.Product = saleDTO.Product;
            sale.SaleManager = saleDTO.SaleManager;
            sale.ClientName = saleDTO.ClientName;
            sale.Date = saleDTO.Date;
            Database.Sales.Update(sale);
            Database.Save();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Database.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
