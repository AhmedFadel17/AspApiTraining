namespace ExternalAPi.Models
{
    public record ProductMedia : ProductAttachment
    {
        public string MediaUrl { get; set; }
        public string MediaType { get; set; }
    }
}
