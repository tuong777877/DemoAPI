using DemoMyWebAPI.Models;

namespace DemoMyWebAPI.Repositories.Constracts
{
    public interface ICateCustomerRepository
    {
        List<CateCustomerVM> GetAll();

        CateCustomerVM GetById(int id);

        CateCustomerVM Add(CateCustomerModel model);

        void Update(CateCustomerVM model);

        void Delete(int id);
    }
}