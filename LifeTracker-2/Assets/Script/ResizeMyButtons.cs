using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeMyButtons : MonoBehaviour
{
    public float myfactor;
    // Start is called before the first frame update
    void Start()
    {
      Invoke("ResizeAllButtons", 0.05f);
      // ResizeAllButtons();
    }

    public void ResizeAllButtons(){

      Vector2 u;
      GameObject myButton;
      float scaleXY;
      foreach(Transform T in transform){

          myButton=T.gameObject;
          if(myButton.GetComponent<Button>()){
          RectTransform mytransform = myButton.GetComponent<RectTransform>();

          u=GlobalSet.GetAnchorCenter(mytransform);
          mytransform.anchorMin= new Vector2(u.x,u.y);
          mytransform.anchorMax= new Vector2(u.x,u.y);
          if(myButton.name=="ButtonBack"){
            scaleXY=GlobalSet.SetScaleXY(gameObject,0.1f);
          }else{
            scaleXY=GlobalSet.SetScaleXY(gameObject,myfactor);
          }
          mytransform.offsetMin= new Vector2(-scaleXY,-scaleXY);
          mytransform.offsetMax= new Vector2(scaleXY,scaleXY);
        }
      }
    }
}
