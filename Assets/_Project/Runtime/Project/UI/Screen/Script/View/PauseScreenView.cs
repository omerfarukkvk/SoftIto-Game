using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenView : MonoBehaviour
{
    public void OnClickResumeButton()
    {
        ScreenModel.Instance.ClearLayer(ScreenLayers.Layer1);
    }
    
    public async void OnClickSettingsButton()
    {
        await ScreenModel.Instance.OpenScreen(ScreenKeys.SettingsScreen, ScreenLayers.Layer2);
    }
    
    public async void OnClickExitButton()
    {
        ScreenModel.Instance.ClearLayer(ScreenLayers.Layer2);
        await BundleModel.Instance.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}
