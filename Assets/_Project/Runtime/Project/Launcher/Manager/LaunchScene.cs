using System;
using UnityEngine;

namespace _Project.Runtime.Project.Launcher.Menager
{
    public class LaunchScene:MonoBehaviour
    {
        public async void Awake()
        {
            BundleModel.Instance = new BundleModel();
            var screenManager = ScreenModel.Instance;
            await screenManager.OpenScreen(ScreenKeys.MenuScreen, ScreenLayers.Layer1);
        }
    }

    
}