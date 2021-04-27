using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class main_menu : MonoBehaviour
{

  public GameObject PauseMenu;

  void Awake() {
      Screen.sleepTimeout = SleepTimeout.NeverSleep;
      global_settings.DisableAutoRotationFromLandscape();

  }

  public void QuitGame()
  {

    Application.Quit();

  }
  public void Pause()
  {

    PauseMenu.SetActive(true);
    global_settings.DisableAutoRotationFromLandscape();
  }
  public void UnPauseInPortrait()
  {

    PauseMenu.SetActive(false);
    global_settings.DisableAutoRotationFromPortrait();
  }

  public void UnPauseInLandscape()
  {

    PauseMenu.SetActive(false);
    global_settings.DisableAutoRotationFromLandscape();
  }
}
