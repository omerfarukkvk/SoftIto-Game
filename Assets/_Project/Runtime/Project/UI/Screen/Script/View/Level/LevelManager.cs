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
}
