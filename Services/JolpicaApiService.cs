using System.Net.Http;
using System.Threading.Tasks;

namespace FormulaOneDemo.Services;

public class JolpicaApiService
{
    private readonly HttpClient _httpClient;

    public JolpicaApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://api.jolpi.ca/"); // Jolpica API Base URL
    }

    // Function to fetch race data for a specific season and round
    public async Task<string> GetRaceAsync(int season, int round)
    {
        try
        {
            // Construct the API URL dynamically
            var url = $"ergast/f1/{season}/{round}/races/";
            var response = await _httpClient.GetAsync(url);

            // Ensure response is successful
            response.EnsureSuccessStatusCode();

            // Retrieve raw JSON response
            var rawJson = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Raw API Response: " + rawJson); // Log for debugging
            return rawJson;
        }
        catch (Exception ex)
        {
            // Log the error for debugging
            Console.WriteLine($"Error in GetRaceAsync: {ex.Message}");
            throw; // Rethrow for debugging
        }
    }

}
