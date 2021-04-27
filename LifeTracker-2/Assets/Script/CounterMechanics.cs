using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CounterMechanics : MonoBehaviour
{
    public int counter;
    public int ID=0;
    public GameObject myCounter;
    public TextMeshProUGUI mtext;
    public string newText;


    public void ButtonClickCounterDown()
    {
       counter=counter-1;
       UpdateCounter();

    }
    public void ButtonClickCounterUp()
    {
       counter=counter+1;
       UpdateCounter();
    }

    public void UpdateCounter()
    {
      myCounter = transform.Find("Counter").gameObject;
      mtext= myCounter.GetComponent<TextMeshProUGUI>();
      newText=counter.ToString();
      mtext.text=newText;
    }

    public void InitPlayerLife(){

      counter = GlobalSet.startLifePlayers;
      UpdateCounter();

      GameObject counterIcon = transform.Find("ButtonCounter/CounterIcon").gameObject;
      Sprite sprite = Resources.Load<Sprite>("CustomAssets/VectorIcons2/9-01");
      counterIcon.GetComponent<Image>().sprite=sprite;
      ID=0;

      GameObject ButtonIcon = transform.Find("ButtonCounter").gameObject;
      ButtonIcon.GetComponent<Image>().enabled = false;
    }

    public void InitPlayerCounter(string counterID, int buttonID){

      counter = 0;
      UpdateCounter();
      ID=buttonID;

      GameObject counterIcon = transform.Find("ButtonCounter/CounterIcon").gameObject;
      Sprite sprite = Resources.Load<Sprite>("CustomAssets/VectorIcons1/"+counterID);
      counterIcon.GetComponent<Image>().sprite=sprite;

    }
    public void DeleteThisPanel(){

      GameObject parent= transform.parent.gameObject;
      parent.GetComponent<CounterMenu>().DeleteCounterPanel( ID );
    }


}
