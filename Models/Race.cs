namespace FormulaOneDemo.Models;

public class Race
{
    public required string Season { get; set; }
    public required string Round { get; set; }
    public required string Url { get; set; }
    public required string RaceName { get; set; }
    public required Circuit RaceCircuit { get; set; }
    public required string Date { get; set; }
}

