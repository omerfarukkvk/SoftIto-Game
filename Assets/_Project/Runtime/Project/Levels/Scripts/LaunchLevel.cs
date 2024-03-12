using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchLevel : MonoBehaviour
{
    private void Awake()
    {
        BundleModel.Instance = new BundleModel();
    }

    public async void OnClickPauseButton()
    {
        await ScreenModel.Instance.OpenScreen(ScreenKeys.PauseScreen, ScreenLayers.Layer1);
    }
}
