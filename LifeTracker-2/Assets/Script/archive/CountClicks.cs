using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountClicks : MonoBehaviour
{
    public int counter ;
    public int counter_id;
    public GameObject myTextgameObject;
    public Text ourComponent;
    // Start is called before the first frame update
    void Start()
    {
        counter = global_settings.startLifePlayers;
        UpdateLife();
    }

    public void ButtonClickLifeDown()
    {
       counter=counter-1;
       UpdateLife();

    }
    public void ButtonClickLifeUp()
    {
       counter=counter+1;
       UpdateLife();
    }

    void UpdateLife()
    {
      ourComponent = myTextgameObject.GetComponent<Text>();
      ourComponent.text= counter.ToString();
    }

}
