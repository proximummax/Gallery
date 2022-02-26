using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;


public class LoadImages : MonoBehaviour
{
    public event UnityAction<UnityWebRequest> ImageReceived;
    private void Start()
    {
        StartCoroutine(DownloadImage());
    }

    private IEnumerator DownloadImage()
    {
        for (int imageNumber = 1; imageNumber <= 66; imageNumber++)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture("http://data.ikppbb.com/test-task-unity-data/pics/" + imageNumber + ".jpg");
            yield return request.SendWebRequest();
            ImageReceived?.Invoke(request);
        }
    }

}
