using BlazorProducts.Client.HttpRepository;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorProducts.Client.Pages
{
    public partial class Products
    {
        public List<Product> ProductList { get; set; } = new List<Product>();
        public MetaData MetaData { get; set; } = new MetaData();

        private ProductParameters _productParameters = new ProductParameters();

        [Inject]
        public IProductHttpRepository ProductRepo { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var pagingResponse = await ProductRepo.GetProducts(_productParameters);

            ProductList = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;

            //foreach (var product in ProductList)
            //{
            //	Console.WriteLine(product.Name);
            //}
        }
    }
}