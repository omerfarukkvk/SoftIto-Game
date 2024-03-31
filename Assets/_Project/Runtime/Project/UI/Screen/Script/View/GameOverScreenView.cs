using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
        ScreenManager.Instance.ClearLayer(ScreenLayers.Layer2);
        await ScreenManager.Instance.OpenScreen(ScreenKeys.LevelScreen, ScreenLayers.Layer1);
    }
    public async void OnClickSettingsButton()
    {
        ScreenManager.Instance.ClearLayer(ScreenLayers.Layer2);
        await ScreenManager.Instance.OpenScreen(ScreenKeys.SettingsScreen, ScreenLayers.Layer2);
    }
    public async void OnClickExitButton()
    {
        ScreenManager.Instance.ClearLayer(ScreenLayers.Layer2);
        await BundleModel.Instance.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}
