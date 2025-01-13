namespace ExamsApi.DTOs.Errors
{
    public class ErrorResponseDto
    {
        public required string Error { get; set; }
        public int StatusCode { get; set; }
        public object? Details { get; set; }
    }
}
