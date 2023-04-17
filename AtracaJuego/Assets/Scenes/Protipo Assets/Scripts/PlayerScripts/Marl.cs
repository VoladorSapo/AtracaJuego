using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marl : PlayablePlayer
{
    public GameObject GasPrefab;
    public GameObject DisplayGas;
    Vector3Int posMouse;
    Vector3Int prevMouse;

    Vector3Int placeHere;
    private bool InstHecho=false;
    
    protected override void Awake()
    {
        base.Awake();
        effect=-1;
        prevMouse=posMouse;

    }
    public override void Update()
    {
        base.Update();
        
        if (!SPM._gameController.Pause) { 
            posMouse = GC.GetMousePosition();
        }
        if(!GC.isEmpty(posMouse, false, 2) && Mode == 2 && !SPM._gameController.Pause)
        {  
                if(!InstHecho){
                Vector3Int posNew = posMouse * 10 + new Vector3Int(5, 5, 0);
                
                Instantiate(DisplayGas, posNew, Quaternion.identity);
                

                InstHecho=true;
                }
                if(Input.GetMouseButton(0) && Cooldown==0 && SPM.currentPlayer== teamNumb && !SPM._gameController.Pause)
                {

                    placeHere=posMouse;

                    Vector3 directionVec = placeHere - GC.grid.WorldToCell(transform.position);
                    switch(Mathf.Sign(directionVec.x)){
                    case 1: sprite.flipX = false; break;
                    case -1: sprite.flipX = true; break;
                    }


                    Cooldown=2;
                    SoundManager.InstanceSound.PlaySound(SoundManager.InstanceSound._sfx, SoundGallery.InstanceClip.audioClips[2]);
                Vector3Int tilepos = GC.grid.WorldToCell(transform.position - new Vector3(5f, 5f, 0)) - new Vector3Int(GC.ogx, GC.ogy);

                CustomTileClass tile = GC.tiles[tilepos.x, tilepos.y];
                CustomTileClass tile2 = GC.tiles[posMouse.x - GC.ogx, posMouse.y - GC.ogy];
                CDH.AttackDialogue(GetType().ToString(), tile, tile2);
                
                animator.SetInteger("Anim", 2);
                }
        }
        if(prevMouse!=posMouse || Cooldown!=0 || Mode!=2 || !alive || SPM.currentPlayer!=teamNumb){
            Destroy(GameObject.FindGameObjectWithTag("DisplayGasTag"));
            InstHecho=false;
        }

        /*
        if(Input.GetMouseButtonDown(0) && Cooldown==0 && SPM.currentPlayer==teamNumb && Mode == 2)
        {
            
            if(!GC.isEmpty(posMouse, false, 2)){
                Cooldown=3;
                animator.SetInteger("Anim", 2);
            }
        }*/

        prevMouse=posMouse;
    }
    public override void InstantiatePrefab()
    {
        //Vector3Int posNew=new Vector3Int(Mathf.FloorToInt(transform.position.x),Mathf.FloorToInt(transform.position.y),0); //*10 por el tamaño de las tiles + offset de (10/2,10/2,0)=(5,5,0)
        Vector3Int posNew = placeHere * 10 + new Vector3Int(5, 5, 0);
        Instantiate(GasPrefab, posNew, Quaternion.identity);
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
    }

    public override void ChangeMapShown(int setMode){
        Mode = setMode;
        if (Mode == 1)
        {
            changeCircle(true);
            print("move");
            GC.setAttackPos(transform.position, 1, true, true, false, 2, true);
            GC.setReachablePos(transform.position, MaxDistance, true, true, false, false);
        }
        else if (Mode == 2) { GC.setAttackPos(transform.position, 1, true, true, false, 2, false); GC.setReachablePos(transform.position, MaxDistance, true, true, true, true); changeCircle(true); }
        else
        {
            changeCircle(false);
            GC.setAttackPos(transform.position, 1, true, true, false, 2, true); GC.setReachablePos(transform.position, MaxDistance, true, true, true, true);
        }
        _turnbuttons.showButtons(this, setMode, !hasMove, !hasAttack);

    }
}

