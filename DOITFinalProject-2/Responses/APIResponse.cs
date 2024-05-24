namespace DOITFinalProject_2.Responses
{
    public class APIResponse
    {
        public string Message { get; set; } = null!;
        public bool IsSuccess { get; set; }
        public object Result { get; set; } = null!;
        public int StatusCode { get; set; }
    }
}
