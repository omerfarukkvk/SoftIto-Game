using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; //Do tween implement

public class GameScreenView : MonoBehaviour
{
    public async void OnClickPauseButton()
    {
        await ScreenModel.Instance.OpenScreen(ScreenKeys.PauseScreen, ScreenLayers.Layer2);
    }
    public async void OnClickBackButton()
    {
        await ScreenModel.Instance.OpenScreen(ScreenKeys.MenuScreen, ScreenLayers.Layer1);
    }
}
