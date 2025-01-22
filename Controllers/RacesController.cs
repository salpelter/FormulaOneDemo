using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using FormulaOneDemo.Services;
using FormulaOneDemo.Models;
using Newtonsoft.Json;

namespace FormulaOneDemo.Controllers;

public class RacesController : Controller
{
    private readonly JolpicaApiService _jolpicaApiService;

    public RacesController(JolpicaApiService jolpicaApiService)
    {
        _jolpicaApiService = jolpicaApiService;
    }

    // Show the form
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    // Handle form submission
    [HttpGet]
    [Route("races")]
    public async Task<IActionResult> GetRaceAsync([FromQuery] int season, [FromQuery] int round)
    {
        try
        {
            var races = await _jolpicaApiService.GetRaceAsync(season, round);
            return View("Index", races);
        }
        catch (HttpRequestException ex)
        {
            // Handle API-specific errors
            ModelState.AddModelError("", $"API request failed: {ex.Message}");
            return View("Index", new List<Race>());
        }
        catch (JsonException ex)
        {
            // Handle JSON parsing errors
            ModelState.AddModelError("", $"Failed to parse race data: {ex.Message}");
            return View("Index", new List<Race>());
        }
        catch (Exception ex)
        {
            // Handle unexpected errors
            ModelState.AddModelError("", $"An unexpected error occurred: {ex.Message}");
            return View("Index", new List<Race>());
        }
    }
}
