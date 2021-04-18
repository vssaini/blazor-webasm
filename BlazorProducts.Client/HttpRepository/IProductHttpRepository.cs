using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorProducts.Client.HttpRepository
{
    public interface IProductHttpRepository
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(Guid id);
    }
}
