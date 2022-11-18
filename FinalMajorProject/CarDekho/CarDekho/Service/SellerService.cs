namespace CarDekho.Service
{
    using CarDekho.Models;
    using CarDekho.Repository;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class SellerService : ISellerRepo
    {
        private readonly CarDekhoDBContext carCot;

        public SellerService(CarDekhoDBContext carCot)
        {
            this.carCot = carCot;
        }

        public async Task<Seller> Create(Seller seller)
        {
            var res = await this.carCot.Sellers.AddAsync(seller);
            await this.carCot.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Seller> GetById(long id)
        {
            return await this.carCot.Sellers.FirstOrDefaultAsync(a => a.SellerId == id);
        }

        public async Task DeleteById(long id)
        {
            this.carCot.Sellers.Remove(this.carCot.Sellers.FirstOrDefault(a => a.SellerId == id));
            this.carCot.SaveChangesAsync();
        }

        public async Task<Seller> UpdateById(long id, [FromBody] Seller seller)
        {
            var temp = this.carCot.Sellers.FirstOrDefault(a => a.SellerId == id);

            temp.SellerName = seller.SellerName;
            temp.SellerMobile = seller.SellerMobile;
            temp.SellerEmail = seller.SellerEmail;
            temp.SellerPassword = seller.SellerPassword;
            temp.SellerCity = seller.SellerCity;
            temp.SellerAddress = seller.SellerAddress;

            this.carCot.SaveChanges();
            return temp;
        }

        public  Seller Login(string email, string password)
        {
            return  this.carCot.Sellers.FirstOrDefault(a => a.SellerEmail.ToLower().Equals(email.ToLower()) && a.SellerPassword.Equals(password));
        }


        // FOR ADMIN
        public async Task<IEnumerable<Seller>> GetAll()
        {
            return await this.carCot.Sellers.ToListAsync();
        }



        public async Task<IEnumerable<Seller>> GetAllSeller()
        {

            var getSeller = await this.carCot.Sellers
                    .Select(
                 s => new Seller
                 {
                     SellerName = s.SellerName,
                     SellerEmail = s.SellerEmail,
                     SellerCity = s.SellerCity,
                     SellerAddress = s.SellerAddress,
                 

                 }).ToListAsync();
            return getSeller;

        }
    }
}
