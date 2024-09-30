using Negocio;
using RestSharp;
using System;

namespace Datos
{
    public class ConnecectionApi
    {
        RestClient client;
        List<string>? Categories;

        public ConnecectionApi(string url)
        {
            client = new RestClient(url);
        }

        public List<ApiProducts>? GetProducts()
        {
            var request = new RestRequest("products", Method.Get);
            List<ApiProducts>? products = client.Get<List<ApiProducts>>(request);
            return products;
        }
        public List<string>? GetCategories()
        {
            var request = new RestRequest("products/categories", Method.Get);
            Categories = client.Get<List<string>>(request);
            return Categories;
        }
        public List<ApiProducts>? PostProducts(List<ApiProducts> listProductsToUpdate, ApiProducts newProduct)
        {
            var request = new RestRequest("products", Method.Post);

            if (listProductsToUpdate == null)
            {
                listProductsToUpdate = new List<ApiProducts>();
            }

            listProductsToUpdate.Add(newProduct);

            return listProductsToUpdate;
        }
        public List<ApiProducts>? DeleteProducts(List<ApiProducts> listProductsToUpdate, List<int> listIds)
        {
            foreach (int productId in listIds)
            {
                var request = new RestRequest($"products/{productId}", Method.Delete);
                ApiProducts? response = client.Delete<ApiProducts>(request);
            }
            listProductsToUpdate.RemoveAll(item => listIds.Contains(item.Id));
            
            return listProductsToUpdate;
        }
        public List<ApiProducts>? PutProducts(List<ApiProducts> ListProductsToUpdate, ApiProducts productToEdit)
        {
            var request = new RestRequest($"products/{productToEdit}", Method.Put);

            //ApiProducts? response = client.Put<ApiProducts>(request);

            var product = ListProductsToUpdate.Where(item => item.Id == productToEdit.Id).First();

            ListProductsToUpdate.Remove(product);
            ListProductsToUpdate.Add(productToEdit);

            return ListProductsToUpdate;
        }
    }
}