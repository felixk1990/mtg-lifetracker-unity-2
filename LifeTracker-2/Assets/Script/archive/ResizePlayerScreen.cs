using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResizePlayerScreen : MonoBehaviour
{

  public GameObject PlayerPanel;
  public GameObject LifeTicker;
  public int objectsCounter=0;
  // Start is called before the first frame update
  void Start()
  {
    PlayerPanel=GameObject.Find("PlayerPanel");
    LifeTicker=GameObject.Find("Life");

  }
  public void ResizeScreen(){

    objectsCounter+=1;
    ResizeLifeTicker();
    ResizeCounterPanels();
    CreateCounterPanel();

  }

  public void ResizeLifeTicker(){

    RectTransform mytransform = LifeTicker.GetComponent<RectTransform>();
    float c=(float)objectsCounter;
    mytransform.anchorMin= new Vector2(0,0);
    mytransform.anchorMax= new Vector2(1.0f/(c+1),1);
    mytransform.offsetMin= new Vector2(0,0);
    mytransform.offsetMax= new Vector2(0,0);

  }
  public void ResizeCounterPanels(){

    if(objectsCounter > 1){

      float c=(float)objectsCounter;

      for( int i=1 ; i < objectsCounter; i++){

        GameObject Counter = GameObject.Find( "Counter"+i.ToString() );
        RectTransform mytransform =  Counter.GetComponent<RectTransform>();

        mytransform.anchorMin= new Vector2(i/(c+1),0);
        mytransform.anchorMax= new Vector2((i+1)/(c+1),1);
        mytransform.offsetMin= new Vector2(0,0);
        mytransform.offsetMax= new Vector2(0,0);

      }
    }
  }

  public void CreateCounterPanel(){

    float c=(float)objectsCounter;
    GameObject CounterPanel= new GameObject();
    CounterPanel.name="Counter"+objectsCounter.ToString();
    CounterPanel.transform.SetParent(  PlayerPanel.transform , false);
    CounterPanel.AddComponent<Image>();
    CounterPanel.GetComponent<Image>().color= new Color32(255,255,255,255);

    RectTransform mynewtransform =CounterPanel.GetComponent<RectTransform>();
    mynewtransform.anchorMin= new Vector2(c/(c+1),0);
    mynewtransform.anchorMax= new Vector2(1.0f,1);
    mynewtransform.offsetMin= new Vector2(0,0);
    mynewtransform.offsetMax= new Vector2(0,0);

    CreateSpritePanel(CounterPanel);
  }

  public void CreateSpritePanel(GameObject parent){

    GameObject SpritePanel= new GameObject();
    SpritePanel.AddComponent<Image>();
    Image imageIcon = SpritePanel.GetComponent<Image>();
    Sprite sprite = Resources.Load<Sprite>("CleanVectorIcons/T_5_drop_");
    imageIcon.sprite  =  Resources.Load<Sprite>("CleanVectorIcons/T_5_drop_");

    SpritePanel.transform.SetParent(  parent.transform , false);
    SpritePanel.GetComponent<Image>().color= new Color32(0,255,255,255);

    RectTransform mynewtransform = SpritePanel.GetComponent<RectTransform>();
    mynewtransform.anchorMin= new Vector2(0.4f,0.4f);
    mynewtransform.anchorMax= new Vector2(0.6f,0.6f);
    mynewtransform.offsetMin= new Vector2(0,0);
    mynewtransform.offsetMax= new Vector2(0,0);


  }

}
