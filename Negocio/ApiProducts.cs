namespace Negocio
{
    public class ApiProducts
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }


        public List<ApiProducts> Products { get; set; }

        public List<string> GetCategory()
        {
            List<string> categories = new List<string>();
            foreach (var product in Products)
            {
                categories.Add(product.Category);
            }
            
            return categories.Distinct().ToList(); 
        }
    }
}