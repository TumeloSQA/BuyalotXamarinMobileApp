using BuyalotXamarinMobileApp.Models;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyalotXamarinMobileApp.Services
{
   public class CategoryService
    {
        public async Task<List<ProductCategory>> GetCategoriesAsync()
        {

            RestClient<ProductCategory> restClient = new RestClient<ProductCategory>();

            var categoriesList = await restClient.GetAsync();

            return categoriesList;
        }

        public async Task PostCategoryAsync(ProductCategory productCategory)
        {

            RestClient<ProductCategory> restClient = new RestClient<ProductCategory>();

            var categoriesList = await restClient.PostAsync(productCategory);

        }


    }
}
