namespace CarDekho.Repository
{
    using CarDekho.Models;

    public interface IAdminRepo
    {
        public Task<IEnumerable<Buyer>> AdminGetAllBuyer();

        public Task AdminDeleteBuyerById(long id);

        public Task<IEnumerable<Seller>> AdminGetAllSeller();

        public Task AdminDeleteSellerById(long id);

        public Task<IEnumerable<Provider>> AdminGetAllProvider();

        public Task AdminDeleteProviderById(long id);

        public Task<IQueryable<Provider>> ProviderBuyerDetails();

        public Task<Provider> AdminUpdateProviderStatus(long id, Provider provider);

        public Task<NewCar> AdminUpdateNewCarById(long id, NewCar newCar);

        public Task<UsedCar> AdminUpdateUsedCarById(int id, UsedCar usedCar);


    }
}

