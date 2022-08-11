using DemoMyWebAPI.Models;

namespace DemoMyWebAPI.Repository.Constracts
{
    public interface ICarRepository
    {
        List<CarVM> GetAll();

        CarVM GetById(string id);

        CarVM Add(CarModel model);

        void Update(CarVM carVM);

        void Delete(string id);
    }
}