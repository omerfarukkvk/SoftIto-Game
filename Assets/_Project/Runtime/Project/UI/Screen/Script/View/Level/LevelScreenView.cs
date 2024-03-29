using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScreenView : MonoBehaviour
{
    public async void OnClickBackButton()
    {
        await ScreenManager.Instance.OpenScreen(ScreenKeys.MenuScreen, ScreenLayers.Layer1);
    }
}
