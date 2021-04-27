using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelChanger : MonoBehaviour
{

  public Animator animator;
    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {

      for(int i=0; i<5 ; i++){

        if(global_settings.startNumberPlayers==i){

          SceneManager.LoadScene("Option_Player"+i);

        }
      }
    }

    public void BackToMainMenu(){

        SceneManager.LoadScene(0);

      }
      
    public void FadeToLevel(){

      animator.SetTrigger("Fading");

    }
    public void FadeToMain(){

      animator.SetTrigger("FadeToMain");

    }
}
