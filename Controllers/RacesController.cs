using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using FormulaOneDemo.Services;

namespace FormulaOneDemo.Controllers;

public class RacesController : Controller
{
    private readonly JolpicaApiService _jolpicaApiService;

    // Constructor to inject the JolpicaApiService
    public RacesController(JolpicaApiService jolpicaApiService)
    {
        _jolpicaApiService = jolpicaApiService;
    }

    // API endpoint to get race data for a specific season and round
    [HttpGet]
    [Route("races/{season}/{round}")]
    public async Task<IActionResult> GetRaceAsync(int season, int round)
    {
        try
        {
            // Call the API service to get the race details
            var jsonResponse = await _jolpicaApiService.GetRaceAsync(season, round);

            if (string.IsNullOrEmpty(jsonResponse))
            {
                return Json(new { Error = "No data found for the given season and round." });
            }

            // Parse the JSON response for validation and debugging
            var parsedJson = JToken.Parse(jsonResponse);
            Console.WriteLine("Parsed JSON: " + parsedJson);

            return Content(jsonResponse, "application/json"); // Return the raw JSON
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetRaceAsync: {ex.Message}");
            return StatusCode(500, new { Error = "Internal Server Error", Details = ex.Message });
        }
    }


}
