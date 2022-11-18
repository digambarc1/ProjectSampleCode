
namespace CarDekho.Service
{

    using CarDekho.Models;
    using CarDekho.Repository;
    using System.Web.Http;

    public class UsedCarService:IUsedCarRepo
    {
        private readonly CarDekhoDBContext UsedCarRepo;

        public UsedCarService(CarDekhoDBContext u)
        {
          UsedCarRepo = u;
        }

        public async Task<UsedCar> CreateCar( UsedCar usedCar)
        {
            var res = await UsedCarRepo.UsedCars.AddAsync(usedCar);
            await UsedCarRepo.SaveChangesAsync();
            return res.Entity;
        }

        public async Task UpdateCarDetails(int id, [FromBody]UsedCar usedCar)
        {
            var temp = UsedCarRepo.UsedCars.FirstOrDefault(a => a.UsedCarId == id);

            temp.UcarCost = usedCar.UcarCost;
            temp.UcarDriven = usedCar.UcarDriven;
            temp.UcarInsuranceType = usedCar.UcarInsuranceType;
            temp.UcarMileage = usedCar.UcarMileage;
            temp.UcarName = usedCar.UcarName;
            temp.UcarNoOfPrevOwner = usedCar.UcarNoOfPrevOwner;
            temp.UcarRto = usedCar.UcarRto;
            temp.UcarStatus = usedCar.UcarStatus;
            temp.BookingStatus = usedCar.BookingStatus;

             await this.UsedCarRepo.SaveChangesAsync();

            
        }
    }
}
