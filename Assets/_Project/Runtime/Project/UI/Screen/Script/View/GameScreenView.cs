using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Runtime.Project.UI.Screen.Script.View
{
    public class GameScreenView : MonoBehaviour
    {
        public Slider MovementSlider;
        public Slider ScoreSlider;

        private void Start()
        {
            StartCoroutine(AddScore());
        }

        private IEnumerator AddScore()
        {
            while (true)
            {
                    yield return new WaitForSeconds(0.1f);
                    GameModel.Instance.Score++;
            }
        }

        private void Update()
        {
            GameModel.Instance.MovementForce = MovementSlider.value;
            ScoreSlider.value = GameModel.Instance.Score;
        }

        public async void OnClickPauseButton()
        {
            Time.timeScale = 0f;
            await ScreenModel.Instance.OpenScreen(ScreenKeys.PauseScreen, ScreenLayers.Layer1);
        }

        public void OnChangedMovementSlider()
        {
            MovementSlider.value = 0;
        }
    }
}