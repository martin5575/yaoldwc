using OpenLigaApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FootballEstimate.Model.Loader
{
    public class DoubleCachedLoader<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _cache =
            new Dictionary<TKey, TValue>();

        public Func<TKey, string> LocalFileNameFunc { get; }
        public Func<TKey, Task<TValue>> RemoteLoaderFunc { get; }

        public DoubleCachedLoader(
            Func<TKey,string> localFileNameFunc, 
            Func<TKey, Task<TValue>> remoteLoaderFunc)
        {
            LocalFileNameFunc = localFileNameFunc;
            RemoteLoaderFunc = remoteLoaderFunc;
        }

        public async Task<TValue> GetFromCacheOrLoadAsync(TKey key)
        {
            TValue value;
            if (_cache.TryGetValue(key, out value))
                return await Task.FromResult(value);

            var path = LocalFileNameFunc(key);
            value = SettingsReader.ReadData<TValue>(path);
            if (value != null)
            {
                _cache.Add(key, value);
                return await Task.FromResult(value);
            }

            value = await RemoteLoaderFunc(key);
            SettingsReader.WriteData(path, value);
            _cache.Add(key, value);
            return value;
        }
    }
}

