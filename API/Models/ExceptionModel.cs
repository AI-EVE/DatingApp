namespace API.Models;

public class ExceptionModel
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string Details { get; set; }
    public ExceptionModel(int statusCode, string message, string details)
    {
        StatusCode = statusCode;
        Message = message;
        Details = details;
    }
    
}