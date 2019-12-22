namespace T.Core.Shared
{
    public class ApiExcuteResult
    {
        public ApiStatus Status { get; set; }

        public object Data { get; set; }

        public string Message { get; set; }
    }

    public enum ApiStatus
    {
        Fail,
        Success
    }
}
