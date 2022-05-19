namespace Shopbridge.Framework.CQRS.Results
{
    using System.Threading.Tasks;
    
    public class Result : IResult
    {
        protected Result() { }

        public bool Failed => !Succeeded;

        public string Message { get; protected set; }

        public bool Succeeded { get; protected set; }

        public static IResult Fail() => new Result { Succeeded = false };

        public static IResult Fail(string message) => new Result { Succeeded = false, Message = message };

        public static Task<IResult> FailAsync() => Task.FromResult(Fail());

        public static Task<IResult> FailAsync(string message) => Task.FromResult(Fail(message));

        public static IResult Success() => new Result { Succeeded = true };

        public static IResult Success(string message) => new Result { Succeeded = true, Message = message };

        public static Task<IResult> SuccessAsync() => Task.FromResult(Success());

        public static Task<IResult> SuccessAsync(string message) => Task.FromResult(Success(message));
    }

    public class Result<T> : Result, IResult<T>
    {
        protected Result() { }

        public T Data { get; private set; }

        public static new IResult<T> Fail() => new Result<T> { Succeeded = false };

        public static new IResult<T> Fail(string message) => new Result<T> { Succeeded = false, Message = message };

        public static new Task<IResult<T>> FailAsync() => Task.FromResult(Fail());

        public static new Task<IResult<T>> FailAsync(string message) => Task.FromResult(Fail(message));

        public static new IResult<T> Success() => new Result<T> { Succeeded = true };

        public static new IResult<T> Success(string message) => new Result<T> { Succeeded = true, Message = message };

        public static IResult<T> Success(T data) => new Result<T> { Succeeded = true, Data = data };

        public static IResult<T> Success(T data, string message) => new Result<T> { Succeeded = true, Data = data, Message = message };

        public static new Task<IResult<T>> SuccessAsync() => Task.FromResult(Success());

        public static new Task<IResult<T>> SuccessAsync(string message) => Task.FromResult(Success(message));

        public static Task<IResult<T>> SuccessAsync(T data) => Task.FromResult(Success(data));

        public static Task<IResult<T>> SuccessAsync(T data, string message) => Task.FromResult(Success(data, message));
    }
}