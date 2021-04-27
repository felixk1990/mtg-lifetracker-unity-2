using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalSet : MonoBehaviour
{
    public static int startLifePlayers;
    public static int startNumberPlayers;
    public static int startLevelID;

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
    public static float SetScaleXY(GameObject Counter, float scalefactor){

      RectTransform mymomstransform= Counter.GetComponent<RectTransform>();
      float scale;
      if (mymomstransform.rect.width <= mymomstransform.rect.height){
       scale = mymomstransform.rect.width;
      }else{
       scale = mymomstransform.rect.height;
      }

      return scale*=scalefactor;
    }
    public static Vector2 GetAnchorCenter(RectTransform RT){

      float ux=(RT.anchorMin.x + RT.anchorMax.x)/2.0f;
      float uy=(RT.anchorMin.y + RT.anchorMax.y)/2.0f;
      Vector2 u= new Vector2( ux, uy);

      return u;
    }
}
