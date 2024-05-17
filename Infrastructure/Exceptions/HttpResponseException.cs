using System.Net;

namespace Infrastructure.Exceptions;

public class HttpObjectResult
{
    public HttpStatusCode Status { get; set; }

    public string Message { get; set; }

    public string Details { get; set; }
}

public class HttpResponseException : Exception
{
    public HttpResponseException(string message, HttpStatusCode status, string details = null)
    {
        Value = new HttpObjectResult
        {
            Details = details,
            Message = message,
            Status = status
        };
    }

    public HttpObjectResult Value { get; }
}