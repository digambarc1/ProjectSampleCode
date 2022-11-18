using CarDekho.Models;

namespace CarDekho.Repository
{
    public interface IUsedCarRepo
    {

        public Task<UsedCar> CreateCar(UsedCar usedCar);

        public Task UpdateCarDetails(int id, UsedCar usedCar);



    }
}
