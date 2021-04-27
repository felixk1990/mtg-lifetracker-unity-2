using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeLifeColour : MonoBehaviour
{

    public GameObject counter;
    public Image img;
    public int button_id;
    public float easing=0.5f;
    // Start is called before the first frame update
    void Start()
    {
      counter=GameObject.Find("Life");
      img=counter.GetComponent<Image>();
    }

    public void ChangeColor(){

      if(button_id==0){
        img.color=new Color32(255,60,60,255);
      }else if(button_id==1){
          img.color=new Color32(70,255,70,255);
        }

      }

}
