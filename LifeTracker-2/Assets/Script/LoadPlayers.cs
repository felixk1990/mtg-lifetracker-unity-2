using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayers : MonoBehaviour
{
    public int start_life;
    public int num_players;
    public float rotation;

    public GameObject myPrefab;
    public GameObject parent;
    public GameObject playerPanel;
    public GameObject CounterPanel;
    public GameObject ColorPanel;

    // Start is called before the first frame update
    void Start()
    {
      Invoke("LoadPlayer", 0.05f);
    }

    public void LoadPlayer(){

      parent=gameObject;
      rotation = transform.eulerAngles.z;
      ResizeParent(parent);

      myPrefab = Resources.Load<GameObject>("PreFabs/PlayerPanel");
      playerPanel = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
      playerPanel.transform.SetParent(  parent.transform , false);
      ResizePanel(playerPanel, parent);

      GameObject myCounter= playerPanel.transform.Find("CounterHolder/PlayerCounter").gameObject;
      myCounter.GetComponent<CounterMechanics>().InitPlayerLife();
      myCounter= playerPanel.transform.Find("CounterHolder").gameObject;
      myCounter.GetComponent<CounterMenu>().ResizeCounterIcons();
      myCounter.GetComponent<CounterMenu>().player_id=gameObject;
      ResizeIconHolders();
      // ResizeIconMenu();

    }
    public void ResizePanel(GameObject G, GameObject parent){

      RectTransform mytransform = G.GetComponent<RectTransform>();
      RectTransform mymomstransform = parent.GetComponent<RectTransform>();

      mytransform.anchorMin= new Vector2(0,0);
      mytransform.anchorMax= new Vector2(1,1);
      mytransform.offsetMin= new Vector2(0,0);
      mytransform.offsetMax= new Vector2(0,mymomstransform.rect.height);

    }
    public void ResizeIconHolders(){

      GameObject myMenu= playerPanel.transform.Find("CustomInGame").gameObject;
      for( int i=0; i< myMenu.transform.childCount;i++  ){

          GameObject myIconHolder= myMenu.transform.GetChild(i).Find("IconHolder").gameObject;
          RectTransform mytransform = myIconHolder.GetComponent<RectTransform>();

          mytransform.anchorMin= new Vector2(0.5f,0.4f);
          mytransform.anchorMax= new Vector2(0.5f,0.4f);

          float scaleXY=  GlobalSet.SetScaleXY(myMenu.transform.GetChild(i).gameObject, 0.3f);
          mytransform.offsetMin= new Vector2(-scaleXY,-scaleXY);
          mytransform.offsetMax= new Vector2(scaleXY,scaleXY);
      }
    }

    public void ResizeIconMenu(){

      Vector2 u;
      GameObject myMenu= playerPanel.transform.Find("ChooseACounter/ButtonGrid").gameObject;
      for( int i=0; i< myMenu.transform.childCount;i++  ){

          GameObject myIconHolder= myMenu.transform.GetChild(i).gameObject;
          RectTransform mytransform = myIconHolder.GetComponent<RectTransform>();


          u=GlobalSet.GetAnchorCenter(mytransform);
          mytransform.anchorMin= new Vector2(u.x,u.y);
          mytransform.anchorMax= new Vector2(u.x,u.y);

          float scaleXY=GlobalSet.SetScaleXY(myMenu,0.08f);
          mytransform.offsetMin= new Vector2(-scaleXY,-scaleXY);
          mytransform.offsetMax= new Vector2(scaleXY,scaleXY);
      }
      myMenu= playerPanel.transform.Find("ChooseACounter").gameObject;
      myMenu.SetActive(false);
    }

    public void ResizeParent(GameObject parent){

      if(rotation==90 | rotation==270){

        RectTransform mytransform = parent.GetComponent<RectTransform>();

        GameObject myScaler = GameObject.Find("ScalePanel");
        RectTransform myScalerTransform = myScaler.GetComponent<RectTransform>();
        mytransform.sizeDelta = new Vector2(  myScalerTransform.rect.size.y,  myScalerTransform.rect.size.x);

      }
    }

}
