namespace urlshortner.Models
{
    public class UrlManagement
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public string ShortenUrl { get; set; } = string.Empty;
    }

    public class UrlManagementRequest
    {
        public string Url { get; set; } = string.Empty;
    }

    public class UrlManagementResponse
    {
        public string ShortenUrl { get; set; } = string.Empty;
    }
}
