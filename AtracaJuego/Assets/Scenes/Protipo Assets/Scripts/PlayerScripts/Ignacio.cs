using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using System.Linq;
public class Ignacio : PlayablePlayer
{
    public GameObject FirePrefab;
    private Vector3Int posMouse;

    protected override void Awake()
    {
        base.Awake();
        effect=-1;
    }
    public override void Update()
    {   
        base.Update();
        if(Input.GetMouseButtonDown(0) && Cooldown==0 && SPM.currentPlayer==teamNumb && Mode == 2 && !SPM._gameController.Pause)
        {
            posMouse = GC.GetMousePosition();
            if (!GC.isEmpty(posMouse, false, 2)){
                Cooldown=1;
                Vector3Int tilepos = GC.grid.WorldToCell(transform.position - new Vector3(5f, 5f, 0)) - new Vector3Int(GC.ogx, GC.ogy);

                //print(tilepos);
                CustomTileClass tile = GC.tiles[tilepos.x, tilepos.y];
                CustomTileClass tile2 = GC.tiles[posMouse.x- GC.ogx, posMouse.y- GC.ogy];
                CDH.AttackDialogue(GetType().ToString(),tile,tile2);

                animator.SetInteger("Anim",2);

                /* hasAttack= true;
                if (hasMove)
                {
                   // SPM.endTurn(teamNumb, false);
                }
                else
                {
                    ChangeMapShown(1);
                }
                //FireCooldown++;
                //_SPM.CanAttack[0]=false;*/
            }
        }

    }

    public override void InstantiatePrefab(){
        Vector3Int posNew=posMouse*10+new Vector3Int(5,5,0); //*10 por el tamaño de las tiles + offset de (10/2,10/2,0)=(5,5,0)
        Instantiate(FirePrefab, posNew, Quaternion.identity);
        hasAttack = true;
        changeColor();

        if (hasMove)
        {
            // SPM.endTurn(teamNumb, false);
            hasTurn = true;
            ChangeMapShown(0);
        }
        else
        {
           StartCoroutine(ChangeMapWait(1));
        }
    }
    public override void ChangeMapShown(int setMode){
        Mode = setMode;
        if (Mode == 1)
        {
            print("move");
            GC.setAttackPos(transform.position, 1, true, true, false, 0, true);
            GC.setReachablePos(transform.position,MaxDistance, true, true, false, false);
        }
        else if (Mode == 2) { GC.setAttackPos(transform.position, 1, true, true, false, 0, false); GC.setReachablePos(transform.position, MaxDistance, true, true, true, true); }
        else
        {
            GC.setAttackPos(transform.position, 1, true, true, false, 0, true); GC.setReachablePos(transform.position, MaxDistance, true, true, true, true);
        }
        _turnbuttons.showButtons(this, setMode, !hasMove, !hasAttack);

    }
    /* if(AttackMode){AttackMode=false; GC.setAttackPos(transform.position, 1, true, true, false, 2, true); GC.setReachablePos(transform.position, SPM.MaxDistancePlayers[teamNumb], true,true,false,false);}
            else{AttackMode=true; GC.setAttackPos(transform.position, 1, true, true, false, 2, false); GC.setReachablePos(transform.position, SPM.MaxDistancePlayers[teamNumb], true,true,true,true);}*/


    
}
    
