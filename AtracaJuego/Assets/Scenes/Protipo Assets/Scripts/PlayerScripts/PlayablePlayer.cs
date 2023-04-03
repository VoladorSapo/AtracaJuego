using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayablePlayer : PlayerBase
{
    protected int directionPush;
    protected int Cooldown;
    protected bool willAttack;
    protected override void Awake()
    {
        base.Awake();
        SPM = GameObject.Find("Controller").GetComponent<ScriptPlayerManager>();

    }
    protected override void OnTriggerEnter2D(Collider2D other){}
    public override void Update()
    {
        if (SPM.currentPlayer == teamNumb && SPM.Activated && !moving && Mode == 1)
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                if (GC.isEmpty(Camera.main.ScreenToWorldPoint(Input.mousePosition),true,0))
                {
                    Move(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }

            }
            
        }
        if(SPM.currentPlayer == teamNumb && SPM.Activated)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                StartCoroutine("skipturn");
            }
        }
        if (Input.GetMouseButtonDown(1) && SPM.currentPlayer==teamNumb&& SPM.Activated && !moving)
        { //&& _SPM.currentPlayer==x
            int newMode = (Mode + 1) % 3;
            print(Mode);
            print(newMode);
            ChangeMapShown(newMode);
        }
        base.Update();
    }

    void OnMouseDown()
    {
        if (SPM.Activated && SPM.players[SPM.currentPlayer].Mode == 0)
        {
            print("yotoyroyt" +name+teamNumb);
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
        willAttack=false;
        base.setGame();
        Cooldown = 0;
    }
    protected override void ChangeMapShown(int setPos)
    {

    }

    public override void startTurn()
    {
        //GC.setReachablePos(transform.position, SPM.MaxDistancePlayers[teamNumb], true,true,team,false);
        print("hey");
        ChangeMapShown(1);
        willAttack=false;
        hasMove = false;
        hasAttack = false;
        if (Cooldown > 0) { Cooldown--; }
    }

    IEnumerator skipturn()
    {
        yield return new WaitForEndOfFrame();
        SPM.endTurn(teamNumb, false);

    }

    public void Revive(PlayerBase player)
    {
        player.alive = true;
        //Vector3Int tilepos = GC.grid.WorldToCell(transform.position);
        //CustomTileClass tile = GC.tiles[tilepos.x -GC.ogx, tilepos.y -GC.ogy];
        //tile.setPlayer(null);
        player.sprite.enabled = true;
    }
}
