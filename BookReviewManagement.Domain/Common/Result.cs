namespace BookReviewManagement.Domain.Common;

public class Result
{
    public string Message { get; set; } = null!;
    public bool IsSuccess { get; set; }

    protected Result()
    {
    }
    
    public static Result Success() => 
        new()
        {
            IsSuccess = true
        };

    public static Result Error(string message) =>
        new()
        {
            Message = message,
            IsSuccess = false
        };
}

public class Result<T> : Result
{
    public T? Data { get; set; }
    
    public static Result<T> Success(T? data) 
        => new()
        {
            Data = data,
            IsSuccess = true
        };

    public new static Result<T> Error(string message)
        => new()
        {
            Message = message,
            IsSuccess = false
        };
}
