using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : PlayerBase
{
    public ScriptPlayerManager SPM;
    public GridController GC;

    protected override void MoveClick(){
        if(SPM.Player1 && GC.canMoveHere){
        base.MoveClick();
        }
    }

    void OnMouseDown(){
        SPM.Player1=true;
        SPM.Player2=false;
    }
}
