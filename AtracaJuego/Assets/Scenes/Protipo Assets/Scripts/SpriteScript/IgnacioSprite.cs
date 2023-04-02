using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnacioSprite : MonoBehaviour
{
    public Ignacio ignacio;
    
    void Awake(){
    GameObject.Find("Player1").GetComponent<Ignacio>();
    }

    void StartFire(){
        ignacio.InstantiateFirePrefab();
    }
}
