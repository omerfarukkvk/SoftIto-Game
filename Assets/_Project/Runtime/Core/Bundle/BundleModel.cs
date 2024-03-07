using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Project.Runtime.Core.Singleton;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class BundleModel : SingletonModel<BundleModel>
{
    public async Task<GameObject> LoadPrefab(string key, Transform parent)
    {
        var asyncOperationHandle = Addressables.InstantiateAsync(key, parent);
        await asyncOperationHandle.Task;
        return asyncOperationHandle.Result;
    }

    public async Task<Sprite> LoadSprite(string key)
    {
        var asyncOperationHandle = Addressables.LoadAssetAsync<Sprite>(key);
        await asyncOperationHandle.Task;
        return asyncOperationHandle.Result;
    }
}
