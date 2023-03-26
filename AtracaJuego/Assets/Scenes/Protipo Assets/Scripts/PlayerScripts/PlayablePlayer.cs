using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayablePlayer : PlayerBase
{

    protected int directionPush;

    void Start(){
        
    }


    public override void Update()
    {
        if (SPM.currentPlayer == teamNumb && SPM.Activated && !moving)
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                if (GC.isEmpty(Camera.main.ScreenToWorldPoint(Input.mousePosition),true))
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
        GC.setReachablePos(transform.position, MaxDistance, true,true,team);

    }

}
