using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace gracious.response.lib.tests;

public class BaseResponseTests
{
    [Fact]
    public void ResponseOk_ShouldReturnOkResult()
    {
        // Arrange
        const string message = "Success";
        object data = new { id = 1, name = "Test" };

        // Act
        var result = BaseResponse.ResponseOk(message, data) as ObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        Assert.True((result.Value as ObjectResponse)?.Success);
        Assert.Equal(message, (result.Value as ObjectResponse)?.Message);
        Assert.Equal(data, (result.Value as ObjectResponse)?.Data);
    }
    
    [Fact]
    public void ResponseServerError_ShouldReturnInternalServerErrorResult()
    {
        // Arrange
        var exception = new Exception("Server error");

        // Act
        var result = BaseResponse.ResponseServerError(exception) as ObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.InternalServerError, result.StatusCode);
        Assert.False((result.Value as ObjectResponse)?.Success);
        Assert.Equal(exception.Message, (result.Value as ObjectResponse)?.Message);
    }

    [Fact]
    public void ResponseBadRequest_ShouldReturnBadRequestResult()
    {
        // Arrange
        const string message = "Bad request";

        // Act
        var result = BaseResponse.ResponseBadRequest(message) as ObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        Assert.False((result.Value as ObjectResponse)?.Success);
        Assert.Equal(message, (result.Value as ObjectResponse)?.Message);
    }

    [Fact]
    public void ResponseNotFound_ShouldReturnNotFoundResult()
    {
        // Arrange
        const string message = "Not found";

        // Act
        var result = BaseResponse.ResponseNotFound(message) as ObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
        Assert.False((result.Value as ObjectResponse)?.Success);
        Assert.Equal(message, (result.Value as ObjectResponse)?.Message);
    }
}