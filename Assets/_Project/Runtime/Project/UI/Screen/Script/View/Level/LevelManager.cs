using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLevelScene : MonoBehaviour
{
    public async void OnClickLevelOne()
    {
        await BundleModel.Instance.LoadScene("Level1", LoadSceneMode.Single);
    }
    public async void OnClickLevelTwo()
    {
        await BundleModel.Instance.LoadScene("Level2", LoadSceneMode.Single);
    }
    public async void OnClickLevelThree()
    {
        await BundleModel.Instance.LoadScene("Level3", LoadSceneMode.Single);
    }
    public async void OnClickLevelFour()
    {
        await BundleModel.Instance.LoadScene("Level4", LoadSceneMode.Single);
    }
    public async void OnClickLevelFive()
    {
        await BundleModel.Instance.LoadScene("Level5", LoadSceneMode.Single);
    }
    public async void OnClickLevelSix()
    {
            await BundleModel.Instance.LoadScene("Level6", LoadSceneMode.Single);
    }
}
