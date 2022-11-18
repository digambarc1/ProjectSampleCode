namespace CarDekho.Service
{
    using System.Collections;
    using System.Net;
    /*using System.Web.Mvc;*/
    using CarDekho.Models;
    using CarDekho.Repository;
   /* using Microsoft.AspNetCore.JsonPatch;*/
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Data.SqlClient;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class BuyerService : IBuyerRepo
    {
        private readonly CarDekhoDBContext car;

        public BuyerService(CarDekhoDBContext car)
        {
            this.car = car;
        }

        public async Task<Buyer> Create(Buyer buyer)
        {
            var res = await this.car.Buyers.AddAsync(buyer);
            await this.car.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Buyer> GetById(long id)
        {
            return await this.car.Buyers.FirstOrDefaultAsync(a => a.BuyerId == id);
        }


        public async Task DeleteById(long id)
        {
           var res= this.car.Buyers.FirstOrDefault(a => a.BuyerId == id);
            if(res != null)
            {
                this.car.Buyers.Remove(res);
                await car.SaveChangesAsync();
            }
        }

        public async Task DeleteByEmail(string email)
        {
           var res= this.car.Buyers.FirstOrDefault(a => a.BuyerEmail == email);
            if (res != null)
            {
                this.car.Buyers.Remove(res);
                await car.SaveChangesAsync();
            }
        }

        public async Task<Buyer> GetByEmail(string email)
        {


            return await this.car.Buyers.FirstOrDefaultAsync(a => a.BuyerEmail == email);
        }

        
        public Buyer Login(string email, string password)
        {
            return this.car.Buyers.FirstOrDefault(a => a.BuyerEmail.ToLower().Equals(email.ToLower()) && a.BuyerPassword.Equals(password));
        }

        // For Admin

        public async Task<IEnumerable<Buyer>> GetAll()
        {

            var getBuyer = await this.car.Buyers
                    .Select(
                 s => new Buyer
                 {
                     BuyerName = s.BuyerName,
                     BuyerEmail = s.BuyerEmail,
                 }).ToListAsync();
            return getBuyer;

        }


        //        For Admin

        //            var buyeradmindet = Buyer.

        //        public async Task<IEnumerable<Buyer>> GetAll()
        //        {  var buyeradmindet =Buyer.select(b => new {
        //buyer.BuyerName,
        //buyer.BuyerMobile,
        //buyer.BuyerEmail,
        //buyer.BuyerAddress


        //        }

        //        var buyeradmindet =
        //Buyer.select(b => new {
        //    buyer.BuyerName,
        //    buyer.BuyerMobile,
        //    buyer.BuyerEmail,
        //    buyer.BuyerAddress,
        //})

        //public async Task UpdateById(int id, JsonPatchDocument<Buyer> buyer)
        //{
        //    /* var temp = this.car.Buyers.FirstOrDefault(a => a.BuyerId == id);*/
        //    var temp = this.car.Buyers.FirstOrDefault(a => a.BuyerId==id);

        //    if (temp != null)
        //    {
        //        buyer.ApplyTo(temp);
        //       await this.car.SaveChangesAsync();
        //    }
        //}

        public async Task<Buyer> UpdateById(int id, [FromBody] Buyer buyer)
        {
            var temp = this.car.Buyers.FirstOrDefault(a => a.BuyerId == id);
            if(temp!= null)
            {
                temp.BuyerName = buyer.BuyerName;
                temp.BuyerMobile = buyer.BuyerMobile;
                temp.BuyerEmail = buyer.BuyerEmail;
                temp.BuyerPassword = buyer.BuyerPassword;
                temp.BuyerCity = buyer.BuyerCity;
                temp.BuyerAddress = buyer.BuyerAddress;

                this.car.SaveChanges();
                return temp;
            }
            
            
                return null;
            
        }

        //public bool CheckUser(string username, string password)
        //{
        //    var u = car.Buyers.FirstOrDefault(a => a.BuyerName == username);
        //    var p = car.Buyers.FirstOrDefault(a => a.BuyerPassword == password);
        //    return username.Equals(u) && password.Equals(p);

    }
   
}
