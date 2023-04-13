using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paul : PlayablePlayer
{
    public GameObject ElecPrefab;
    Vector3Int posMouse;
    private int x, y;

    protected override void Awake()
    {
        base.Awake();
        effect=-1;
        MaxDistance=8;
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
                Cooldown=1;
                animator.SetInteger("Anim", 2);

            }
        }
    }
    public override void InstantiatePrefab()
    {
        Vector3Int posNew = posMouse * 10 + new Vector3Int(5, 5, 0); //*10 por el tamaño de las tiles + offset de (10/2,10/2,0)=(5,5,0)

        Vector3 directionVec = posMouse - GC.grid.WorldToCell(transform.position);
        int x = (int)directionVec.x;
        int y = (int)directionVec.y;
        Vector2 dir = new Vector2(x, y);
        Debug.LogWarning(Mathf.Abs(x));
        if (Mathf.Abs(x) != Mathf.Abs(y))
        { //A los lados
            switch (Mathf.Abs(x) > 0)
            {
                case false:
                    if (y > 0)
                    {
                        ElecPrefab.GetComponent<ElecEffect>().direction = 3;
                        Instantiate(ElecPrefab, posNew, Quaternion.identity);
                    }
                    else
                    {
                        ElecPrefab.GetComponent<ElecEffect>().direction = 4;
                        Instantiate(ElecPrefab, posNew, Quaternion.identity);
                    }
                    break;
                case true:
                    if (x > 0)
                    {
                        ElecPrefab.GetComponent<ElecEffect>().direction = 1;
                        Instantiate(ElecPrefab, posNew, Quaternion.identity);
                    }
                    else
                    {
                        ElecPrefab.GetComponent<ElecEffect>().direction = 2;
                        Instantiate(ElecPrefab, posNew, Quaternion.identity);
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
            ChangeMapShown(1);
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
            print("move");
            GC.setAttackPos(transform.position, 1, true, true, false, 1, true);
            GC.setReachablePos(transform.position, MaxDistance, true, true, false, false);
        }
        else if (Mode == 2) { GC.setAttackPos(transform.position, 1, true, true, false, 4, false); GC.setReachablePos(transform.position, MaxDistance, true, true, true, true); }
        else
        {
            GC.setAttackPos(transform.position, 1, true, true, false, 4, true); GC.setReachablePos(transform.position, MaxDistance, true, true, true, true);
        }
        _turnbuttons.showButtons(this, setMode, !hasMove, !hasAttack);

    }

}

