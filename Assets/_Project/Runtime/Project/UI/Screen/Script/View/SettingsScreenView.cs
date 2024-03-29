using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScreenView : MonoBehaviour
{
    public void OnClickBack()
    {
        ScreenModel.Instance.ClearLayer(ScreenLayers.Layer2);
    }

    public void OnValueChangecFPSToggle(bool b)
    {
        if (b)
        {
            GameModel.Instance.ShowFPS = true;
        }
        else
        {
            GameModel.Instance.ShowFPS = false;
        }
    }
}
