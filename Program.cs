using Newtonsoft.Json;

namespace StudentExerciseCON_API_Products
{
    internal class Program
    {
        //static void Main(string[] args)
        static async Task Main(string[] args)
        {
            string url = "https://dummyjson.com/products";

            HttpClient httpClient = new HttpClient();

            try
            {
                var httpResponseMessage = await httpClient.GetAsync(url);

                string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

                Console.WriteLine(jsonResponse + "\n");

                var products = JsonConvert.DeserializeObject<Root>(jsonResponse);

                foreach (var product in products.products)
                {
                    Console.WriteLine($"\nID: {product.id} \nProduct: {product.title}");

                    for (int i = 0; i < product.images.Count; i++)
                    {
                        Console.WriteLine(
                            string.Format("Picture: {0}",
                            product.images[i].ToString()
                            ));
                    }
                }
                Console.ReadLine();
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                httpClient.Dispose();
            }
        }
    }
}
 //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class product
{
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public int price { get; set; }
    public double discountPercentage { get; set; }
    public double rating { get; set; }
    public int stock {  get; set; }
    public string brand { get; set; }
    public string category { get; set; }
    public string thumbnail { get; set; }
    public List<string> images { get; set; }
}
public class Root
{
    public List<product> products { get; set; }
    public int total { get; set; }
}


