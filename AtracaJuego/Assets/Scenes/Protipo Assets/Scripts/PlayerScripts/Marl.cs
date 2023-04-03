using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marl : PlayablePlayer
{
    public GameObject GasPrefab;
    Vector3Int posMouse;
    // Update is called once per frame
    public override void Update()
    {

        base.Update();
        if(Input.GetMouseButtonDown(0) && Cooldown==0 && SPM.currentPlayer==teamNumb && Mode == 2)
        {
            posMouse=GC.GetMousePosition();
            if(!GC.isEmpty(posMouse, false, 2)){
                animator.SetInteger("Anim", 2);
            }
        }
    }
    public override void InstantiatePrefab()
    {
        //Vector3Int posNew=new Vector3Int(Mathf.FloorToInt(transform.position.x),Mathf.FloorToInt(transform.position.y),0); //*10 por el tamaño de las tiles + offset de (10/2,10/2,0)=(5,5,0)
        Vector3Int posNew = posMouse * 10 + new Vector3Int(5, 5, 0);
        Instantiate(GasPrefab, posNew, Quaternion.identity);
        hasAttack = true;
        animator.SetInteger("Anim", 0);

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
            GC.setAttackPos(transform.position, 1, true, true, false, 2, true);
            GC.setReachablePos(transform.position, SPM.MaxDistancePlayers[teamNumb], true, true, false, false);
        }
        else if (Mode == 2) { GC.setAttackPos(transform.position, 1, true, true, false, 2, false); GC.setReachablePos(transform.position, SPM.MaxDistancePlayers[teamNumb], true, true, true, true); }
        else
        {
            GC.setAttackPos(transform.position, 1, true, true, false, 2, true); GC.setReachablePos(transform.position, SPM.MaxDistancePlayers[teamNumb], true, true, true, true);
        }
    }
}

