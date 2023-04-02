using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Player1 : PlayablePlayer
{   
    protected override void ChangeMapShown(int setMode)
    {
        Mode = setMode;
        if (Mode == 1)
        {
            print("move");
            GC.setAttackPos(transform.position, 1, true, true, false, 1, true);
            GC.setReachablePos(transform.position, SPM.MaxDistancePlayers[teamNumb], true, true, false, false);
        }
        else if (Mode == 2) { GC.setAttackPos(transform.position, 1, true, true, false, 1, false); GC.setReachablePos(transform.position, SPM.MaxDistancePlayers[teamNumb], true, true, true, true); }
        else
        {
            GC.setAttackPos(transform.position, 1, true, true, false, 1, true); GC.setReachablePos(transform.position, SPM.MaxDistancePlayers[teamNumb], true, true, true, true);
        }
    }
}

