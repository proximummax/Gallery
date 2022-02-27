using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;


public class LoadImages : MonoBehaviour
{
    public event UnityAction<Texture2D, int> ImageReceived;


    public IEnumerator DownloadImage(int imageNumber)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture("http://data.ikppbb.com/test-task-unity-data/pics/" + (imageNumber + 1) + ".jpg");
        yield return request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
            Debug.Log("error request");
        else
            ImageReceived?.Invoke(DownloadHandlerTexture.GetContent(request), (imageNumber));
    }

}
