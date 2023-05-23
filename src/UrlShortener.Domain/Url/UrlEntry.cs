namespace UrlShortener.Domain.Url
{
    public class UrlEntry
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortAlias { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
