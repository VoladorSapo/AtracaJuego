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

}

}
