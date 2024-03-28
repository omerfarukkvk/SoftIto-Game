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
    public Slider MovementSlider;
    public Slider ScoreSlider;
    Vector2 fp;
    Vector2 lp;
    float movementThreshold = 10f;
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
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            //Debug.Log(touch.phase);
            if(touch.phase == TouchPhase.Began)
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                lp = touch.position;
                float movement = lp.x - fp.x;
                if(Mathf.Abs(movement) > movementThreshold)
                    GameModel.Instance.MovementForce = movement / (Screen.width / 2);   
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                //number = 0;
                GameModel.Instance.MovementForce = 0;
            }
        }
        //Debug.Log("Movement force: " + GameModel.Instance.MovementForce);
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