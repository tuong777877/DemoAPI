using DemoMyWebAPI.Models;
using DemoMyWebAPI.Repositories.Constracts;

namespace DemoMyWebAPI.Repositories.Implements
{
    public class CateCustomerRepository : ICateCustomerRepository
    {
        private readonly CarStoreContext _context;

        public CateCustomerRepository(CarStoreContext context)
        {
            _context = context;
        }

        public List<CateCustomerVM> GetAll()
        {
            var catecus = _context.CateCustomers.Select(c => new CateCustomerVM
            {
                Id = c.Id,
                Name = c.Name,
            });
            return catecus.ToList();
        }

        public CateCustomerVM GetById(int id)
        {
            var catecus = _context.CateCustomers.SingleOrDefault(c => c.Id == id);
            if (catecus != null)
            {
                return new CateCustomerVM
                {
                    Id = catecus.Id,
                    Name = catecus.Name,
                };
            }
            else
            {
                return null;
            }
        }

        public CateCustomerVM Add(CateCustomerModel model)
        {
            var catecus = new CateCustomer
            {
                Name = model.Name,
            };
            _context.Add(catecus);
            _context.SaveChanges();
            return new CateCustomerVM
            {
                Id = catecus.Id,
                Name = catecus.Name,
            };
        }

        public void Update(CateCustomerVM model)
        {
            var catecus = _context.CateCustomers.SingleOrDefault(c => c.Id == model.Id);
            if (catecus != null)
            {
                model.Name = model.Name;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var catecus = _context.CateCustomers.SingleOrDefault(c => c.Id == id);
            if (catecus != null)
            {
                _context.Remove(catecus);
                _context.SaveChanges();
            }
        }
    }
}