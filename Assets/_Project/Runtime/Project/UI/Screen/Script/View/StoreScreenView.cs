using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoreScreenView : MonoBehaviour
{
   public TextMeshProUGUI DiamondText;
   private void Start()
   {
      DiamondText.text=(GameModel.Instance.DiamondVal).ToString();
   }
   public async void OnClickBackButton()
   {
      ScreenManager.Instance.ClearLayer(ScreenLayers.Layer1);
      await ScreenManager.Instance.OpenScreen(ScreenKeys.MenuScreen, ScreenLayers.Layer1);
   }
}
