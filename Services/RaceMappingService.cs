using Newtonsoft.Json;
using FormulaOneDemo.Models;

namespace FormulaOneDemo.Services;

public class RaceMappingService
{
    public List<Race> MapJsonToRaces(string apiResponse)
    {
        var jsonResponse = JsonConvert.DeserializeObject<ApiResponse>(apiResponse);
        return jsonResponse?.MRData.RaceTable.Races ?? [];
    }
}