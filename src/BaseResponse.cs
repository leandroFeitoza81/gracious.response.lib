using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace gracious.response.lib;

public class BaseResponse
{
    private static ActionResult CustomResponse(
        HttpStatusCode statusCode,
        bool success,
        string? message,
        object? data = null
    )
    {
        var objectResponse = new ObjectResponse()
        {
            Success = success,
            Message = message,
            Data = data
        };
        
        return new ObjectResult(objectResponse)
        {
            StatusCode = (int)statusCode
        };
    }
    
    public static ActionResult ResponseOk(string? message, object? data = null)
    {
        return CustomResponse(HttpStatusCode.OK, true, message, data);
    }

    public static ActionResult ResponseServerError(Exception ex)
    {
        return CustomResponse(HttpStatusCode.InternalServerError, false, ex.Message);
    }

    public static ActionResult ResponseBadRequest(string message)
    {
        return CustomResponse(HttpStatusCode.BadRequest, false, message);
    }

    public static ActionResult ResponseNotFound(string message)
    {
        return CustomResponse(HttpStatusCode.NotFound, false, message);
    }
}