using Negocio;
using RestSharp;

namespace Datos
{
    public class ConnecectionApi
    {
        public static List<ApiProducts> GetProducts(string url)
        {            
            var cliente = new RestClient(url);
            var request = new RestRequest("products", Method.Get);
            List<ApiProducts> products = cliente.Get<List<ApiProducts>>(request);
            return products;
        }
    }
}