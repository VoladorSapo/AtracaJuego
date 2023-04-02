using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using System.Linq;
public class Ignacio : PlayablePlayer
{
    public GameObject FirePrefab;

    //Vector3Int posGrid = _GC.grid.WorldToCell(transform.position);
       //_GC.tiles[posGrid.x-_GC.ogx, posGrid.y-_GC.ogy].setPlayer(this); //Hacer esto para inicializar

    // Update is called once per frame
    public override void Update()
    {   
        base.Update();
        if(Input.GetMouseButtonDown(0) && Cooldown==0 && SPM.currentPlayer==teamNumb && Mode ==2){
            Vector3Int posMouse=GC.GetMousePosition();
            if(!GC.isEmpty(posMouse, false, 2)){
                Vector3Int posNew=posMouse*10+new Vector3Int(5,5,0); //*10 por el tamaño de las tiles + offset de (10/2,10/2,0)=(5,5,0)
                Instantiate(FirePrefab, posNew, Quaternion.identity);
                 hasAttack= true;
                if (hasMove)
                {
                   // SPM.endTurn(teamNumb, false);
                }
                else
                {
                    ChangeMapShown(1);
                }
                //FireCooldown++;
                //_SPM.CanAttack[0]=false;
            }
        }
    }

    protected override void ChangeMapShown(int setMode){
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
    /* if(AttackMode){AttackMode=false; GC.setAttackPos(transform.position, 1, true, true, false, 2, true); GC.setReachablePos(transform.position, SPM.MaxDistancePlayers[teamNumb], true,true,false,false);}
            else{AttackMode=true; GC.setAttackPos(transform.position, 1, true, true, false, 2, false); GC.setReachablePos(transform.position, SPM.MaxDistancePlayers[teamNumb], true,true,true,true);}*/
}
    
