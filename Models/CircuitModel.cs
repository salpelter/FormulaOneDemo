namespace FormulaOneDemo.Models;

public class Circuit
{
    public required string CircuitId { get; set; }
    public required string Url { get; set; }
    public required string CircuitName { get; set; }
    public required Location CircuitLocation { get; set; }
}
