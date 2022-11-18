// <copyright file="IBuyerRepo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarDekho.Repository
{
    using CarDekho.Models;
    using Microsoft.AspNetCore.JsonPatch;

    public interface IBuyerRepo
    {
        public Task<Buyer> Create(Buyer buyer);

        public Task<Buyer> GetById(long id);

        public Task DeleteById(long id);

        public Task<Buyer> UpdateById(int id, Buyer buyer);

        public Task<Buyer> GetByEmail(string email);

        public Buyer Login(string email, string password);

        // For Admin
        public Task<IEnumerable<Buyer>> GetAll();

        public Task DeleteByEmail(string email);

        /* bool CheckUser(string username, string password);*/
    }
}
