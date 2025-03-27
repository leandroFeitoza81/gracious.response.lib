namespace gracious.response.lib;

public class ObjectResponse
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }
}