using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        global_settings.DisableAutoRotationFromPortrait();
    }

}
