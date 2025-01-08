using CatalogServiceAPI.Entities;

namespace CatalogServiceAPI.DTOs.Products
{
    public class PaginateProductsDto
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<Product>? Data { get; set; }

        public PaginateProductsDto(List<Product> data, int count, int pageNumber, int pageSize)
        {
            Data = data;
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
    }
}
