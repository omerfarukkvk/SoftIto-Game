using UnityEngine;

namespace _Project.Runtime.Project.UI.Screen.Script.View
{
    public class MenuScreenView : MonoBehaviour
    {
        public void OnClickExit()
        {
            Application.Quit();
        }
        public async void OnClickSettingsScreen()
        {
            await ScreenManager.Instance.OpenScreen(ScreenKeys.SettingsScreen, ScreenLayers.Layer2);
        }
        public async void OnClickGameScreen()
        {
            await ScreenManager.Instance.OpenScreen(ScreenKeys.LevelScreen, ScreenLayers.Layer1);
        }
        public async void OnClickStoreScreen()
        {
            await ScreenManager.Instance.OpenScreen(ScreenKeys.StoreScreen, ScreenLayers.Layer1);
        }
        
    }
}
