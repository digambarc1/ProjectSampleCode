namespace CarDekho.Service
{
    using System.Web.Http;
    using CarDekho.Models;
    using CarDekho.Repository;
    using Microsoft.EntityFrameworkCore;

    public class AdminService : IAdminRepo
    {

        private readonly CarDekhoDBContext car;

        public AdminService(CarDekhoDBContext car)
        {
            this.car = car;
        }

        public async Task<IEnumerable<Buyer>> AdminGetAllBuyer()
        {
            var getBuyer = await this.car.Buyers
                        .Select(
                     s => new Buyer
                     {
                         BuyerId = s.BuyerId,
                         BuyerName = s.BuyerName,
                         BuyerEmail = s.BuyerEmail,
                         BuyerMobile = s.BuyerMobile,
                         BuyerAddress = s.BuyerAddress,
                         BuyerCity = s.BuyerCity
                     }).ToListAsync();
            return getBuyer;
        }

        public async Task AdminDeleteBuyerById(long id)
        {
            var res = this.car.Buyers.FirstOrDefault(a => a.BuyerId == id);
            if (res != null)
            {
                this.car.Buyers.Remove(res);
                await this.car.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Seller>> AdminGetAllSeller()
        {

            var getSeller = await this.car.Sellers
                    .Select(
                 s => new Seller
                 {
                     SellerId = s.SellerId,
                     SellerName = s.SellerName,
                     SellerEmail = s.SellerEmail,
                     SellerCity = s.SellerCity,
                     SellerAddress = s.SellerAddress

                 }).ToListAsync();
            return getSeller;

        }

        public async Task AdminDeleteSellerById(long id)
        {
            this.car.Sellers.Remove(this.car.Sellers.FirstOrDefault(a => a.SellerId == id));
            this.car.SaveChangesAsync();
        }

        public async Task<IEnumerable<Provider>> AdminGetAllProvider()
        {
            var getSeller = await this.car.Providers
                   .Select(
                p => new Provider
                {
                    ProviderId = p.ProviderId,
                    ProviderName = p.ProviderName,
                    ProviderEmail = p.ProviderEmail,
                    ProviderCity = p.ProviderCity,
                    ProviderAddress = p.ProviderAddress,


                }).ToListAsync();
            return getSeller;
        }

        public async Task AdminDeleteProviderById(long id)
        {
            var res = this.car.Providers.FirstOrDefault(a => a.ProviderId == id);
            if (res != null)
            {
                this.car.Providers.Remove(res);
                await this.car.SaveChangesAsync();
            }
        }

        public async Task<IQueryable<Provider>> ProviderBuyerDetails()
        {

            var query = (from pd in car.Providers
                         join od in car.ProviderDetailsforBuyers on pd.ProviderId equals od.ProviderId
                         into t
                         from rt in t.DefaultIfEmpty()
                         orderby pd.ProviderId
                         select new
                         {

                             BuyerId = rt.BuyerId,
                             pd.ProviderName,
                             pd.ProviderContact,
                             pd.ProviderEmail,
                             pd.ProviderAddress,


                         }).ToList();
            return (IQueryable<Provider>)query;
        }

        public async Task<Provider> AdminUpdateProviderStatus(long id, [FromBody] Provider provider)
        {
            var temp = car.Providers.FirstOrDefault(a => a.ProviderId == id);
            temp.ProviderName = provider.ProviderName;
            temp.ProviderContact = provider.ProviderContact;
            temp.ProviderEmail = provider.ProviderEmail;
            temp.ProviderPassword = provider.ProviderPassword;
            temp.ProviderCity = provider.ProviderCity;
            temp.ProviderAddress = provider.ProviderAddress;
            temp.ProviderRegStatus = provider.ProviderRegStatus;

            this.car.SaveChanges();
            return temp;
      }

        public async Task<NewCar> AdminUpdateNewCarById(long id, [FromBody] NewCar newCar)
        {

            var temp = this.car.NewCars.FirstOrDefault(a => a.NewCarId == id);

            temp.NcarStatus = newCar.NcarStatus;
            temp.NcarTransmission = newCar.NcarTransmission;
            temp.BookingStatus = newCar.BookingStatus;
            temp.NcarCost = newCar.NcarCost;
            temp.NcarInsuranceType = newCar.NcarInsuranceType;
            temp.NcarMileage = newCar.NcarMileage;
            temp.NcarName = newCar.NcarName;
            this.car.SaveChanges();
            return temp;
        }

        public async Task<UsedCar> AdminUpdateUsedCarById(int id, [FromBody] UsedCar usedCar)
        {
            var temp = car.UsedCars.FirstOrDefault(a => a.UsedCarId == id);

            temp.UcarCost = usedCar.UcarCost;
            temp.UcarDriven = usedCar.UcarDriven;
            temp.UcarInsuranceType = usedCar.UcarInsuranceType;
            temp.UcarMileage = usedCar.UcarMileage;
            temp.UcarName = usedCar.UcarName;
            temp.UcarNoOfPrevOwner = usedCar.UcarNoOfPrevOwner;
            temp.UcarRto = usedCar.UcarRto;
            temp.UcarStatus = usedCar.UcarStatus;
            temp.BookingStatus = usedCar.BookingStatus;

            await this.car.SaveChangesAsync();

            return temp;
        }
    }
}
