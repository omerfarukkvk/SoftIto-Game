using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchLevel : MonoBehaviour
{
    private void Awake()
    {
        OpenGameScreen();
    }

    public async void OpenGameScreen()
    {
        await ScreenManager.Instance.OpenScreen(ScreenKeys.GameScreen, ScreenLayers.Layer1);
    }
}
