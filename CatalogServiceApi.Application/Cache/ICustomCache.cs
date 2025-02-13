using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogServiceApi.Application.Cache
{
    public interface ICustomCache
    {
        T Set<T> (string key, T value,TimeSpan expirationTime);
        T Get<T>(string key);
        void Remove(string key);

    }

}
