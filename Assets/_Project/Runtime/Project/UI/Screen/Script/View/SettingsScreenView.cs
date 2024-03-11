using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScreenView : MonoBehaviour
{
    public void OnClickBack()
    {
        ScreenModel.Instance.ClearLayer(ScreenLayers.Layer3);
    }
}
