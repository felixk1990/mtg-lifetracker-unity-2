using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CounterMenu : MonoBehaviour
{

  public int numberCounters;
  public int numberID;
  public GameObject player_id;
  public GameObject myPrefab;
  public GameObject playerCounter;
  public GameObject playerCounterIcon;
  public GameObject playerCounterText;

  public Color32[] myColors= new Color32[] { new Color32(0,0,0,100), new Color32(125,0,255,255), new Color32(0,0,255,255), new Color32(255,0,0,255),new Color32(255,0,255,255), new Color32(255,125,0,255), new Color32(0,255,200,255),new Color32(255,255,255,255), new Color32(255,255,0,255), new Color32(0,255,0,255)  };
  public int mycolorID;

  void Start(){

    numberCounters=1;
    numberID=1;
    mycolorID=0;
  }

  public void CreateCounterPanel(string counterID){

    numberCounters+=1;
    numberID+=1;

    myPrefab = Resources.Load<GameObject>("PreFabs/PlayerCounter");
    playerCounter = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    playerCounter.transform.SetParent(  gameObject.transform , false);
    playerCounter.GetComponent<CounterMechanics>().InitPlayerCounter( counterID , numberID);

    if(numberCounters> 1){
      ResizeCounterPanels();
      ResizeCounterIcons();
      RecolorCounterPanels(mycolorID);
    }
  }

  public void ResizeCounterPanels(){

      float c=(float)numberCounters;
      int num_children= transform.childCount;
      int i=0;
      // for( int i=0 ; i < num_children; i++){
      foreach( Transform T in transform){

        // playerCounter = transform.GetChild(i).gameObject;
        // RectTransform mytransform =  playerCounter.GetComponent<RectTransform>();
        RectTransform mytransform =  T.gameObject.GetComponent<RectTransform>();

        mytransform.anchorMin= new Vector2(i/c,0);
        mytransform.anchorMax= new Vector2((i+1)/c,1);
        mytransform.offsetMin= new Vector2(0,0);
        mytransform.offsetMax= new Vector2(0,0);
        i+=1;
      }
  }

  public void ResizeCounterIcons(){

        float c=(float)numberCounters;
        // int num_children= transform.childCount;
        foreach( Transform T in transform){
          playerCounter = T.gameObject;
          RectTransform mytransform =  T.Find("ButtonCounter").gameObject.GetComponent<RectTransform>();
        // for( int i=0 ; i < num_children; i++){
        //

          // playerCounterIcon = playerCounter.transform.Find("ButtonCounter").gameObject;
          // RectTransform mytransform = playerCounterIcon.GetComponent<RectTransform>();

          mytransform.anchorMin= new Vector2(0.5f,0.2f);
          mytransform.anchorMax= new Vector2(0.5f,0.2f);

          float scaleXY=GlobalSet.SetScaleXY(playerCounter, 0.1f);
          mytransform.offsetMin= new Vector2(-scaleXY,-scaleXY);
          mytransform.offsetMax= new Vector2(scaleXY,scaleXY);

        }
  }

  public void RecolorCounterPanels( int colorID ){

    Debug.Log(colorID);
    Debug.Log(  mycolorID);
    mycolorID=colorID;
    Debug.Log(  mycolorID);
    int num_children= transform.childCount;

    for( int i=0 ; i < num_children; i++){

      playerCounter = transform.GetChild(i).gameObject;
      playerCounter.GetComponent<Image>().color= myColors[colorID];

      if(colorID >= 3){
        colorCounterText(Color.black);
        if(i==0){
          colorCounterIcon(Color.black);
        }else{
            colorCounterIcon(myColors[colorID]);
          }
      }else{
        colorCounterText(Color.white);
        colorCounterIcon(Color.white);
          }
    }
    }

  public void colorCounterText(Color32 colorMe){
      playerCounterText = playerCounter.transform.Find("Counter").gameObject;
      playerCounterText.GetComponent<TextMeshProUGUI>().color=colorMe;
    }

  public void colorCounterIcon(Color32 colorMe){
      playerCounterIcon = playerCounter.transform.Find("ButtonCounter/CounterIcon").gameObject;
      playerCounterIcon.GetComponent<Image>().color=colorMe;
    }

  public void DeleteCounterPanel(int buttonID){

    int counterID;
    int i=0;
    int j=0;
    numberCounters-=1;
    foreach( Transform T in transform){

      counterID = T.gameObject.GetComponent<CounterMechanics>().ID;
      if( counterID == buttonID ){
        j=i;
      }
      i++;

    }
    DestroyImmediate(transform.GetChild(j).gameObject);
    ResizeCounterPanels();
    ResizeCounterIcons();
  }

  public void StartCounterMenu(){

    GameObject playerPanel= gameObject.transform.parent.gameObject;
    GameObject parentPanel=  playerPanel.transform.parent.gameObject;
    GameObject counterPanel=parentPanel.GetComponent<LoadPlayers>().CounterPanel;

    counterPanel.SetActive(true);
    counterPanel.transform.Find("ButtonGrid").gameObject.GetComponent<CallCounterMenu>().player_id=player_id;

  }
  public void StartColorMenu(){

    GameObject playerPanel= gameObject.transform.parent.gameObject;
    GameObject parentPanel=  playerPanel.transform.parent.gameObject;
    GameObject colorPanel=parentPanel.GetComponent<LoadPlayers>().ColorPanel;

    colorPanel.SetActive(true);
    colorPanel.GetComponent<CallCounterMenu>().player_id=player_id;

  }
}
