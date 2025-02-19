using RoomService.Data.Models.Common;
using RoomService.Enums;

namespace RoomService.Extensions;

public static class ResultExtensions
{
    public static Envelope<T> ToEnvelope<T>(this Result<T> result)
    {
        if (result.IsSuccess)
        {
            return new Envelope<T>(result.Data);
        }
        else
        {
            var statusCode = result.GetStatusCode();
            var error = new Error(statusCode, result.Error.ToString());
            
            return new Envelope<T>(error);
        }
    }

    public static int GetStatusCode(this Result result)
    {
        if(result.IsSuccess)
        {
            return StatusCodes.Status200OK;
        }

        return result.Error switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status400BadRequest,
        };
    }

    public static int GetStatusCode<T>(this Result<T> result)
    {
        return ((Result)result).GetStatusCode();
    }
}
