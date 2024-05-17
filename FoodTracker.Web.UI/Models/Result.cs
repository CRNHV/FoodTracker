namespace FoodTracker.Web.UI.Models;

public sealed class Result<T> where T : class
{
    public T? Data { get; init; }
    public List<string> Errors { get; } = new List<string>();
    public bool IsSuccess { get => Errors.Count == 0; }
}

public static class Results<T> where T : class
{
    public static Result<T> Error(params string[] errors)
    {
        var result = new Result<T>();
        return result;
    }

    public static Result<T> FromException(Exception ex)
    {
        var result = new Result<T>();

        //var message = "An unexpected erorr occured while fetching data from the API";

        //if (ex.Message.Contains("404"))
        //    message = "Your query returned no results.";

        //if (ex.Message.Contains("401"))
        //    message = "You are not authorized to use the API.";

        result.Errors.Add(ex.Message);

        return result;
    }

    public static Result<T> Succes(T data)
    {
        var result = new Result<T>()
        {
            Data = data
        };
        return result;
    }
}