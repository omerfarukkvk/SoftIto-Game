using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScreenView : MonoBehaviour
{
    /*public Image Image1;
    private Sequence _sequence;


    private void Awake()
    {
        _sequence = DOTween.Sequence();

    }


    public void OnClick()
    {
        //Image1.color = Color.red;
        Image1.DOFade(0, 0).SetEase(Ease.InQuad).OnComplete((() =>
        {
            Image1.DOFade(1, .4f).SetEase(Ease.InQuad);
        }));
        var tween1 = Image1.transform.DOScaleY(13, .4f).SetRelative(true);
        var tween2 = Image1.transform.DOScaleX( 7,.3f).SetRelative(true);
        _sequence.Join(tween1).SetEase(Ease.InQuad);
        _sequence.Join(tween2).SetEase(Ease.InQuad);
    }*/
    public async void OnClickBackButton()
    {
        await ScreenModel.Instance.OpenScreen(ScreenKeys.MenuScreen, ScreenLayers.Layer1);
    }
}
