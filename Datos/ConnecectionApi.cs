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
    }
}