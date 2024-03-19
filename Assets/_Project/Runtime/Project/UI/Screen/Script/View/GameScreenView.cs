using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Runtime.Project.UI.Screen.Script.View
{
    
    public class GameScreenView : MonoBehaviour
    {
        public Slider MovementSlider;
        public async void OnClickPauseButton()
        {
            await ScreenModel.Instance.OpenScreen(ScreenKeys.PauseScreen, ScreenLayers.Layer1);
        }
        public void OnChangedMovementSlider()
        {
            MovementSlider.value = 0;
        }
    }
}
