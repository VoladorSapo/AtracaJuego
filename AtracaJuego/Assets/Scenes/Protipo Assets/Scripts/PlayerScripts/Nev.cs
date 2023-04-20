using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nev : PlayablePlayer
{
    public GameObject IcePrefab;
    public PlayerBase IceCube;
    public GameObject DisplayIce;
    Vector3Int posMouse;
    Vector3Int posNev;
    private bool InstHecho = false;
    protected override void Awake()
    {
        base.Awake();
        print(this.GetType().ToString());
        effect = -1;
    }
    public override void Update()
    {
        base.Update();

        posNev = GC.grid.WorldToCell(transform.position);
        if (Cooldown == 0 && SPM.currentPlayer == teamNumb && Mode == 2)
        {
            if (!InstHecho)
            {
                Vector3Int posNew = posMouse * 10 + new Vector3Int(5, 5, 0);
                Vector3Int posNevCenter = posNev * 10 + new Vector3Int(5, 5, 0);
                Vector3Int posDisplay;

                for(int i=-1; i<=1; i++){
                    for(int j=-1; j<=1; j++){
                        posDisplay=posNevCenter+new Vector3Int(10*i,10*j,0);
                        Vector3Int posDisplayInted=GC.grid.WorldToCell(posDisplay)-new Vector3Int(GC.ogx,GC.ogy,0);
                        if(GC.tiles[posDisplayInted.x,posDisplayInted.y].GetTileEffect()!=16){
                        Instantiate(DisplayIce, posDisplay, Quaternion.identity);
                        }
                    }
                }
                //Instantiate(DisplayIce, posNevCenter, Quaternion.identity);
                InstHecho = true;
            }
            if (Input.GetMouseButtonDown(0) && !SPM._gameController.Pause)
            {

                posMouse = GC.GetMousePosition();
                
                Vector3Int posInGrid = GC.grid.WorldToCell(transform.position);
                if (!GC.isEmpty(posMouse, false, 2) && GC.tiles[posMouse.x - GC.ogx, posMouse.y - GC.ogy].player == null)
                {
                    Vector3 directionVec = posMouse - GC.grid.WorldToCell(transform.position);
                    switch(Mathf.Sign(directionVec.x)){
                    case 1: sprite.flipX = false; break;
                    case -1: sprite.flipX = true; break;
                    }
                    //Vector3Int posNew=new Vector3Int(Mathf.FloorToInt(transform.position.x),Mathf.FloorToInt(transform.position.y),0); //*10 por el tamaño de las tiles + offset de (10/2,10/2,0)=(5,5,0)
                    animator.SetInteger("Anim", 2);
                    Cooldown = maxCooldown;
                    Vector3Int tilepos = GC.grid.WorldToCell(transform.position - new Vector3(5f, 5f, 0)) - new Vector3Int(GC.ogx, GC.ogy);
                    SoundManager.InstanceSound.PlaySound(SoundManager.InstanceSound._sfx, SoundGallery.InstanceClip.audioClips[3]);
                    //print(tilepos);
                    CustomTileClass tile = GC.tiles[tilepos.x, tilepos.y];
                    CustomTileClass tile2 = GC.tiles[posMouse.x - GC.ogx, posMouse.y - GC.ogy];
                    CDH.AttackDialogue(GetType().ToString(), tile, tile2);
                    

                }
            }
        }

        if (Cooldown != 0 || Mode != 2 || SPM.currentPlayer != teamNumb || !alive)
        {
            GameObject[] displays=GameObject.FindGameObjectsWithTag("DisplayIceTag");
            foreach(GameObject go in displays){
                Destroy(go);
            }
            //Destroy(GameObject.FindGameObjectWithTag("DisplayIceTag"));
            InstHecho = false;
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
                GC.tiles[posInGrid.x - GC.ogx + i, posInGrid.y - GC.ogy + j].addEffect(4, true, 0, -1);
            }
        }
        Vector3Int posNew = posMouse * 10 + new Vector3Int(5, 5, 0);
        Instantiate(IcePrefab, posNew, Quaternion.identity);
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

    public override void ChangeMapShown(int setMode)
    {
        Mode = setMode;
        if (Mode == 1)
        {
            changeCircle(true);
            print("move");
            GC.setAttackPos(transform.position, 1, true, true, false, 3, true);
            GC.setReachablePos(transform.position, MaxDistance, true, 1, false, false, true);
        }
        else if (Mode == 2) { GC.setAttackPos(transform.position, 1, true, true, false, 3, false); GC.setReachablePos(transform.position, MaxDistance, true, 1, true, true, true); changeCircle(true); }
        else
        {
            changeCircle(false);
            GC.setAttackPos(transform.position, 1, true, true, false, 3, true); GC.setReachablePos(transform.position, MaxDistance, true, 1, true, true, true);
        }
        _turnbuttons.showButtons(this, setMode, !hasMove, !hasAttack);

    }
}
//Cambiar display
