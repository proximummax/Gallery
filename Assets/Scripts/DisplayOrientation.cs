using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayOrientation : MonoBehaviour
{
    public enum Orientations
    {
        Any,
        Portrait,
    }

    [SerializeField] private Orientations Orientation;

    private void Start()
    {
        Application.targetFrameRate = 60;

        switch (Orientation)
        {
            case Orientations.Any:
                Screen.orientation = ScreenOrientation.AutoRotation;

                Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = true;
                Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = true;
                break;

            case Orientations.Portrait:

                Screen.orientation = ScreenOrientation.Portrait;
                Screen.orientation = ScreenOrientation.AutoRotation;

                Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = true;
                Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = false;
                break;
        }

    }
}


