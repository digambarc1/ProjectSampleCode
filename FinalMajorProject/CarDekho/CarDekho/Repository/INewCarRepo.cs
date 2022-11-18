namespace CarDekho.Repository
{
    using CarDekho.Models;

    public interface INewCarRepo
    {
        public Task<NewCar> CreateCar(NewCar newCar);

        public Task<NewCar> GetByIdCar(long id);

        public Task DeleteByIdCar(long id);

        public Task<NewCar> UpdateByIdCar(long id, NewCar newCar);

        public Task<IEnumerable<NewCar>> GetAll();

    }
}
