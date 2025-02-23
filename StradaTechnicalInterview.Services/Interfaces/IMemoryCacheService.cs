namespace StradaTechnicalInterview.Services.Interfaces
{
    public interface IMemoryCacheService
    {
        T GetCache<T>(string key);
        void RemoveKey(string key);
        void SetCacheOneDay<T>(string key, T value);
        void SetCacheOneHour<T>(string key, T value);
    }
}