using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajasQuemables : ObjectStuff
{
    private bool Burning=false;
    private SpriteRenderer spriteC;
    protected override void Start()
    {
        base.Start();
        spriteC=GetComponent<SpriteRenderer>();
        LifeTime=1;
        effect=-1;
    }

    public override void Update(){
        Vector3Int posGrid=GC.grid.WorldToCell(transform.position);
        base.Update();
        if(Burning){
            spriteC.color=new Color(1,0,0,1);

            if(Input.GetKeyDown("p")){ //Temporal2
                LifeTime--;
            }
            //GC.tiles[posGrid.x-GC.ogx,posGrid.y-GC.ogy].addEffect(8,true,0,-1);
        }
        if(LifeTime==0){Destroy(this.gameObject);}
    }

    public void Burn(){
        Burning=true;
        effect=8;
        bypass=true;
        direction=0;
    }
}
