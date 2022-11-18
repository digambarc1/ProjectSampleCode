namespace CarDekho.Repository
{
    using CarDekho.Models;

    public interface ISellerRepo
    {
        public Task<Seller> Create(Seller seller);

        public Task<Seller> GetById(long id);

        public Task DeleteById(long id);

        public Task<Seller> UpdateById(long id, Seller seller);

        public Seller Login(string email, string password);

        //for admin
        public Task<IEnumerable<Seller>> GetAllSeller();

    }
}
