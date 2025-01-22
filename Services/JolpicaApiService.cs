using FormulaOneDemo.Models;
using Newtonsoft.Json;

namespace FormulaOneDemo.Services;

public class JolpicaApiService
{
    private readonly HttpClient _httpClient;
    private readonly RaceMappingService _mappingService;

    public JolpicaApiService(HttpClient httpClient, RaceMappingService mappingService)
    {
        _httpClient = httpClient;
        _mappingService = mappingService;
    }

    // Function to fetch race data for a specific season and round
    public async Task<List<Race>> GetRaceAsync(int season, int round)
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
            return _mappingService.MapJsonToRaces(rawJson);
        }
        catch (HttpRequestException ex)
        {
            throw new HttpRequestException($"Failed to fetch race data: {ex.Message}");
        }
        catch (JsonException ex)
        {
            // Specific exception for JSON parsing errors
            throw new InvalidOperationException($"Failed to process race data: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error processing race data: {ex.Message}");
        }
    }

}
