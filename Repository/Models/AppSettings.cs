namespace Repository.Models
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpireTime { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
    }
}