using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite : MonoBehaviour
{
    public PlayerBase player;
    
    void Awake(){
        player = GetComponentInParent<PlayerBase>();
    }

    void StartPrefab(){
        player.InstantiatePrefab();
    }
}
