using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
  void Start() {

  }

  public void QuitGame()
  {
    Application.Quit();
  }
  public void LoadMain(){
    SceneManager.LoadScene(0);
  }
  public void RestartGame(){

  SceneManager.LoadScene(GlobalSet.startLevelID);
  }

}
