using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_mechanics : MonoBehaviour
{
    public int button_id;
    public int lifePoints;
    public int numberPlayers;
    
    public void SetNumberPlayers(){

      global_settings.startNumberPlayers=numberPlayers;

    }

    public void SetLifePlayers(){

      global_settings.startLifePlayers=lifePoints;

    }
}
