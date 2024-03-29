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
    private Vector2 fp;
    private Vector2 lp;
    
    //FPS
    private bool ShowFPS;
    public float updateInterval = 0.5f;

    private float accum = 0; // Toplam kare zamanı
    private int frames = 0; // Toplam kare sayısı
    private float timeleft; // Güncelleme aralığı
    public TMP_Text FPSLabel;
    void Awake()
    {
        ScoreSlider.minValue = 0;
        ScoreSlider.maxValue = 100;
        ShowFPS = GameModel.Instance.ShowFPS;
    }

    private void Start()
    {
        if (ShowFPS)
        {
            FPSLabel.gameObject.SetActive(true);
            timeleft = updateInterval;
        }
    }

    private void Update()
    {
        MinValue.text = ScoreSlider.minValue.ToString();
        MaxValue.text = ScoreSlider.maxValue.ToString();
        GameModel.Instance.MovementForce = MovementSlider.value;
        ScoreSlider.value = GameModel.Instance.Score;
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