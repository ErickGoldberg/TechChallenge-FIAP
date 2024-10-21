namespace Contacts.Application.Abstraction
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFound { get; }
        public string Message { get; }

        public Result(bool isSuccess, string message, bool isFound = true)
        {
            IsSuccess = isSuccess;
            IsFound = isFound;
            Message = message;
        }

        public static Result Success(string message = "Success.")
        {
            return new Result(true, message);
        }

        public static Result Failure(string message = "Failure.")
        {
            return new Result(false, message);
        }

        public static Result NotFound(string message = "Not Found.")
        {
            return new Result(false, message, false);
        }
    }

    public class Result<T> : Result
    {
        public T Data { get; }

        public Result(bool isSuccess, string message, bool isFound = true, T data = default)
            : base(isSuccess, message, isFound)
        {
            Data = data;
        }

        public static new Result<T> Success(T data, string message = "Success.")
        {
            return new Result<T>(true, message, data: data);
        }

        public static new Result<T> Failure(string message = "Failure.")
        {
            return new Result<T>(false, message);
        }

        public static new Result<T> NotFound(string message = "Not Found.")
        {
            return new Result<T>(false, message, false);
        }
    }

}
