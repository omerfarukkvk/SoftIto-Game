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
    
    //FPS
    private bool ShowFPS;
    public float updateInterval = 0.5f;

    private float accum = 0; // Toplam kare zamanı
    private int frames = 0; // Toplam kare sayısı
    private float timeleft; // Güncelleme aralığı
    public TMP_Text FPSLabel;
    void Awake()
    {
        //ScoreSlider.minValue = 0;
        //ScoreSlider.maxValue = 50;
        ShowFPS = GameModel.Instance.ShowFPS;
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
        
        //FPS show
        if (ShowFPS)
        {
            FPSLabel.gameObject.SetActive(true);
            timeleft = updateInterval;
        }
        else
        {
            FPSLabel.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        MinValue.text = ScoreSlider.minValue.ToString();
        MaxValue.text = ScoreSlider.maxValue.ToString();
        CurrentScoreVal.text = GameModel.Instance.Score.ToString();
        GameModel.Instance.MovementForce = MovementSlider.value;
        ScoreSlider.value = GameModel.Instance.Score;
        FPSFunc();
        TouchMovement();
        CheckScore();
    }

    public void FPSFunc()
    {
        if (ShowFPS)
        {
            timeleft -= Time.deltaTime;
            accum += Time.timeScale / Time.deltaTime;
            ++frames;
            
            if (timeleft <= 0.0)
            {
                float fps = accum / frames;
                
                FPSLabel.text = fps.ToString("f2");
                
                timeleft = updateInterval;
                accum = 0.0f;
                frames = 0;
            }
        }
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
            case int n when(n >= 0 && n < 50):
                SetSliderValues(0, 50, GameModel.Instance.Score);
                break;
            case int n when(n >= 50 && n < 100):
                SetSliderValues(50, 100, GameModel.Instance.Score);
                break;
            case int n when(n >= 100 && n < 150):
                SetSliderValues(100, 150,GameModel.Instance.Score);
                break;
            case int n when(n >= 150 && n < 200):
                SetSliderValues(150, 200,GameModel.Instance.Score);
                break;
            case int n when(n >= 200 && n < 250):
                SetSliderValues(200, 250,GameModel.Instance.Score);
                break;
            case int n when(n >= 250 && n < 300):
                SetSliderValues(250, 300,GameModel.Instance.Score);
                break;
            case int n when(n >= 300 && n < 350):
                SetSliderValues(300, 350,GameModel.Instance.Score);
                break;
            case int n when(n >= 350 && n < 400):
                SetSliderValues(350, 400,GameModel.Instance.Score);
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