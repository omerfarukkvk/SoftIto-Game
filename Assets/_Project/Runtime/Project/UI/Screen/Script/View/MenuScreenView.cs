using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreenView : MonoBehaviour
{
    public void OnClickExit()
    {
        Application.Quit();
    }
    public void OnClickSettingsScreen()
    {
        
    }
    public void OnClickGameScreen()
    {
        
    }
    public void OnClickMenuScreen()
    {
        OpenMenuScreen();
    }
    private async void OpenMenuScreen()
    {
        await ScreenModel.Instance.OpenScreen(ScreenKeys.MenuScreen, ScreenLayers.Layer1);
    }
}
