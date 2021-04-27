using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CustomLife : MonoBehaviour
{
  public void SetPlayerLifeCustom()
  {
    string customLife = gameObject.GetComponent<TMP_InputField>().text;

    GameObject myMenu = GameObject.Find("StarterMenu");
    myMenu.GetComponent<MainMenu>().SetPlayerLife(int.Parse(customLife));

  }

}
