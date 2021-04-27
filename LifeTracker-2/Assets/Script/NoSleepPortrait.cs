using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSleepPortrait : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake() {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        GlobalSet.DisableAutoRotationFromPortrait();
    }

}
