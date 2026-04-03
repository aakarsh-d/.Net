namespace Shared;

public class InputMessage
{
    public string CorrelationId { get; set; }
    public int Value { get; set; }
}

public class ResultMessage
{
    public string CorrelationId { get; set; }
    public string Type { get; set; } // "square" or "cube"
    public int Value { get; set; }
}