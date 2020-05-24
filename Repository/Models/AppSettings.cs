namespace Repository.Models
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public double ExpireTime { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
    }
}