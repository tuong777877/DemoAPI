using DemoMyWebAPI.Models;

namespace DemoMyWebAPI.Repositories.Constracts
{
    public interface ICustomerRepository
    {
        public List<CustomerVM> GetAll();

        CustomerVM GetById(string id);

        CustomerVM Create(CustomerModel model);

        void Update(CustomerVM model);

        void Delete(string id);
    }
}