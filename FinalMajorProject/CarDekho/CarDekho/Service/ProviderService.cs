namespace CarDekho.Service
{
    using CarDekho.Models;
    using CarDekho.Repository;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class ProviderService : IProviderRepo
    {

        private readonly CarDekhoDBContext carCot;

        public ProviderService(CarDekhoDBContext carCot)
        {
            this.carCot = carCot;
        }

        public async Task<Provider> Create(Provider provider)
        {
            var res = await carCot.Providers.AddAsync(provider);
            await carCot.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Provider> GetById(long id)
        {
            return await carCot.Providers.FirstOrDefaultAsync(a => a.ProviderId == id);
        }

        public async Task DeleteById(long id)
        {
            this.carCot.Providers.Remove(this.carCot.Providers.FirstOrDefault(a => a.ProviderId == id));
            this.carCot.SaveChangesAsync();
        }

        public async Task <Provider> UpdateById(long id, [FromBody] Provider provider)
        {
            var temp = carCot.Providers.FirstOrDefault(a => a.ProviderId == id);
           
                temp.ProviderName = provider.ProviderName;
                temp.ProviderContact = provider.ProviderContact;
                temp.ProviderEmail = provider.ProviderEmail;
                temp.ProviderPassword = provider.ProviderPassword;
                temp.ProviderCity = provider.ProviderCity;
                temp.ProviderAddress = provider.ProviderAddress;

                this.carCot.SaveChanges();
                return temp;
     
        }

        public async Task<IEnumerable<Provider>> GetAll()
        {
            return await this.carCot.Providers.ToListAsync();
        }

        public async Task<IEnumerable<Provider>> GetAllProvider()
        {

            var getProvider = await this.carCot.Providers
                    .Select(
                 s => new Provider
                 {
                     ProviderName = s.ProviderName,
                     ProviderEmail = s.ProviderEmail,
                     ProviderCity = s.ProviderCity,
                     ProviderContact = s.ProviderContact,
                     ProviderAddress = s.ProviderAddress,

                 }).ToListAsync();
            return getProvider;

        }

        public async Task<Provider> Login(string email, string password)
        {
            return await this.carCot.Providers.FirstOrDefaultAsync(a => a.ProviderEmail.ToLower().Equals(email.ToLower()) && a.ProviderPassword.Equals(password));
        }


    }
}
