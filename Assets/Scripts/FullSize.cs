using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullSize : MonoBehaviour
{
    [SerializeField] private Image _fullImagePrefab;
    [SerializeField] private GameObject _panel;

    private Image _currentImage;

    private void Start()
    {
        SetFullSizeImage();
    }

    private void SetFullSizeImage()
    {
        _currentImage = Instantiate(_fullImagePrefab, _panel.transform);
        _currentImage.sprite = ImageStorage.SelectedImage.sprite;
    }
}
