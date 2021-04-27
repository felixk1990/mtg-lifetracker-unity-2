using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PageSwipeObject : MonoBehaviour , IDragHandler, IEndDragHandler
{

    private Vector3 panelLocation;
    public float percentThreshold=0.2f;
    public float easing=0.5f;
    public bool shifted=false;
    // Start is called before the first frame update
    void Start()
    {
      panelLocation=transform.position;

    }

    public void OnDrag( PointerEventData data){

      float dx=  data.position.x - data.pressPosition.x;
      if((dx > 0) && shifted){
        transform.position= panelLocation + new Vector3 (dx,0,0);
      }  else if((dx  < 0) && !shifted  ){
        transform.position= panelLocation + new Vector3 (dx,0,0);
      }
    }

    public void OnEndDrag( PointerEventData data){

      float dx=  data.position.x - data.pressPosition.x;
      float DX=Screen.width;
      float percentage = dx / DX;

      if(Mathf.Abs(percentage) >= percentThreshold){

        Vector3 newLocation=panelLocation;

        if((percentage > 0) && shifted){
          newLocation+= new Vector3( DX,  0,  0  );
          shifted=false;

        }
        else if((percentage  < 0) && !shifted  ){
          newLocation+= new Vector3( -DX,  0,  0  );
          shifted=true;
        }

        StartCoroutine(SmoothMove(transform.position, newLocation, easing));
        // transform.position=newLocation;
        panelLocation=newLocation;
      }else{
        // transform.position=panelLocation;
        StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
      }
      // panelLocation=transform.position;

    }

    public void SwipeRight(){
      float DX=Screen.width;
      Vector3 newLocation=panelLocation;
      newLocation+= new Vector3( DX,  0,  0  );
      shifted=false;
      StartCoroutine(SmoothMove(transform.position, newLocation, easing));
      panelLocation=newLocation;
    }

    IEnumerator SmoothMove(Vector3 start, Vector3 end, float seconds){
      float t= 0.0f;
      while(t <= 1.0){
        t+=Time.deltaTime/seconds;
        transform.position=Vector3.Lerp(start,end,Mathf.SmoothStep(0.1f,1f,t));
        yield return null;
        // yield return new WaitForSeconds(1f);
      }
    }
}
