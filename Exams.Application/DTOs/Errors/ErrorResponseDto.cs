namespace ExamsApi.Application.DTOs.Errors
{
    public record ErrorResponseDto
    {
        public required string Error { get; set; }
        public int StatusCode { get; set; }
        public object? Details { get; set; }
    }
}
