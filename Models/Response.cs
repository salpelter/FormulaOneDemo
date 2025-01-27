namespace FormulaOneDemo.Models;

public class ApiResponse
{
    public required MRData MRData { get; set; }
}

public class MRData
{
    public required RaceTable RaceTable { get; set; }
}

public class RaceTable
{
    public required List<Race> Races { get; set; }
}