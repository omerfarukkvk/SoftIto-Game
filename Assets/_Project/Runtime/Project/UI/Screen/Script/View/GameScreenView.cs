using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class GameScreenView : MonoBehaviour
{
    public TMP_Text MinValue;
    public TMP_Text MaxValue;
    public TMP_Text CurrentScoreVal;
    public Slider MovementSlider;
    public Slider ScoreSlider;
    private Vector2 fp;
    private Vector2 lp;
    private bool ShowMovementSlider;
    
    void Awake()
    {
        //ScoreSlider.minValue = 0;
        //ScoreSlider.maxValue = 50;
        ShowMovementSlider = GameModel.Instance.MovementSliderVal;
    }

    private void Start()
    {
        //Movement Slider
        if (ShowMovementSlider)
        {
            MovementSlider.gameObject.SetActive(true);
        }
        else
        {
            MovementSlider.gameObject.SetActive(false);
        }
        
    }

    private void Update()
    {
        MinValue.text = ScoreSlider.minValue.ToString();
        MaxValue.text = ScoreSlider.maxValue.ToString();
        CurrentScoreVal.text = GameModel.Instance.Score.ToString();
        GameModel.Instance.MovementForce = MovementSlider.value;
        ScoreSlider.value = GameModel.Instance.Score;
        TouchMovement();
        CheckScore();
    }

    public void TouchMovement()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            //Debug.Log(touch.phase);
            if(touch.phase == TouchPhase.Began)
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if(touch.phase == TouchPhase.Stationary)
            {
                lp = touch.position;
                float movement = lp.x - fp.x;
                GameModel.Instance.MovementForce = movement / Screen.width;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                //number = 0;
                GameModel.Instance.MovementForce = 0;
            }
        }
        //Debug.Log("Movement force: " + GameModel.Instance.MovementForce);
    }

    private void CheckScore()
    {
        switch(GameModel.Instance.Score)
        {
            case int n when(n >= 0 && n < 100):
                SetSliderValues(0, 100, GameModel.Instance.Score);
                break;
            case int n when(n >= 100 && n < 200):
                SetSliderValues(100, 200, GameModel.Instance.Score);
                break;
            case int n when(n >= 200 && n < 300):
                SetSliderValues(200, 300,GameModel.Instance.Score);
                break;
            case int n when(n >= 300 && n < 400):
                SetSliderValues(300, 400,GameModel.Instance.Score);
                break;
            case int n when(n >= 400 && n < 500):
                SetSliderValues(400, 500,GameModel.Instance.Score);
                break;
            case int n when(n >= 500 && n < 600):
                SetSliderValues(500, 600,GameModel.Instance.Score);
                break;
            case int n when(n >= 600 && n < 700):
                SetSliderValues(600, 700,GameModel.Instance.Score);
                break;
        }
    }

    void SetSliderValues(int minValue, int maxValue, int sliderVal)
    {
        ScoreSlider.minValue = minValue;
        ScoreSlider.maxValue = maxValue;
        ScoreSlider.value = sliderVal;
    }

    public async void OnClickPauseButton()
    {
        Time.timeScale = 0f;
        await ScreenManager.Instance.OpenScreen(ScreenKeys.PauseScreen, ScreenLayers.Layer1);
    }

    public void OnChangedMovementSlider()
    {
        MovementSlider.value = 0;
    }
}