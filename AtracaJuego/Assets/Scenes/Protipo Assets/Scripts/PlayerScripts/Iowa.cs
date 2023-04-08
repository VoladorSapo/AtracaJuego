using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iowa : PlayablePlayer
{
    
    public GameObject PushPrefab;
    public Vector3Int posMouse;
    private int x,y;

    protected override void Awake()
    {
        base.Awake();
        effect=-1;
    }
    public override void Update()
    {   

        base.Update();
        Vector3Int tileO = GC.grid.WorldToCell(transform.position);
        x=tileO.x-GC.ogx;
        y=tileO.y-GC.ogy;
        if(Input.GetMouseButtonDown(0) && Cooldown==0 && SPM.currentPlayer==teamNumb && Mode == 2)
        {
            posMouse=GC.GetMousePosition();
            if(!GC.isEmpty(posMouse, false, 2)){
                Cooldown=1;
                animator.SetInteger("Anim", 2);

            }
        }
        }

        public void StartRage(int dir){
            StartCoroutine(RageOn(dir));
        }
        protected override void OnTriggerEnter2D(Collider2D other){
            //if(){}
            switch(other.name){
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
        
        if (hasMove)
        {
            // SPM.endTurn(teamNumb, false);
            ChangeMapShown(0);
            hasTurn = true;
        }
        else
        {
            ChangeMapShown(1);
        }
        //else{} Las diagonales

        //Instantiate(PushPrefab, posNew, Quaternion.identity);
        //PushCooldown++;
        //_SPM.CanAttack[0]=false;
    }
    public override void ChangeMapShown(int setMode){
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
            print("waka");
            GC.setAttackPos(transform.position, 1, true, true, false, 1, true); GC.setReachablePos(transform.position, SPM.MaxDistancePlayers[teamNumb], true, true, true, true);
        }
        _turnbuttons.showButtons(this,setMode,!hasMove,!hasAttack);
        }

        IEnumerator RageOn(int direction){
        int dx=0, dy=0;
        switch(direction){
            case 1: dx=1; break;
            case 2: dx=-1; break;
            case 3: dy=1; break;
            case 4: dy=-1; break;
        }

        WaitForSeconds wfs=new WaitForSeconds(0);
        int speed=60;
        bool stop=false;
        Vector3 newPos=transform.position+new Vector3(10f*dx,10f*dy,0f);
        Vector3Int tileO = GC.grid.WorldToCell(transform.position);
        GC.tiles[x,y].setPlayer(null);
        
        while(!stop){
            tileO = GC.grid.WorldToCell(transform.position);
            x=tileO.x-GC.ogx;
            y=tileO.y-GC.ogy;
            transform.position = Vector3.MoveTowards(transform.position, newPos, speed*Time.deltaTime);
            if(transform.position==newPos && (GC.tiles[x+ dx,y + dy].GetTileState()<5 || GC.tiles[x+ dx,y + dy].GetTileState()==9 || GC.tiles[x+ dx,y + dy].GetTileState()==11)){
                newPos=transform.position+new Vector3(10f*dx,10f*dy,0f); 
                //if transform.position coincide con una tile rompible, hacer efecto de romper (SetTileStats)
                }
            else if(transform.position==newPos && (GC.tiles[x + dx,y + dy].GetTileState()>=5 || GC.tiles[x+ dx,y + dy].GetTileState()!=9 || GC.tiles[x+ dx,y + dy].GetTileState()!=11)){
                 stop=true;}
            
            yield return wfs;
        }
        GC.tiles[x,y].setPlayer(this);
        }

        
    }


