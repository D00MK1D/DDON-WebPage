using DDON_WebPage.Components.Data;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

public sealed class ItemCatalogService
{
    private readonly IWebHostEnvironment _env;
    private readonly IMemoryCache _cache;

    public ItemCatalogService(IWebHostEnvironment env, IMemoryCache cache)
    {
        _env = env;
        _cache = cache;
    }

    public async Task<ItemJson?> GetItemAsync(int itemId)
    {
        var cacheKey = $"item-json-{itemId}";

        if (_cache.TryGetValue(cacheKey, out ItemJson? cachedItem))
            return cachedItem;

        var path = Path.Combine(_env.WebRootPath, "items", $"i{itemId:D8}.json");

        if (!File.Exists(path))
            return null;

        await using var stream = File.OpenRead(path);

        var item = await JsonSerializer.DeserializeAsync<ItemJson>(stream);

        if (item is not null)
        {
            _cache.Set(cacheKey, item, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromHours(6),
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1)
            });
        }

        return item;
    }
}