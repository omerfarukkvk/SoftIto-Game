using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ScreenManager : SingletonBehaviour<ScreenManager>
{
    [Serializable]
    public class ScreenLayer
    {
        public string Key;
        public Transform Layer;
    }
    public List<ScreenLayer> screenLayers;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public async Task<GameObject> OpenScreen(string screenKey,string layerKey,bool clearLayer = true)
    {
        Transform layer = null;

        if (clearLayer)
            ClearLayer(layerKey);
        
        foreach (var screenLayer in screenLayers)
        {
            if (screenLayer.Key == layerKey)
            {
                layer = screenLayer.Layer;
                break;
            }
        }

        if (layer == null)
        {
            Debug.Log("Layer not found!");
        }
        
        var loadPrefab = await BundleModel.Instance.LoadPrefab(screenKey,layer);
        
        return loadPrefab;
    }
    public void ClearLayer(string layerKey)
    {
        foreach (var screenLayer in screenLayers)
        {
            if (screenLayer.Key == layerKey)
            {
                var layer = screenLayer.Layer;
                foreach (Transform child in layer)
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }
}
