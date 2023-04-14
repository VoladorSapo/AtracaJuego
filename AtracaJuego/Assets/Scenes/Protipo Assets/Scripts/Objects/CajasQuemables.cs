using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajasQuemables : ObjectStuff
{
    public bool Burning=false;
    private SpriteRenderer spriteC;
    protected override void Start()
    {
        base.Start();
        spriteC=GetComponent<SpriteRenderer>();
        effect=-1;
    }

    public override void Update(){
        base.Update();  
    }

    public void Burn(){
        Burning=true;
        animator.SetBool("Burning",true);
        effect=8;
        bypass=true;
        direction=0;

        Vector3Int tilePos=GC.grid.WorldToCell(transform.position);
        GC.tiles[tilePos.x-GC.ogx,tilePos.y-GC.ogy].addEffect(8,true,0,-1);
    }

    public void BurntBox(){
        Destroy(this.gameObject);
    }

    public void isBurning()
    {
        if(Burning){LifeTime--;}
        if(LifeTime==0){animator.SetInteger("Anim",3);}
    }
}
