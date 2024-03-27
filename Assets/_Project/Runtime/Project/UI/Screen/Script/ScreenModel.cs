using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ScreenModel : SingletonBehaviour<ScreenModel>
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

        // Eğer bulunduğunuz layerda daha önceden bir screen varsa ve clearLayer değişkenini false vermediyseniz o layerdaki ekranları temizler
        if (clearLayer)
            ClearLayer(layerKey);
        
        // screenLayers ın içinde dönüp verdiğimiz layerı bulur
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
        
        //layer varsa screeni yükler.
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
