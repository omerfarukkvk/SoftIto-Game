using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Runtime.Project.UI.Screen.Script.View
{
    
    public class GameScreenView : MonoBehaviour
    {
        public async void OnClickPauseButton()
        {
            await ScreenModel.Instance.OpenScreen(ScreenKeys.PauseScreen, ScreenLayers.Layer1);
        }
    }
}
