using DemoMyWebAPI.Models;

namespace DemoMyWebAPI.Repository.Constracts
{
    public interface ICateCarRepository
    {
        List<CateCarVM> GetAll();

        CateCarVM GetById(int id);

        CateCarVM Add(CateCarModel model);

        void Update(CateCarModel cateacarVM, int id);

        void Delete(int id);
    }
}