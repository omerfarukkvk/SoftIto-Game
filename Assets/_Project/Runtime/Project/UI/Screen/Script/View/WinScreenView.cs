using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenView : MonoBehaviour
{
    public TMP_Text ScoreLabel;
    void Awake()
    {
        ScoreLabel.text += GameModel.Instance.Score.ToString();
    }
    public async void OnClickNextButton()
    {
        ScreenManager.Instance.ClearLayer(ScreenLayers.Layer1);
        await BundleModel.Instance.LoadScene("Level2", LoadSceneMode.Single);
    }
    public async void OnClickSettingsButton()
    {
        await ScreenManager.Instance.OpenScreen(ScreenKeys.SettingsScreen, ScreenLayers.Layer1);
    }
    public async void OnClickExitButton()
    {
        await BundleModel.Instance.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}
