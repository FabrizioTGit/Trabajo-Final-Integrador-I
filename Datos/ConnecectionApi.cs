using Negocio;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

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

        public string GetProducts(List<ApiProducts> listProductsToUpdate)
        {
            var request = new RestRequest("products", Method.Get);

            var response = client.Get(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var products = JsonConvert.DeserializeObject<List<ApiProducts>>(response.Content);

                listProductsToUpdate.Clear();
                listProductsToUpdate.AddRange(products);
                return "Productos cargados correctamente";
            }
            else
            {
                return "Error al obtener los productos";
            }
        }

        public string GetCategories(List<string> listCategoriesToUpdate)
        {
            var request = new RestRequest("products/categories", Method.Get);

            var response = client.Get(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var categories = JsonConvert.DeserializeObject<List<string>>(response.Content);

                listCategoriesToUpdate.Clear();
                listCategoriesToUpdate.AddRange(categories);
                return "Categorías obtenidas correctamente";
            }
            else
            {
                return "Error al obtener las categorías";
            }
        }
        public string PostProducts(List<ApiProducts> listProductsToUpdate, ApiProducts newProduct)
        {
            var request = new RestRequest("products", Method.Post);

            request.AddJsonBody(newProduct);

            var response = client.Post(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                listProductsToUpdate.Add(newProduct);
                return "Producto agregado correctamente";
            }
            else
            {
                return "No se pudo agregar el producto";
            }
        }

        public string DeleteProducts(List<ApiProducts> listProductsToUpdate, List<int> listIds)
        {
            foreach (int productId in listIds)
            {
                var request = new RestRequest($"products/{productId}", Method.Delete);

                var response = client.Delete(request); 

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    listProductsToUpdate.RemoveAll(item => listIds.Contains(item.Id));

                    return "Productos eliminados correctamente.";
                }
            }            
            return "Error al eliminar el producto";
        }
        public string PutProducts(List<ApiProducts> ListProductsToUpdate, ApiProducts productToEdit)
        {
            var request = new RestRequest($"products/{productToEdit.Id}", Method.Put);

            request.AddJsonBody(productToEdit);

            var response = client.Put(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var product = ListProductsToUpdate.Where(item => item.Id == productToEdit.Id).First();

                product.Title = productToEdit.Title;
                product.Description = productToEdit.Description;
                product.Category = productToEdit.Category;
                product.Price = productToEdit.Price;

                return "Producto actualizado correctamente";
            }
            return "No se pudo actualizar";
        }
    }
}