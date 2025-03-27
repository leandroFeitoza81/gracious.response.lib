# Gracious Response Library

**Gracious Response Library** provides a simple and elegant way to standardize HTTP responses in your ASP.NET applications. It includes methods to generate consistent response objects for different HTTP status codes.

## Features

- **Easy Integration**: Create standardized HTTP responses with minimal effort.
- **Flexibility**: Supports custom messages and data payloads.
- **Predefined Methods**:
  - `ResponseOk`: For 200 OK responses.
  - `ResponseBadRequest`: For 400 Bad Request responses.
  - `ResponseNotFound`: For 404 Not Found responses.
  - `ResponseServerError`: For 500 Internal Server Error responses.

## Installation

Install the package via NuGet:

```bash
dotnet add package gracious.response.lib --version <Version>
```

Alternatively, use the NuGet Package Manager:

```bash
PM> Install-Package gracious.response.lib -Version <Version>
```

## Usage

Here's an example of how to use the library:

```csharp
using gracious.response.lib;
using Microsoft.AspNetCore.Mvc;

public class SampleController : ControllerBase
{
    [HttpGet("success")]
    public ActionResult GetSuccessResponse()
    {
        return BaseResponse.ResponseOk("Request successful", new { id = 1, name = "Sample Data" });
    }

    [HttpGet("error")]
    public ActionResult GetErrorResponse()
    {
        return BaseResponse.ResponseServerError(new Exception("Something went wrong"));
    }
}
```

## Requirements

- .NET Core 6.0 or later
- ASP.NET Core

## Contributing

Contributions are welcome! Please open an issue or submit a pull request on the GitHub repository.

## License

This project is licensed under the **MIT License**.

---
