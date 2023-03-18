using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : PlayerBase
{
    //public ScriptPlayerManager SPM;
    public ScriptPlayerManager SPM;
    public GridController GC;

    protected override void MoveClick(){
        if(SPM.Player2 && GC.canMoveHere){
        base.MoveClick();
        }
    }

    void OnMouseDown(){
        SPM.Player1=false;
        SPM.Player2=true;
    }
}
