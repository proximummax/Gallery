using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageDisplay : MonoBehaviour
{
    [SerializeField] private LoadImages _loader;
    [SerializeField] private Image _imagePrefab;
    [SerializeField] private GameObject _content;

    private List<Image> _images = new List<Image>();

    private void Start()
    {
        DisplayOrientation.ChangeOrientation(DisplayOrientation.Orientations.Portrait);

        for (int i = 0; i <= 65; i++)
            _images.Add(Instantiate(_imagePrefab, _content.transform));

        StartCoroutine(DisplayImage());
    }


    private IEnumerator DisplayImage()
    {
        while (true)
        {
            for (int i = 0; i < _images.Count; i++)
            {
                if (_images[i].GetComponent<Renderer>().isVisible && _images[i].sprite == null)
                {
                    yield return StartCoroutine(_loader.DownloadImage(i));
                }
            }
            yield return null;
        }
    }
    private void OnEnable()
    {
        _loader.ImageReceived += SetTexture;
    }

    private void OnDisable()
    {
        _loader.ImageReceived -= SetTexture;
    }
    private void SetTexture(Texture2D texture, int imageNumber)
    {
        _images[imageNumber].sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
    }

}
