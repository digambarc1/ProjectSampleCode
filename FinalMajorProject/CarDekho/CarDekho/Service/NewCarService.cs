namespace CarDekho.Service
{
    using CarDekho.Models;
    using CarDekho.Repository;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class NewCarService: INewCarRepo
    {
        private readonly CarDekhoDBContext carCot;

        public NewCarService(CarDekhoDBContext carCot)
        {
            this.carCot = carCot;
        }

        public async Task<NewCar> CreateCar(NewCar newCar)
        {
            var res = await this.carCot.NewCars.AddAsync(newCar);
            await this.carCot.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<NewCar> GetByIdCar(long id)
        {
            return await this.carCot.NewCars.FirstOrDefaultAsync(a => a.NewCarId == id);
        }

        public async Task DeleteByIdCar(long id)
        {
            this.carCot.NewCars.Remove(this.carCot.NewCars.FirstOrDefault(a => a.NewCarId == id));
            this.carCot.SaveChangesAsync();
        }

        public async Task<IEnumerable<NewCar>> GetAll()
        {
            return await this.carCot.NewCars.ToListAsync();
        }

        public async Task<NewCar> UpdateByIdCar(long id, [FromBody] NewCar newCar)
        {

            var temp = this.carCot.NewCars.FirstOrDefault(a => a.NewCarId == id);

            temp.NcarStatus = newCar.NcarStatus;
            temp.NcarTransmission = newCar.NcarTransmission;
            temp.BookingStatus = newCar.BookingStatus;
            temp.NcarCost = newCar.NcarCost;
            temp.NcarInsuranceType = newCar.NcarInsuranceType;
            temp.NcarMileage = newCar.NcarMileage;
            temp.NcarName = newCar.NcarName;


            this.carCot.SaveChanges();
            return temp;
        }
    }
}
