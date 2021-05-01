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

    Debug.Log(player_id.name);
    // player_id.transform.Find("PlayerPanel(Clone)/CounterHolder").GetComponent<CounterMenu>().CreateCounterPanel(counterID);

  }

}
