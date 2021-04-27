using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

  public GameObject Menu;
  public GameObject LifeMenu;
  public GameObject PlayerMenu;
  public GameObject Player3;
  public GameObject Player2;

  void Awake() {
      Screen.sleepTimeout = SleepTimeout.NeverSleep;
      GlobalSet.DisableAutoRotationFromPortrait();
  }

  public void QuitGame()
  {
    Application.Quit();
  }
  public void NewGame()
  {
    LifeMenu.SetActive(true);
    Menu.SetActive(false);
  }

  public void SetPlayerLife(int counterID)
  {
    GlobalSet.startLifePlayers=counterID;
    PlayerMenu.SetActive(true);
    LifeMenu.SetActive(false);
  }

  public void SetPlayerNum( int counterID )
  {
    GlobalSet.startNumberPlayers=counterID;
    PlayerMenu.SetActive(false);
    if(counterID==2){
      Player2.SetActive(true);
    }else if(counterID==3){
      Player3.SetActive(true);
    }else{
      LoadPlayerLevel(counterID );
    }
  }

  public void SetPlayerSeating( int levelID )
  {
      LoadPlayerLevel(levelID );
  }

  public void LoadPlayerLevel( int levelID ){
    GlobalSet.startLevelID=levelID;
    SceneManager.LoadScene(levelID);
  }



}
