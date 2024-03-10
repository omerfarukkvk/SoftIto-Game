using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; //Do tween implement

public class GameScreenView : MonoBehaviour
{
    public void OnClickPauseButton()
    {
        
    }
    public async void OnClickBackButton()
    {
        await ScreenModel.Instance.OpenScreen(ScreenKeys.MenuScreen, ScreenLayers.Layer1);
    }
}
