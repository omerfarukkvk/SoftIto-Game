using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreenView : MonoBehaviour
{
    public TMP_Text ScoreLabel;
    void Awake()
    {
        ScoreLabel.text += GameModel.Instance.Score.ToString();
    }
    public async void OnClickRestartButton()
    {
        await BundleModel.Instance.UnLoadScene("Level1");
        ScreenManager.Instance.ClearLayer(ScreenLayers.Layer2);
        await BundleModel.Instance.LoadScene("Level1", LoadSceneMode.Single);
    }
    public async void OnClickSettingsButton()
    {
        await ScreenManager.Instance.OpenScreen(ScreenKeys.SettingsScreen, ScreenLayers.Layer2);
    }
    public async void OnClickExitButton()
    {
        ScreenManager.Instance.ClearLayer(ScreenLayers.Layer2);
        await BundleModel.Instance.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}
