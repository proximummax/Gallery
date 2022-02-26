using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageDisplay : MonoBehaviour
{
    [SerializeField] private LoadImages _loader;
    [SerializeField] private Image _imagePrefab;
    [SerializeField] private GameObject _content;

    private Image _currentImage;

    private void Start()
    {
        DisplayOrientation.ChangeOrientation(DisplayOrientation.Orientations.Portrait);
    }

    private void OnEnable()
    {
        _loader.ImageReceived += InstatiateImage;
    }

    private void OnDisable()
    {
        _loader.ImageReceived -= InstatiateImage;
    }
    private void SetTexture(UnityWebRequest request, Image image)
    {
        Texture2D texture = DownloadHandlerTexture.GetContent(request);
        image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
    }

    private void InstatiateImage(UnityWebRequest request)
    {
        _currentImage = Instantiate(_imagePrefab, _content.transform);
        SetTexture(request, _currentImage);
    }
}
