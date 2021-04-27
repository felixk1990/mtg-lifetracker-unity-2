using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadPlayer : MonoBehaviour
{
  public GameObject myPrefab;
  public GameObject parent;
  public GameObject playerPanel;
  public GameObject LifeTracker;
  // Start is called before the first frame update
  void Start()
  {

    parent=GameObject.Find("ScreenCanvas");
    myPrefab = Resources.Load<GameObject>("PreFab/PlayerPanel");
    playerPanel = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    playerPanel.transform.SetParent(  parent.transform , false);
    ResizePanel(playerPanel, parent);

    myPrefab = Resources.Load<GameObject>("PreFab/LifeTracker");
    LifeTracker = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    LifeTracker.transform.SetParent(  playerPanel.transform , false);
    ResizeTracker(LifeTracker);

  }

  public void ResizePanel(GameObject G, GameObject parent){

    RectTransform mytransform = G.GetComponent<RectTransform>();
    RectTransform mymomstransform = parent.GetComponent<RectTransform>();

    mytransform.anchorMin= new Vector2(0,0);
    mytransform.anchorMax= new Vector2(1,1);
    mytransform.offsetMin= new Vector2(0,0);
    mytransform.offsetMax= new Vector2(mymomstransform.rect.width,0);
    // mytransform.SetInsetAndSizeFromParentEdge(mymomstransform.Right,0,0);
    // Vector2 sizeRect= mytransform.sizeDelta;
    // Debug.Log(sizeRect);
    // mytransform.sizeDelta = new Vector2(1000 ,sizeRect.y);

  }

  public void ResizeTracker(GameObject G){

    RectTransform mytransform = G.GetComponent<RectTransform>();

    mytransform.anchorMin= new Vector2(0,0);
    mytransform.anchorMax= new Vector2(1.0f/2,1);
    mytransform.offsetMin= new Vector2(0,0);
    mytransform.offsetMax= new Vector2(0,0);

  }
}
