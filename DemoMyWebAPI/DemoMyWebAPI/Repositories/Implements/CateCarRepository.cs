using DemoMyWebAPI.Models;

namespace DemoMyWebAPI.Repository.Implements
{
    public class CateCarRepository : ICateCarRepository
    {
        private readonly CarStoreContext _context;

        public CateCarRepository(CarStoreContext context)
        {
            _context = context;
        }

        public List<CateCarVM> GetAll()
        {
            var catecar = _context.CateCars.Select(cc => new CateCarVM
            {
                Id = cc.Id,
                Name = cc.Name,
            });
            return catecar.ToList();
        }

        public CateCarVM GetById(int id)
        {
            var catecar = _context.CateCars.SingleOrDefault(cc => cc.Id == id);
            if (catecar != null)
            {
                return new CateCarVM
                {
                    Id = catecar.Id,
                    Name = catecar.Name,
                };
            }
            return null;
        }

        public CateCarVM Add(CateCarModel model)
        {
            var catecar = new CateCar
            {
                Name = model.Name,
            };
            _context.Add(catecar);
            _context.SaveChanges();
            return new CateCarVM
            {
                Id = catecar.Id,
                Name = catecar.Name,
            };
        }

        public void Update(CateCarModel model,int id)
        {
            var catecar = _context.CateCars.SingleOrDefault(cc => cc.Id == id);
            if (catecar != null)
            {
                catecar.Name = model.Name;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var catecar = _context.CateCars.SingleOrDefault(cc => cc.Id == id);
            if (catecar != null)
            {
                _context.Remove(catecar);
                _context.SaveChanges();
            }
        }
    }
}