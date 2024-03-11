using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreenView : MonoBehaviour
{
    public void OnClickResumeButton()
    {
        ScreenModel.Instance.ClearLayer(ScreenLayers.Layer2);
    }
    
    public async void OnClickSettingsButton()
    {
        await ScreenModel.Instance.OpenScreen(ScreenKeys.SettingsScreen, ScreenLayers.Layer3);
    }
    
    public async void OnClickExitButton()
    {
        ScreenModel.Instance.ClearLayer(ScreenLayers.Layer2);
        await ScreenModel.Instance.OpenScreen(ScreenKeys.MenuScreen, ScreenLayers.Layer1);
    }
}
