using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MakeArtHappen : MonoBehaviour
{
    public string[] arts= new string[] {"artwork_1","artwork_2","artwork_3","artwork_4","artwork_5","artwork_6","artwork_7","artwork_8","artwork_9","artwork_10"};
    // Start is called before the first frame update
    void Start()
    {

      float rand= Random.value;
      int index = (int) (rand*arts.Length);
      Sprite texture = Resources.Load<Sprite>("CustomAssets/Misc/"+arts[index]);
      Debug.Log(texture);
      gameObject.GetComponent<Image>().sprite = texture;;
      //

    }

    // Update is called once per frame
    void Update()
    {

    }
}
