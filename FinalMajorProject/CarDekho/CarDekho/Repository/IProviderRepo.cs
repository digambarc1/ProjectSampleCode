namespace CarDekho.Repository
{
    using CarDekho.Models;

    public interface IProviderRepo
    {

        public Task<Provider> Create(Provider provider);

        public Task<Provider> GetById(long id);

        public Task DeleteById(long id);

        public Task<Provider> UpdateById(long id, Provider provider);
        public Task<Provider> Login(string email, string password);
        //for admin

        public Task<IEnumerable<Provider>> GetAllProvider();
    }
}
