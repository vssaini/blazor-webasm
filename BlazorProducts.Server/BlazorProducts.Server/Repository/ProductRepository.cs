﻿using BlazorProducts.Server.Context;
using BlazorProducts.Server.Paging;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BlazorProducts.Server.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Product>> GetProducts(ProductParameters productParameters)
        {
            var products = await _context.Products.ToListAsync();

            return PagedList<Product>.ToPagedList(products, productParameters.PageNumber, productParameters.PageSize);            
        }

        public async Task<Product> GetProduct(Guid id) =>
            await _context.Products.FirstOrDefaultAsync(p => p.Id.Equals(id));
    }
}
