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
        await BundleModel.Instance.UnLoadScene("Level2");
        ScreenModel.Instance.ClearLayer(ScreenLayers.Layer2);
        await BundleModel.Instance.LoadScene("Level2", LoadSceneMode.Single);
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