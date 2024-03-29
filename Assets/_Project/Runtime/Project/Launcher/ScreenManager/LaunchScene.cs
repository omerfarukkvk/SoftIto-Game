using System.Collections;
using System.Collections.Generic;
using log4net.Layout;
using UnityEngine;

public class LaunchScene : MonoBehaviour
{
    public async void Awake()
    {
        BundleModel.Instance = new BundleModel();
        var screenManager = ScreenModel.Instance;
        await screenManager.OpenScreen(ScreenKeys.MenuScreen, ScreenLayers.Layer1);
    }
}
