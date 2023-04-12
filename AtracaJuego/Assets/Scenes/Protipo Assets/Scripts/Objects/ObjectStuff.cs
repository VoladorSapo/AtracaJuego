using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectStuff : PlayerBase
{   

[SerializeField] protected int LifeTime;

public override void Update(){
        base.Update();
}

public void StartObject(){
    Vector3Int posGrid=GC.grid.WorldToCell(transform.position);
    Debug.LogWarning(this);
    GC.tiles[posGrid.x-GC.ogx, posGrid.y-GC.ogy].setPlayer(this);
}
protected override void Awake()
    {
        base.Awake();
        isObject=true;
    }
public override void Die(){
    if(this.tag!="StoneBox"){
    alive = false;
    Vector3Int tilepos = GC.grid.WorldToCell(transform.position);
    CustomTileClass tile = GC.tiles[tilepos.x -GC.ogx, tilepos.y -GC.ogy];
    tile.setPlayer(null);
    Destroy(this.gameObject);
        switch(this.tag){
            case "WoodBox": break; //Animacion de romper caja
            case "IceCube": break; //Animacion de romper hielo
        }
    }
}

}
