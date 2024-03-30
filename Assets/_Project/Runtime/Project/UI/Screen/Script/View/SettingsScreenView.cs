using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScreenView : MonoBehaviour
{
    public Toggle FPSToogle;
    public Toggle MovementSlider;

    private void Start()
    {
        FPSToogle.isOn = GameModel.Instance.ShowFPS; 
        MovementSlider.isOn = GameModel.Instance.MovementSliderVal;
    }

    public void OnClickBack()
    {
        ScreenManager.Instance.ClearLayer(ScreenLayers.Layer2);
    }

    public async void OnValueChangeFPSToggle(bool b)
    {
        if (b)
        {
            GameModel.Instance.ShowFPS = true;
            FPSToogle.isOn = true;
            await ScreenManager.Instance.OpenScreen(ScreenKeys.NotificationScreen, ScreenLayers.Layer4);
        }
        else
        {
            GameModel.Instance.ShowFPS = false;
            FPSToogle.isOn = false;
            ScreenManager.Instance.ClearLayer(ScreenLayers.Layer4);
        }
    }
    public void OnValueChangeMovementSliderToggle(bool b)
    {
        if (b)
        {
            GameModel.Instance.MovementSliderVal = true;
            MovementSlider.isOn = true;
        }
        else
        {
            GameModel.Instance.MovementSliderVal = false;
            MovementSlider.isOn = false;
        }
    }
}
