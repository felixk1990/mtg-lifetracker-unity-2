using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CallCounterMenu : MonoBehaviour
{

  public GameObject player_id;

  void Start(){

  }

  public void CreateCounterPanel(string counterID){

    player_id.transform.Find("PlayerPanel(Clone)/CounterHolder").GetComponent<CounterMenu>().CreateCounterPanel(counterID);
    player_id.transform.Find("PlayerPanel(Clone)").GetComponent<SwipePanels>().SwipeUp();

  }

  public void SetCounterPanelColor(int colorID){

    player_id.transform.Find("PlayerPanel(Clone)/CounterHolder").GetComponent<CounterMenu>().RecolorCounterPanels(colorID);
    player_id.transform.Find("PlayerPanel(Clone)").GetComponent<SwipePanels>().SwipeUp();
  }

}
