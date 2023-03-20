using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3 : PlayerBase
{
   // public ScriptPlayerManager SPM;
    public GridController GC;
    [SerializeField] private int MaxDistance = 3;

    protected override void MoveClick(){
        if(SPM.Player3 && GC.canMoveHere && GC.distanceRun<=MaxDistance){
        base.MoveClick();
        }
    }

    void OnMouseDown(){
        SPM.Player1=false;
        SPM.Player2=false;
        SPM.Player3=true;
    }
}
