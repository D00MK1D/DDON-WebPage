using DDON_WebPage.Components.Data;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;
using System.IO.Compression;
using System.Text.Json;

public sealed class ItemCatalogService
{
    private readonly IWebHostEnvironment _env;
    private readonly IMemoryCache _cache;
    private readonly ConcurrentDictionary<int, ItemJson> _itemsCache = new();
    private readonly ConcurrentDictionary<string, byte[]> _imageCache = new(StringComparer.OrdinalIgnoreCase);

    public ItemCatalogService(IWebHostEnvironment env, IMemoryCache cache)
    {
        _env = env;
        _cache = cache;
        LoadAllItemsIntoMemory();
    }

    private void LoadAllItemsIntoMemory()
    {
        var itemsZipPath = Path.Combine(_env.WebRootPath, "items.zip");
        if (File.Exists(itemsZipPath))
        {
            using var archive = ZipFile.OpenRead(itemsZipPath);
            foreach (var entry in archive.Entries)
            {
                if (string.IsNullOrEmpty(entry.Name)) continue;

                if (entry.Name.Length >= 13 && int.TryParse(entry.Name.AsSpan(1, 8), out int itemId))
                {
                    using var stream = entry.Open();
                    var item = JsonSerializer.Deserialize<ItemJson>(stream);
                    if (item != null)
                    {
                        _itemsCache[itemId] = item;
                    }
                }
            }
        }
        var imagesZipPath = Path.Combine(_env.WebRootPath, "item-images.zip");
        if (File.Exists(imagesZipPath))
        {
            using var archive = ZipFile.OpenRead(imagesZipPath);
            foreach (var entry in archive.Entries)
            {
                if (string.IsNullOrEmpty(entry.Name)) continue;

                using var stream = entry.Open();
                using var ms = new MemoryStream();
                stream.CopyTo(ms);
                _imageCache[entry.Name] = ms.ToArray();
            }
        }
    }
    public Task<ItemJson?> GetItemAsync(int itemId)
    {
        _itemsCache.TryGetValue(itemId, out var item);
        return Task.FromResult(item);
    }
    public byte[]? GetItemImage(string fileName)
    {
        _imageCache.TryGetValue(fileName, out var bytes);
        return bytes;
    }
}