using System.Data;

namespace Program;

class Cars
{
    public string name { get; set; }
    public string url { get; set; }
}

class Response
{
    public Cars[] results { get; set; }
}

class Program
{
    public static void Main()
    {
        Console.WriteLine("Hi!");

        var task = GetUsers();
        task.Wait();

        var cars = task.Result;

        Console.ReadKey();
    }

    public static async Task<Cars[]> GetUsers()
    {
        try
        {
            string baseUrl = "https://cars.ua";

            using HttpClient client = new HttpClient();
            using HttpResponseMessage res = await client.GetAsync(baseUrl);
            using HttpContent content = res.Content;

            var data = await content.ReadAsStringAsync();

            if (response == null)
            {
                throw new NoNullAllowedException();
            }

            return response.results;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            return new Cars[] { };
        }
    }
}