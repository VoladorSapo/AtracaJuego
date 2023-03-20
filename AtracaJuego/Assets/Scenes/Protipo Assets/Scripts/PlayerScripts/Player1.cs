using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Player1 : PlayerBase
{   
    //public ScriptPlayerManager SPM;
    //public ScriptPlayerManager SPM;
    public GridController GC;
    [SerializeField] private int MaxDistance = 5;

    protected override void MoveClick(){
        if(SPM.Player1 && GC.canMoveHere && GC.distanceRun<=MaxDistance){
        base.MoveClick();
        }
    }

    void OnMouseDown(){
        SPM.Player1=true;
        SPM.Player2=false;
        SPM.Player3=false;
    }

}
