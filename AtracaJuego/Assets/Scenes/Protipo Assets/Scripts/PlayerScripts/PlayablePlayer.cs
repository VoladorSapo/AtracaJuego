using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayablePlayer : PlayerBase
{
    protected int directionPush;
    [SerializeField] public int Cooldown;
    [SerializeField] protected turnButtonsController _turnbuttons;
    protected bool willAttack;
    protected override void Awake()
    {
        base.Awake();
        SPM = GameObject.Find("Controller").GetComponent<ScriptPlayerManager>();
        _turnbuttons = GameObject.Find("TurnButtons").GetComponent<turnButtonsController>();
    }
    protected override void OnTriggerEnter2D(Collider2D other){}
    public override void Update()
    {
        if (SPM.currentPlayer == teamNumb && SPM.Activated && !moving && Mode == 1)
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && !SPM._gameController.Pause)
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
        if (Input.GetMouseButtonDown(1) && SPM.currentPlayer==teamNumb&& SPM.Activated && !moving && !SPM._gameController.Pause)
        { 
            int newMode = (Mode + 1) % 3;
            if(!hasAttack || !hasMove){
            if(hasAttack && newMode==2){newMode=0;}
            if(hasMove && newMode==1){newMode=2;}
            }else{newMode=0;}
            
            
            ChangeMapShown(newMode);
        }
        base.Update();
    }

    void OnMouseDown()
    {
        if (alive && SPM.Activated && SPM.players[SPM.currentPlayer].Mode == 0)
        {
            print("yotoyroyt" +name+teamNumb);
            CDH.SelectDialogue(GetType().ToString());
            SPM.ChangePlayer(teamNumb);
            //GC.setReachablePos(transform.position, MaxDistance, true);
        }
    }

    public override void pressWinTile()
    {
        print("olebeti");
        _gamecontroller.winTilePressed();
    }
    public override void setGame()
    {
        willAttack=false;
        base.setGame();
        if (Cooldown > 0) { Cooldown--; }
    }
    public override void setDeath()
    {
        base.setDeath();
    }
    public override void setTurn(bool newTurn)
    {
        print("movidas chungas");
        // base.setTurn(newTurn);
        if (!stunned)
        {
            willAttack = false;
            hasTurn = false;
            hasMove = false;
            hasAttack = Cooldown > 1 ? true : false;
        }
        else
        {
            hasAttack = hasMove = hasTurn = true;
            print("loquisimo");
            stunned = false;
        }
        changeColor();
        if (Cooldown > 0) { Cooldown--;  }
    }
    
    public override void ChangeMapShown(int setPos)
    {

    }
    public override void changeColor()
    {
        if (hasAttack && hasMove)
        {
            sprite.color = _color;
        }
        else
        {
            sprite.color = new Color(255, 255, 255);
        }
    }
    public override void startTurn()
    {
        //GC.setReachablePos(transform.position, SPM.MaxDistancePlayers[teamNumb], true,true,team,false);
        print("hey");
        if (hasMove && hasAttack)
        {
            ChangeMapShown(0);
        }
        else if (!hasMove)
        {
            ChangeMapShown(1);
        }
        else
        {
            ChangeMapShown(2);
        }
      
    }

    IEnumerator skipturn()
    {
        yield return new WaitForEndOfFrame();
        SPM.nextTurn(teamNumb, false);

    }

    public void Revive(PlayerBase player)
    {
        player.alive = true;
        //Vector3Int tilepos = GC.grid.WorldToCell(transform.position);
        //CustomTileClass tile = GC.tiles[tilepos.x -GC.ogx, tilepos.y -GC.ogy];
        //tile.setPlayer(null);
        hasAttack = hasTurn = hasMove = false;
        currentHealth = maxHealth;
        player.animator.enabled=true;
        player.animator.SetInteger("Anim", 0);

        SPM.revive(this);
        
        //player.sprite.enabled = true;
    }
}
