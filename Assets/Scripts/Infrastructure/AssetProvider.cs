using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AssetProvider : IAssetProvider
{
    private Dictionary<string, Object> _cachedObject = new();

    public Object LoadAsset(string key)
    {
        if (_cachedObject.ContainsKey(key))
        {
            return _cachedObject[key];
        }

        var prefab = Resources.LoadAsync(key);

        _cachedObject.Add(key, prefab.asset);

        return prefab.asset;
    }
}