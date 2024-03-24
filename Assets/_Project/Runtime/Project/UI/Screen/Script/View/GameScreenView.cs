using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

namespace _Project.Runtime.Project.UI.Screen.Script.View
{
    public class GameScreenView : MonoBehaviour
    {
        public TMP_Text MinValue;
        public TMP_Text MaxValue;
        public Slider MovementSlider;
        public Slider ScoreSlider;
        void Awake()
        {
            ScoreSlider.minValue = 0;
            ScoreSlider.maxValue = 100;
        }

        private void Update()
        {
            MinValue.text = ScoreSlider.minValue.ToString();
            MaxValue.text = ScoreSlider.maxValue.ToString();
            GameModel.Instance.MovementForce = MovementSlider.value;
            ScoreSlider.value = GameModel.Instance.Score;
            CheckScore();
        }

        private void CheckScore()
        {
            switch(GameModel.Instance.Score)
            {
                case 100:
                    SetSliderValues(100, 200);
                    break;
                case 200:
                    SetSliderValues(200, 300);
                    break;
                //Caseler eklenecek!!
            }
        }

        void SetSliderValues(int minValue, int maxValue)
        {
            ScoreSlider.minValue = minValue;
            ScoreSlider.maxValue = maxValue;
            ScoreSlider.value = minValue;
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