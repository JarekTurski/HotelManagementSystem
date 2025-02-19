using Microsoft.AspNetCore.Mvc;
using RoomService.Data.Models.Common;
using RoomService.Extensions;

namespace RoomService.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    public BaseController()
    {
    }

    public IActionResult BuildEnvelope<T>(Result<T> result)
    {
        var envelope = result.ToEnvelope();
        var statusCode = result.GetStatusCode();

        return StatusCode(statusCode, envelope);
    }
}
