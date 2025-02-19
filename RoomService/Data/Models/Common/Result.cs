using RoomService.Enums;

namespace RoomService.Data.Models.Common;

public readonly struct Result
{
    private readonly ErrorType _errorType;

    private Result(bool isSuccess)
    {
        IsSuccess = isSuccess;
        _errorType = default;
    }

    private Result(bool isSuccess, ErrorType errorType)
    {
        IsSuccess = isSuccess;
        _errorType = errorType;
    }
    public ErrorType Error
    {
        get
        {
            if (IsSuccess)
            {
                throw new InvalidOperationException();
            }

            return _errorType;
        }
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public static Result Success()
    {
        return new Result(isSuccess: true);
    }

    public static Result<T> Success<T>(T data)
    {
        return new Result<T>(isSuccess: true, data);
    }
    public static Result Failure(ErrorType errorType)
    {
        return new Result(isSuccess: false, errorType);
    }
    public static Result<T> Failure<T>(ErrorType errorType)
    {
        return new Result<T>(isSuccess: false, errorType);
    }

    public static explicit operator Result(Result<object> v)
    {
        throw new NotImplementedException();
    }
}
