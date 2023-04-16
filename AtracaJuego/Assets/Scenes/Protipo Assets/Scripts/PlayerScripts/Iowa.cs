using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iowa : PlayablePlayer
{

    public GameObject PushPrefab;
    public Vector3Int posMouse;
    private int x, y;

    protected override void Awake()
    {
        base.Awake();
        effect = -1;
    }
    public override void Update()
    {

        base.Update();
        Vector3Int tileO = GC.grid.WorldToCell(transform.position);
        x = tileO.x - GC.ogx;
        y = tileO.y - GC.ogy;
        if (Input.GetMouseButtonDown(0) && Cooldown == 0 && SPM.currentPlayer == teamNumb && Mode == 2 && !SPM._gameController.Pause)
        {
            posMouse = GC.GetMousePosition();
            if (!GC.isEmpty(posMouse, false, 2))
            {
                Cooldown = 1;
                CustomTileClass tile = GC.tiles[tileO.x - GC.ogx, tileO.y - GC.ogy];
                CustomTileClass tile2 = GC.tiles[posMouse.x - GC.ogx, posMouse.y - GC.ogy];
                CDH.AttackDialogue(GetType().ToString(), tile, tile2);

                animator.SetInteger("Anim", 2);

            }
        }
    }

    public void StartRage(int dir)
    {
        StartCoroutine(RageOn(dir));
    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        //if(){}
        switch (other.name)
        {
            case "ElecPrefab(Clone)": StartCoroutine(RageOn(other.GetComponent<PushEffect>().direction)); break;
        }
    }
    public override void InstantiatePrefab()
    {
        Vector3Int posNew = posMouse * 10 + new Vector3Int(5, 5, 0); //*10 por el tamaño de las tiles + offset de (10/2,10/2,0)=(5,5,0)

        Vector3 directionVec = posMouse - GC.grid.WorldToCell(transform.position);
        int x = (int)directionVec.x;
        int y = (int)directionVec.y;
        Vector2 dir = new Vector2(x, y);
        if (Mathf.Abs(x) != Mathf.Abs(y))
        { //A los lados
            PushPrefab.GetComponent<PushEffect>()._iowa = this;
            switch (Mathf.Abs(x))
            {

                case 0:
                    if (y == 1)
                    {
                        PushPrefab.GetComponent<PushEffect>().direction = 3;

                        Instantiate(PushPrefab, posNew, Quaternion.identity);
                    }
                    else
                    {
                        PushPrefab.GetComponent<PushEffect>().direction = 4;
                        Instantiate(PushPrefab, posNew, Quaternion.identity);
                    }
                    break;
                case 1:
                    if (x == 1)
                    {
                        PushPrefab.GetComponent<PushEffect>().direction = 1;
                        sprite.flipX = false;
                        Instantiate(PushPrefab, posNew, Quaternion.identity);
                    }
                    else
                    {
                        PushPrefab.GetComponent<PushEffect>().direction = 2;
                        sprite.flipX = true;
                        Instantiate(PushPrefab, posNew, Quaternion.identity);
                    }
                    break;
            }
        }
        hasAttack = true;
        changeColor();
        if (hasMove)
        {
            // SPM.endTurn(teamNumb, false);
            ChangeMapShown(0);
            hasTurn = true;
        }
        else
        {
            StartCoroutine(ChangeMapWait(1));
        }
        //else{} Las diagonales

        //Instantiate(PushPrefab, posNew, Quaternion.identity);
        //PushCooldown++;
        //_SPM.CanAttack[0]=false;
    }
    public override void ChangeMapShown(int setMode)
    {
        Mode = setMode;
        if (Mode == 1)
        {
            changeCircle(true);
            print("move");
            GC.setAttackPos(transform.position, 1, true, true, false, 1, true);
            GC.setReachablePos(transform.position, MaxDistance, true, true, false, false);
        }
        else if (Mode == 2) { GC.setAttackPos(transform.position, 1, true, true, false, 1, false); GC.setReachablePos(transform.position, MaxDistance, true, true, true, true); changeCircle(true); }
        else
        {
            changeCircle(false);
            print("waka");
            GC.setAttackPos(transform.position, 1, true, true, false, 1, true); GC.setReachablePos(transform.position, MaxDistance, true, true, true, true);
        }
        _turnbuttons.showButtons(this, setMode, !hasMove, !hasAttack);
    }

    IEnumerator RageOn(int direction)
    {
        int dx = 0, dy = 0;
        switch (direction)
        {
            case 1: dx = 1; break;
            case 2: dx = -1; break;
            case 3: dy = 1; break;
            case 4: dy = -1; break;
        }

        WaitForSeconds wfs = new WaitForSeconds(0);
        int speed = 70;
        bool stop = false;
        Vector3 newPos = transform.position + new Vector3(10f * dx, 10f * dy, 0f);
        Vector3Int tileO = GC.grid.WorldToCell(transform.position);
        tileO = GC.grid.WorldToCell(transform.position);
        x = tileO.x - GC.ogx;
        y = tileO.y - GC.ogy;

        GC.tiles[x, y].setPlayer(null);

        if(GC.tiles[x + dx,y + dy].GetPlayer()!=null && GC.tiles[x + dx,y + dy].GetPlayer().tag!="StoneBox"){MM.Damage(0,x+dx,y+dy);}

        if((GC.tiles[x + dx, y + dy].GetTileState() >= 5 && GC.tiles[x + dx, y + dy].GetTileState() != 9 || GC.tiles[x + dx,y + dy].GetPlayer()!=null && (GC.tiles[x + dx,y + dy].GetPlayer().tag=="StoneBox"
        || (GC.tiles[x + dx*2, y + dy*2].GetTileState() >= 5  && GC.tiles[x + dx, y + dy].GetTileState() != 9))
        )){

            if(GC.tiles[x + dx,y + dy].GetPlayer().tag=="StoneBox"){GC.tiles[x + dx,y + dy].GetPlayer().Push(dx,dy,5,48);}

        }
        else{
        while (!stop)
        {
            
            
            transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
            
            if(transform.position == newPos && (GC.tiles[x + dx,y + dy].GetPlayer()!=null && (GC.tiles[x + dx*2, y + dy*2].GetTileState() >= 5  && GC.tiles[x + dx, y + dy].GetTileState() != 9))){
                if(GC.tiles[x + dx,y + dy].GetPlayer()!=null){MM.Damage(0,x+dx,y+dy);} break;
            }else{

            if(GC.tiles[x + dx,y + dy].GetTileState()==9){ PT.PlaceAfterBreak(x,y,dx,dy); break;}
            
            if (transform.position == newPos && (GC.tiles[x + dx, y + dy].GetTileState() < 5 || GC.tiles[x + dx, y + dy].GetTileState() == 9))
            {
                //if(GC.tiles[x + dx,y + dy].GetTileState()==9){GC.tiles[x + dx,y + dy].SetTileStats(1,0,0,0); PT.PlaceAfterBreak(x,y,dx,dy,GC.ogx,GC.ogy);}
                x=GC.grid.WorldToCell(transform.position).x-GC.ogx;
                y=GC.grid.WorldToCell(transform.position).y-GC.ogy;
                if(GC.tiles[x + dx,y + dy].GetPlayer()!=null && GC.tiles[x + dx,y + dy].GetPlayer().tag=="StoneBox"){GC.tiles[x + dx,y + dy].GetPlayer().Push(dx,dy,5,48); break;}
                if(GC.tiles[x + dx,y + dy].GetTileState()==9){ PT.PlaceAfterBreak(x,y,dx,dy); break;}
                if(GC.tiles[x + dx,y + dy].GetPlayer()!=null){MM.Damage(0,x+dx,y+dy);}
                newPos = transform.position + new Vector3(10f * dx, 10f * dy, 0f);
                //if transform.position coincide con una tile rompible, hacer efecto de romper (SetTileStats)
            }
            else if (transform.position == newPos && (GC.tiles[x + dx, y + dy].GetTileState() >= 5 && GC.tiles[x + dx, y + dy].GetTileState() != 9))
            {
                break;
            }
            }

            yield return wfs;
        }
        }
        GC.tiles[x, y].setPlayer(this);
    }


}


