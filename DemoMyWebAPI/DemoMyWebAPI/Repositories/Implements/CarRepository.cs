using DemoMyWebAPI.Data;
using DemoMyWebAPI.Model;
using DemoMyWebAPI.Models;
using DemoMyWebAPI.Repository.Constracts;

namespace DemoMyWebAPI.Repository.Implements
{
    public class CarRepository : ICarRepository
    {
        private readonly CarStoreContext _context;
        public CarRepository(CarStoreContext context)
        {
            _context = context;
        }
        public List<CarVM> GetAll()
        {
            var car = _context.Cars.Select(c => new CarVM
            {
                Id = c.Id,
                Name = c.Name,
                Price = c.Price,
                DateRelease = c.DateRelease,
                Descirption = c.Descirption,
                Status = c.Status,
                NameCate = c.catecar.Name,
            });
            return car.ToList();
        }

        public CarVM GetById(string id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == Guid.Parse(id));
            if (car != null)
            {
                return new CarVM
                {
                    Name = car.Name,
                    Id = car.Id,
                    Price = car.Price,
                    DateRelease = car.DateRelease,
                    Descirption = car.Descirption,
                    NameCate = car.catecar.Name,
                    Status = car.Status,
                };
            }
            return null;
        }
        public CarVM Add(CarModel model)
        {
            var car = new Car
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Price = model.Price,
                Descirption = model.Descirption,
                Status = model.Status,
                IdCate=model.IdCate,
            };
            _context.Add(car);
            _context.SaveChanges();
            return new CarVM
            {
                Id = car.Id,
                Name = car.Name,
                DateRelease = car.DateRelease,
                Descirption = car.Descirption,
                Price = car.Price,
                Status = car.Status,
                NameCate = car.catecar.Name,
            };
        }
        public void Update(CarVM carVM)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == carVM.Id);
            if (car != null)
            {
                carVM.Name = carVM.Name;
                carVM.Price=carVM.Price;
                carVM.Descirption = carVM.Descirption;
                carVM.Status = carVM.Status;
                carVM.DateRelease = carVM.DateRelease;
                carVM.NameCate = carVM.NameCate;
                _context.SaveChanges();
            }
        }
        public void Delete(string id)
        {
            var car = _context.Cars.SingleOrDefault(cc => cc.Id == Guid.Parse(id));
            if (car != null)
            {
                _context.Remove(car);
                _context.SaveChanges();
            }
        }


    }
}
