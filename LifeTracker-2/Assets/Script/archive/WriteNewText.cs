using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WriteNewText : MonoBehaviour
{

    public TextMeshProUGUI mtext;
    public string newText;
    public GameObject myObject;
    // Start is called before the first frame update
    void Start()
    {
      myObject = transform.Find("text").gameObject;
      mtext= myObject.GetComponent<TextMeshProUGUI>();
      Debug.Log(mtext.text);
      RewriteHistory();
    }

    public void RewriteHistory(){
      myObject = transform.Find("text").gameObject;
      mtext= myObject.GetComponent<TextMeshProUGUI>();
      int myLife=40;
      newText=myLife.ToString();
      mtext.text=newText;
      Debug.Log(newText);

    }


}
