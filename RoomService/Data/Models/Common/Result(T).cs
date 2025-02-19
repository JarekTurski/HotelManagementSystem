using RoomService.Enums;

namespace RoomService.Data.Models.Common;

public readonly struct Result<T>
{
    private readonly T _data;
    private readonly ErrorType _errorType;

    internal Result(bool isSuccess, T data)
    {
        IsSuccess = isSuccess;
        _data = data;
        _errorType = default;
    }

    internal Result(bool isSuccess, ErrorType errorType)
    {
        IsSuccess = isSuccess;
        _data = default;
        _errorType = errorType;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

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

    public T Data
    {
        get
        {
            if(IsFailure)
            {
                throw new InvalidOperationException();
            }

            return _data;
        }
    }

    public static implicit operator Result<T>(T data)
    {
        return new Result<T>(isSuccess: true, data);
    }

    public static implicit operator Result(Result<T> result)
    {
        if(result.IsSuccess)
        {
            return Result.Success();
        }
        else
        {
            return Result.Failure(result.Error);
        }
    }
}
