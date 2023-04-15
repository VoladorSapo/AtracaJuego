using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScript : MonoBehaviour
{
    public PlayerBase player;
    
    void Awake(){
        player = GetComponentInParent<PlayerBase>();
    }

    void StartPrefab(){
        player.InstantiatePrefab();
    }

    void CheckNext(){
        player.CheckNext();
    }

    void BeIdle(){
        player.BeIdle();
    }

    void SetDead(){
        if(player.tag=="Player"){player.SetSpriteDead();}
        else{player.DieNow();}
    }
}
