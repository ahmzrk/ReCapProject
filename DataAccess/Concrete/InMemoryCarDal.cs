using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=12,ModelYear=2016,DailyPrice=800000,Description="Hatasız" },
                new Car{CarId=2,BrandId=3,ColorId=11,ModelYear=2013,DailyPrice=600000,Description="Aile Aracı" },
                new Car{CarId=3,BrandId=1,ColorId=8,ModelYear=2019,DailyPrice=1000000,Description="Sıfır Ayarında" },
                new Car{CarId=4,BrandId=2,ColorId=26,ModelYear=2022,DailyPrice=1800000,Description="Garaj arabası" },
                new Car{CarId=5,BrandId=3,ColorId=3,ModelYear=2006,DailyPrice=400000,Description="Serseiden serseriye" }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c=>c.CarId==carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=>c.CarId == car.CarId);
            carToUpdate.BrandId=car.BrandId;
            carToUpdate.ColorId=car.ColorId;
            carToUpdate.ModelYear=car.ModelYear;
            carToUpdate.DailyPrice=car.DailyPrice;
            carToUpdate.Description=car.Description;
        }
    }
}
