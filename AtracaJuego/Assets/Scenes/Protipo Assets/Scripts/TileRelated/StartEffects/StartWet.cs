using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWet : MonoBehaviour
{   
    public GridController GC;

    void Start(){
        GC=GameObject.Find("Grid").GetComponent<GridController>();
    }
    public void Starting(){
    
    Vector3Int posInGrid=GC.grid.WorldToCell(transform.position) - new Vector3Int(GC.ogx,GC.ogy,0);
    GC.tiles[posInGrid.x,posInGrid.y].trySetEffect(2); //2 es mojado
    GC.tiles[posInGrid.x,posInGrid.y].addEffect(6,false,0,-1); //En addeffect es 6 (lioso pero ya es tarde para cambiarlo por el momento)
    }
}
