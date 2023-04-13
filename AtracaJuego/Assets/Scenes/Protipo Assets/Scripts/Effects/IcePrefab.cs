using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePrefab : ObjectStuff
{    
    [SerializeField] private Animator anim;
    protected override void Awake()
    {
        base.Awake();
        Vector3Int posGrid=GC.grid.WorldToCell(transform.position);
        GC.tiles[posGrid.x-GC.ogx, posGrid.y-GC.ogy].setPlayer(this);
        effect=4;
        bypass=false;
        direction=0;
        FreezeTile(posGrid);
        anim=GetComponent<Animator>();
    }
    /*protected override void Start(){
        Vector3Int posGrid=GC.grid.WorldToCell(transform.position);
        GC.tiles[posGrid.x-GC.ogx, posGrid.y-GC.ogy].setPlayer(this);
    }*/
    public override void Update()
    {
        Vector3Int posGrid=GC.grid.WorldToCell(transform.position);
        
        base.Update();
    }

    public void FreezeTile(Vector3Int posGrid){
        GC.tiles[posGrid.x-GC.ogx, posGrid.y-GC.ogy].addEffect(4, false,0,-1);
    }

    public void Melt(){
        StartCoroutine(Melting(0.25f));
    }

    IEnumerator Melting(float sec){
        anim.SetInteger("ToMelt",1);
        WaitForSeconds wfs= new WaitForSeconds(sec);
        //Patron de 5x5
        int rot=0;
        int rotCont=0;
        int rotSteps=1;
        Vector3Int posGrid=GC.grid.WorldToCell(transform.position);
        int x=posGrid.x-GC.ogx; int y=posGrid.y-GC.ogy;
        int prevx=x;
        int prevy=y;
            GC.tiles[posGrid.x-GC.ogx,posGrid.y-GC.ogy].addEffect(0,false,0,-1);
            GC.tiles[posGrid.x-GC.ogx,posGrid.y-GC.ogy].trySetEffect(2);
        
        /*for(int i=1; i<=(25); i++){
            if(GC.tiles[x+1,y].GetTileEffect()==2 || GC.tiles[x-1,y].GetTileEffect()==2 || GC.tiles[x,y+1].GetTileEffect()==2 || GC.tiles[x,y-1].GetTileEffect()==2){
                GC.tiles[prevx,prevy].trySetEffect(2); GC.tiles[x,y].trySetEffect(2);
            }
            prevx=x; prevy=y;
            switch(rot){
                case 0: x++; break;
                case 1: y--; break;
                case 2: x--; break;
                case 3: y++; break;
            }
            if(i%rotSteps==0){
                if((rot)%4==0){
                }
                rot=(rot+1)%4;
                rotCont++;
                if(rotCont%2==0){
                    rotSteps++;
                }
            }
            
        }*/

        /*rot=0;
        rotCont=0;
        rotSteps=1;
        x=posGrid.x-GC.ogx; y=posGrid.y-GC.ogy;
        prevx=x; prevy=y;*/
        for(int i=1; i<=(25); i++){
            if(GC.tiles[x+1,y].GetTileEffect()==2 || GC.tiles[x-1,y].GetTileEffect()==2 || GC.tiles[x,y+1].GetTileEffect()==2 || GC.tiles[x,y-1].GetTileEffect()==2
            ||  GC.tiles[x+1,y].GetTileEffect()==6 || GC.tiles[x-1,y].GetTileEffect()==6 || GC.tiles[x,y+1].GetTileEffect()==6 || GC.tiles[x,y-1].GetTileEffect()==6
            ){
                GC.tiles[prevx,prevy].addEffect(6,false,0,-1); GC.tiles[x,y].addEffect(6,false,0,-1);
                print(i);
            }
            prevx=x; prevy=y;
            
            

            switch(rot){
                case 0: x++; break;
                case 1: y--; break;
                case 2: x--; break;
                case 3: y++; break;
            }
            if(i%rotSteps==0){
                if((rot)%4==0){
                    yield return wfs;
                }
                rot=(rot+1)%4;
                rotCont++;
                if(rotCont%2==0){
                    rotSteps++;
                }
            }
            
        }
}

    public void MeltedObject(){
        Destroy(this.gameObject);
    }

}

