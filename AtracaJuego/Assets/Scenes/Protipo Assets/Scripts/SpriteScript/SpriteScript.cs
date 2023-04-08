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

    void BeIdle(){
        player.BeIdle();
    }

    void SetDead(){
        player.SetSpriteDead();
    }
}
