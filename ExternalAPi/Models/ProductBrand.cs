namespace ExternalAPi.Models
{
    public record ProductBrand : ProductAttachment
    {
        public string BrandName { get; set; }
        public string BrandDescription { get; set; }
        public string BrandPhone { get; set; }
    }
}
