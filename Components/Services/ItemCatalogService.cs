using DDON_WebPage.Components.Data;
using System.IO.Compression;
using System.Text.Json;
using System.Collections.Concurrent;

public sealed class ItemCatalogService
{
    private readonly ConcurrentDictionary<int, ItemJson> _itemsCache = new();
    private readonly IWebHostEnvironment _env;

    public ItemCatalogService(IWebHostEnvironment env)
    {
        _env = env;
        LoadAllItemsIntoMemory();
    }

    private void LoadAllItemsIntoMemory()
    {
        var zipFilePath = Path.Combine(_env.WebRootPath, "items.zip");
        if (!File.Exists(zipFilePath)) return;

        using var archive = ZipFile.OpenRead(zipFilePath);
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

    public Task<ItemJson?> GetItemAsync(int itemId)
    {
        _itemsCache.TryGetValue(itemId, out var item);
        return Task.FromResult(item);
    }
}