using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipePanels : MonoBehaviour , IDragHandler, IEndDragHandler
{

    private Vector3 panelLocation;
    public float percentThreshold=0.2f;
    public float easing=0.5f;
    public bool shifted=false;
    public RectTransform mytransform;
    float rotation;
    // Start is called before the first frame update
    void Start()
    {
      // panelLocation=transform.position;
      panelLocation=transform.localPosition;
      mytransform = gameObject.GetComponent<RectTransform>();
      rotation = transform.eulerAngles.z;

    }
    public float IsRotated(){

      float s=1;
      if(rotation==180){
        s= -1;
      }
      else if(rotation==90){
        s= -1;
      }
      return s;
    }
    public float SetWindowTranslationY (){

      float dy=mytransform.rect.height/2.0f;
      // dy*=IsRotated();
      return dy;

    }
    public float SetTranslationY (PointerEventData data){

      float dy= data.position.y - data.pressPosition.y;
      dy*=IsRotated();
      return dy;

    }
    public float SetTranslationRotatedY (PointerEventData data){

      float dy= data.position.x - data.pressPosition.x;
      dy*=IsRotated();
      return dy;

    }
    public void OnDrag( PointerEventData data){

        float dy=0.0f;
        if (rotation==90 | rotation==270){
          dy = SetTranslationRotatedY(data);
        }
        else if (rotation==0 | rotation==180){
          dy = SetTranslationY(data);
        }

        if((dy > 0) && shifted){
          transform.localPosition= panelLocation + new Vector3 (0,dy,0);
        }else if((dy  < 0) && !shifted  ){
          transform.localPosition= panelLocation + new Vector3 (0,dy,0);
        }

    }

    public void OnEndDrag( PointerEventData data){

      // float dy= SetTranslationY(data);
      float dy=0.0f;
      if (rotation==90 | rotation==270){
        dy = SetTranslationRotatedY(data);
      }
      else if (rotation==0 | rotation==180){
        dy = SetTranslationY(data);
      }
      float DY= SetWindowTranslationY();
      float percentage = dy / DY;

      if(Mathf.Abs(percentage) >= percentThreshold){

        Vector3 newLocation=panelLocation;

        if((percentage > 0) && shifted){
          newLocation+= new Vector3(   0,DY,  0  );
          shifted=false;

        }
        else if((percentage  < 0) && !shifted  ){
          newLocation+= new Vector3( 0,-DY,  0  );
          shifted=true;
        }

        // StartCoroutine(SmoothMove(transform.position, newLocation, easing));
        StartCoroutine(SmoothMove(transform.localPosition, newLocation, easing));
        panelLocation=newLocation;
      }else{
        // StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        StartCoroutine(SmoothMove(transform.localPosition, panelLocation, easing));
      }

    }

    public void SwipeUp(){

      float DY= SetWindowTranslationY();
      Vector3 newLocation=panelLocation;
      newLocation+= new Vector3( 0,  DY ,  0  );
      shifted=false;
      // StartCoroutine(SmoothMove(transform.position, newLocation, easing));
      StartCoroutine(SmoothMove(transform.localPosition, newLocation, easing));
      panelLocation=newLocation;
    }

    IEnumerator SmoothMove(Vector3 start, Vector3 end, float seconds){
      float t= 0.0f;
      while(t <= 1.0){
        t+=Time.deltaTime/seconds;
        // transform.position=Vector3.Lerp(start,end,Mathf.SmoothStep(0.1f,1f,t));
        transform.localPosition=Vector3.Lerp(start,end,Mathf.SmoothStep(0.1f,1f,t));
        yield return null;
      }
    }
}
