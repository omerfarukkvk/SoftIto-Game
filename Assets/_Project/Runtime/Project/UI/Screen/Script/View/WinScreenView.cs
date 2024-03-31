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
    public async void OnClickLevelButton()
    {
        ScreenManager.Instance.ClearLayer(ScreenLayers.Layer2);
        ScreenManager.Instance.ClearLayer(ScreenLayers.Layer1);
        await ScreenManager.Instance.OpenScreen(ScreenKeys.LevelScreen, ScreenLayers.Layer1);
    }
  
    public async void OnClickExitButton()
    {
        ScreenManager.Instance.ClearLayer(ScreenLayers.Layer2);
        await BundleModel.Instance.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}
