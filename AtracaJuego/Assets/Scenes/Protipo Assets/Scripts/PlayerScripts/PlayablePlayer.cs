using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayablePlayer : PlayerBase
{
    protected int directionPush;
    [SerializeField] protected bool AttackMode;
    protected int Cooldown;
    public override void Update()
    {
        if (SPM.currentPlayer == teamNumb && SPM.Activated && !moving && !AttackMode)
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                if (GC.isEmpty(Camera.main.ScreenToWorldPoint(Input.mousePosition),true,0))
                {
                    Move(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }

            }
        }
        if (Input.GetMouseButtonDown(1) && SPM.currentPlayer==teamNumb)
        { //&& _SPM.currentPlayer==x
            ChangeMapShown();
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
    public override void setGame()
    {
        base.setGame();
        Cooldown = 0;
    }
    protected virtual void ChangeMapShown()
    {

    }

    public override void startTurn()
    {
        GC.setReachablePos(transform.position, SPM.MaxDistancePlayers[teamNumb], true,true,team,false);
        AttackMode = false;
        if (Cooldown > 0) { Cooldown--; }
    }

    

}
