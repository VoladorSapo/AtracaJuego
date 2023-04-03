using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nev : PlayablePlayer
{
    public GameObject IcePrefab;
    Vector3Int posMouse;
    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if(Input.GetMouseButtonDown(0) && Cooldown==0 && SPM.currentPlayer==teamNumb && Mode == 2)
        {
            posMouse=GC.GetMousePosition();
            Vector3Int posInGrid=GC.grid.WorldToCell(transform.position);
            if(!GC.isEmpty(posMouse, false, 2) && GC.tiles[posMouse.x-GC.ogx,posMouse.y-GC.ogy].player==null){
                //Vector3Int posNew=new Vector3Int(Mathf.FloorToInt(transform.position.x),Mathf.FloorToInt(transform.position.y),0); //*10 por el tamaño de las tiles + offset de (10/2,10/2,0)=(5,5,0)
                Cooldown=3;
                animator.SetInteger("Anim", 2);

            }
        }
    }
    public override void InstantiatePrefab()
    {
        Vector3Int posInGrid = GC.grid.WorldToCell(transform.position);

        //Vector3Int posNew=new Vector3Int(Mathf.FloorToInt(transform.position.x),Mathf.FloorToInt(transform.position.y),0); //*10 por el tamaño de las tiles + offset de (10/2,10/2,0)=(5,5,0)
        for (int i = 1; i >= -1; i--)
        {
            for (int j = 1; j >= -1; j--)
            {
                GC.tiles[posInGrid.x - GC.ogx + i, posInGrid.y - GC.ogy + j].addEffect(4, true, 0);
            }
        }
        Vector3Int posNew = posMouse * 10 + new Vector3Int(5, 5, 0);
        Instantiate(IcePrefab, posNew, Quaternion.identity);
        hasAttack = true;
        if (hasMove)
        {
             SPM.endTurn(teamNumb, false);
        }
        else
        {
            ChangeMapShown(1);
        }
    }

    protected override void ChangeMapShown(int setMode){
        Mode = setMode;
        if (Mode == 1)
        {
            print("move");
            GC.setAttackPos(transform.position, 1, true, true, false, 3, true);
            GC.setReachablePos(transform.position, SPM.MaxDistancePlayers[teamNumb], true, true, false, false);
        }
        else if (Mode == 2) { GC.setAttackPos(transform.position, 1, true, true, false, 3, false); GC.setReachablePos(transform.position, SPM.MaxDistancePlayers[teamNumb], true, true, true, true); }
        else
        {
            GC.setAttackPos(transform.position, 1, true, true, false, 3, true); GC.setReachablePos(transform.position, SPM.MaxDistancePlayers[teamNumb], true, true, true, true);
        }
    }
}
