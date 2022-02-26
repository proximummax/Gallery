using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransit : MonoBehaviour
{
    public void ChangeScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber, LoadSceneMode.Additive);
    }

    public void TransitImage()
    {
        ImageStorage.SelectedImage = gameObject.GetComponent<Image>();
    }
}
