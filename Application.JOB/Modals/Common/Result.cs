namespace Application.JOB.Modals.Common;

public class Result<T>
{
    public bool Succeded { get; set; }
    public List<string> Messages { get; set; } = [];
    public required T Data { get; set; }

    public static Result<T> Success(params string[] messages)
    {
        return new Result<T>
        {
            Succeded = true,
            Data = default,
            Messages = messages?.ToList() ?? []
        };
    }

    public static Result<T> Success(T data, params string[] messages)
    {
        return new Result<T>
        {
            Succeded = true,
            Data = data,
            Messages = messages?.ToList() ?? []
        };
    }

    public static Result<T> Fail(params string[] messages)
    {
        return new Result<T>
        {
            Succeded = false,
            Data = default,
            Messages = messages?.ToList() ?? []
        };
    }
}
