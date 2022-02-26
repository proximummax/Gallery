using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void CloseScene(int sceneNumber)
    {
        SceneManager.UnloadSceneAsync(sceneNumber);
    }

}
