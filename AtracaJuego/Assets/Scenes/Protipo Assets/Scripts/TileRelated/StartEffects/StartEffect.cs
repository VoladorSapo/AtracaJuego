using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEffect : MonoBehaviour
{
    public StartWet SW;
    void Start(){
        SW=FindObjectOfType<StartWet>();
    }
    public void StartEff(){
        if(SW!=null){SW.Starting();}
    }
}
