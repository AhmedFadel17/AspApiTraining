using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogServiceApi.Domain.Settings
{
    public class ExternalServiceSetting
    {
        public string Url { get; set; }
        public int CacheInSeconds { get; set; } = 1000;
        public int RetriesCount { get; set; } = 3;
    }
}
