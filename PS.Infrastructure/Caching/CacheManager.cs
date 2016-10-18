using System;
using System.Configuration;
using ServiceStack.Redis;

namespace PS.Infrastructure.Caching
{
    public class CacheManager : ICacheManager
    {
        private RedisClient redisClient = null;
        private String hostName = ConfigurationManager.AppSettings["HostName"];
        private int portNumber = int.Parse(ConfigurationManager.AppSettings["PortNumber"]);

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value associated with the specified key.</returns>
        public T Get<T>(string key)
        {
            using (redisClient = new RedisClient(hostName, portNumber))
            {
                var typedclient = redisClient.As<T>();
                return typedclient.GetValue(key);
            }
        }

        /// <summary>
        /// Adds the specified key and object to the cache.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="cacheTime">Cache time</param>
        public void Set(string key, object data, TimeSpan timespan)
        {
            using (redisClient = new RedisClient(hostName, portNumber))
            {
                redisClient.Set(key, data, timespan);

            }
        }

        /// <summary>
        /// Adds the specified key and object to the cache.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        public void Set(string key, object data)
        {
            using (redisClient = new RedisClient(hostName, portNumber))
            {
                redisClient.Set(key, data);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the value associated with the specified key is cached
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>Result</returns>
        public bool IsSet(string key)
        {
            using (redisClient = new RedisClient(hostName, portNumber))
            {
                return redisClient.ContainsKey(key);
            }

        }

        /// <summary>
        /// Removes the value with the specified key from the cache
        /// </summary>
        /// <param name="key">/key</param>
        public void Remove(string key)
        {
            using (redisClient = new RedisClient(hostName, portNumber))
            {
                redisClient.Remove(key);
            }
        }

        /// <summary>
        /// Removes items by pattern
        /// </summary>
        /// <param name="pattern">pattern</param>
        public void RemoveByPattern(string pattern)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Clear all cache data
        /// </summary>
        public void Clear()
        {
            using (redisClient = new RedisClient(hostName, portNumber))
            {
                var typedclient = redisClient;
                typedclient.FlushDb();
            }
        }


    }
}
