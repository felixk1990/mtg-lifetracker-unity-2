using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class global_settings : MonoBehaviour
{
    public static int startLifePlayers;
    public static int startNumberPlayers;

    public static void  DisableAutoRotationFromLandscape() {
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.orientation = ScreenOrientation.Landscape;
    }

    public static void DisableAutoRotationFromPortrait() {

        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToLandscapeLeft = false;
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
