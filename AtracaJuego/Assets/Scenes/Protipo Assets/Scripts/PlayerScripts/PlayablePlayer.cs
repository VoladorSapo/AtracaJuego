using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayablePlayer : PlayerBase
{
    


    public override void Update()
    {
        if (SPM.currentPlayer == teamNumb && SPM.Activated && !moving)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (GC.isWakable(Camera.main.ScreenToWorldPoint(Input.mousePosition),true))
                {
                    Move(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }

            }
        }
        base.Update();
    }

    void OnMouseDown()
    {
        if (SPM.Activated)
        {
            SPM.ChangePlayer(teamNumb);
            //GC.setReachablePos(transform.position, MaxDistance, true);
        }
    }
    public override void pressWinTile()
    {
        _gamecontroller.winTilePressed();
    }
    public override void startTurn()
    {
        GC.setReachablePos(transform.position, MaxDistance, true,true);

    }
}
