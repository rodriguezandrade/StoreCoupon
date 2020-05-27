
using System.Collections.Generic;

namespace Repository.Models.Redis
{
    public class Redis
    {
        public string Password { get; set; }
        public bool AllowAdmin { get; set; }
        public bool Ssl { get; set; }
        public int ConnectTimeout { get; set; }
        public int ConnectRetry { get; set; }
        public int Database { get; set; }
        public List<Hosts> Hosts { get; set; }
    }
}
