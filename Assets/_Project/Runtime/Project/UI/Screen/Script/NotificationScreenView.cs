using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationScreenView : MonoBehaviour
{
    public GameObject FPS;
    private bool ShowFPS;
    public float UpdateInterval = 0.5f;
    private float accum = 0; // Toplam kare zamanı
    private int frames = 0; // Toplam kare sayısı
    private float timeleft; // Güncelleme aralığı

    void Awake()
    {
        ShowFPS = GameModel.Instance.ShowFPS;
    }
    void Start()
    {
        if (ShowFPS)
        {
            FPS.gameObject.SetActive(true);
            timeleft = UpdateInterval;
        }
        else
        {
            FPS.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        FPSFunc();
    }

    private void FPSFunc()
    {
        if (ShowFPS)
        {
            timeleft -= Time.deltaTime;
            accum += Time.timeScale / Time.deltaTime;
            ++frames;
            
            if (timeleft <= 0.0)
            {
                float fps = accum / frames;
                var FPSCount = FPS.transform.Find("FPSCount").gameObject.GetComponent<TMP_Text>();
                FPSCount.text = fps.ToString("f2");
                
                timeleft = UpdateInterval;
                accum = 0.0f;
                frames = 0;
            }
        }
    }
}
