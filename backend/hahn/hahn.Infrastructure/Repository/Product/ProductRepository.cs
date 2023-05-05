﻿using hahn.Domain.Entities;
using hahn.Domain.Entities.BuyerAggregate;
using hahn.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace hahn.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Product> AddAsync(Product entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(params Expression<Func<Product, object>>[] includes)
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid? id, params Expression<Func<Product, object>>[] includes)
        {

            var search = _db.Products.Where(x => x.Id == id);

            return await search.FirstOrDefaultAsync();
        }

        public async Task<bool> GetManagerById(string id)
        {
            return await _db.Manager.Where(x => x.Id == id && x.UserType == 0).AnyAsync();
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<string> DeleteAsync(Product entity)
        {
            try
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
                return "Success!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
