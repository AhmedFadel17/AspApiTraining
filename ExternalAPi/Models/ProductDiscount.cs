namespace ExternalAPi.Models
{
    public record ProductDiscount : ProductAttachment
    {
        public decimal? DiscountAmount { get; set; }
        public int? DiscountPercentage { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
