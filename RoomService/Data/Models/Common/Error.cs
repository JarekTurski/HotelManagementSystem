using RoomService.Enums;

namespace RoomService.Data.Models.Common;

public class Error
{
    public Error(ErrorType errorType, string message)
    {
        Code = errorType.ToString();
        Message = message;  
    }

    public Error(int code, string message)
    {
        Code = code.ToString();
        Message = message;
    }

    public string Code { get; }
    public string Message { get; }
}
