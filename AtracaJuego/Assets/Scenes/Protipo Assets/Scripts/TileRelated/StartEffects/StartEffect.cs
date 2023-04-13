using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEffect : MonoBehaviour
{
    public StartWet[] SW;
    void Start(){
        SW=FindObjectsOfType<StartWet>();
    }
    public void StartEff(){
        if(SW.Length > 0){
            foreach (StartWet sws in SW)
            {
                sws.Starting();
            }
}
    }
}
