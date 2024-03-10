using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MenuScreenView : MonoBehaviour
{
    public void OnClickExit()
    {
        Application.Quit();
    }
    public async void OnClickSettingsScreen()
    {
        await ScreenModel.Instance.OpenScreen(ScreenKeys.SettingsScreen, ScreenLayers.Layer1);
    }
    public async void OnClickGameScreen()
    {
        await ScreenModel.Instance.OpenScreen(ScreenKeys.GameScreen, ScreenLayers.Layer1);
    }
}
