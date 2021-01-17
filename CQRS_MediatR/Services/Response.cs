namespace Services
{
    public static class Response
    {
        public static Response<T> Ok<T>(T data, string message = default) => 
            new Response<T>{
                Message = message,
                Data = data,
                Error = false
            };
        public static Response<T> Fail<T>(string message, T data = default) => 
            new Response<T>{
                Message = message,
                Data = data,
                Error = true
            };
    }
    public class Response<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Error { get; set; }
    }
}