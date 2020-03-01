using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = args[0];
            var client = new HttpClient();
            HttpResponseMessage result = await client.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                string content = await result.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+(\\.[a-z]+)+", RegexOptions.IgnoreCase);

                var matches = regex.Matches(content);
                foreach (var match in matches)
                {
                    Console.WriteLine(match);
                }
            }
        }
    }
}
