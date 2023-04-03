using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectStuff : PlayerBase
{   
public override void Update(){
        base.Update();
}

public override void Die(){

}

public void Melt(){
        StartCoroutine(Melting(0.25f));
        StartCoroutine(DestroyObject(2.0f));
}

IEnumerator Melting(float sec){
        WaitForSeconds wfs= new WaitForSeconds(sec);
        //Patron de 5x5
        int rot=0;
        int rotCont=0;
        int rotSteps=1;
        Vector3Int posGrid=GC.grid.WorldToCell(transform.position);
        int x=posGrid.x-GC.ogx; int y=posGrid.y-GC.ogy;

        
        for(int i=1; i<=(25); i++){
            GC.tiles[x,y].addEffect(6,false,0);
            

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

IEnumerator DestroyObject(float sec){
        WaitForSeconds wfs=new WaitForSeconds(sec);
        Vector3Int posGrid=GC.grid.WorldToCell(transform.position);
        yield return wfs;
        GC.tiles[posGrid.x-GC.ogx,posGrid.y-GC.ogy].addEffect(6,false,0);
        Destroy(this.gameObject);
        
    }

}
