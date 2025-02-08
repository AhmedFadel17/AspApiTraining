using System.Diagnostics.CodeAnalysis;

namespace CatalogServiceApi.Application.DTOs.Errors
{
    [ExcludeFromCodeCoverage]
    public record ErrorResponseDto
    {
        public required string Error { get; set; }
        public int StatusCode { get; set; }
        public object? Details { get; set; }
    }
}
