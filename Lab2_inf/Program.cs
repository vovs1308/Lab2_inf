using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // API URL та ключі
        string apiUrl = "https://hotels-com6.p.rapidapi.com/hotels/reviews-list?propertyId=2621_892034";
        string apiHostHeader = "hotels-com6.p.rapidapi.com";
        string apiKeyHeader = "cb442e3762msh74d42c2202a38ebp170666jsn0d5a71ad58a5";

        Console.WriteLine("Sending request to API...");

        // Виконання запиту
        string response = await SendApiRequest(apiUrl, apiHostHeader, apiKeyHeader);

        // Виведення результату
        if (!string.IsNullOrEmpty(response))
        {
            Console.WriteLine("Response received:");
            Console.WriteLine(response);
        }
        else
        {
            Console.WriteLine("Failed to fetch the response or the response is empty.");
        }
    }

    static async Task<string> SendApiRequest(string url, string hostHeader, string keyHeader)
    {
        using (HttpClient client = new HttpClient())
        {
            // Додаємо заголовки
            client.DefaultRequestHeaders.Add("x-rapidapi-host", hostHeader);
            client.DefaultRequestHeaders.Add("x-rapidapi-key", keyHeader);

            try
            {
                // Виконуємо запит
                HttpResponseMessage response = await client.GetAsync(url);

                // Якщо успішний запит, повертаємо тіло відповіді
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Console.WriteLine($"Error: HTTP {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Обробка винятків
                Console.WriteLine($"Exception occurred: {ex.Message}");
            }
        }

        return string.Empty; // У разі помилки повертаємо порожній рядок
    }
}
