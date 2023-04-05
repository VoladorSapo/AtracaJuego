using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePrefab : ObjectStuff
{    
    protected override void Awake()
    {
        base.Awake();
        Vector3Int posGrid=GC.grid.WorldToCell(transform.position);
        GC.tiles[posGrid.x-GC.ogx, posGrid.y-GC.ogy].setPlayer(this);
        effect=4;
        bypass=false;
        direction=0;
        FreezeTile(posGrid);
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

    

    /*IEnumerator DestroyEffect(float sec){
        WaitForSeconds wfs=new WaitForSeconds(sec);
        yield return wfs;
        _GC.tiles[posGrid.x-_GC.ogx,posGrid.y-_GC.ogy].SetTileEffect(2);
        Destroy(this.gameObject);
        
    }

    IEnumerator PushCube(int direction){
        _GC.tiles[posGrid.x-_GC.ogx ,posGrid.y-_GC.ogy].SetTileEffect(5);
        int dx=0, dy=0;
        switch(direction){
            case 1: dx=1; break;
            case 2: dx=-1; break;
            case 3: dy=1; break;
            case 4: dy=-1; break;
        }
        WaitForSeconds wfs=new WaitForSeconds(0);
        int speed=50;
        bool stop=false;
        Vector3 newPos=transform.position+new Vector3(10f*dx,10f*dy,0f);
        if(_GC.tiles[posGrid.x-_GC.ogx + dx,posGrid.y-_GC.ogy + dy].GetTileState()<5){
        while(!stop){
            //&& _GC.tiles[posGrid.x-_GC.ogx + dx,posGrid.y-_GC.ogy + dy].GetTileState()>=5
            //newPos=transform.position+new Vector3(10f*dx,10f*dy,0f);}
            transform.position = Vector3.MoveTowards(transform.position, newPos, speed*Time.deltaTime);

            if(transform.position==newPos){newPos=transform.position+new Vector3(10f*dx,10f*dy,0f);
                if(_GC.tiles[posGrid.x-_GC.ogx + dx,posGrid.y-_GC.ogy + dy].GetTileState()>=5){break;}
                if(_GC.tiles[posGrid.x-_GC.ogx + dx,posGrid.y-_GC.ogy + dy].GetPlayer()!=null){_GC.tiles[posGrid.x-_GC.ogx + dx,posGrid.y-_GC.ogy+dy].GetPlayer().Push(dx,dy,5); break;}
            }

            yield return wfs;
        }
        }
    }*/
}
