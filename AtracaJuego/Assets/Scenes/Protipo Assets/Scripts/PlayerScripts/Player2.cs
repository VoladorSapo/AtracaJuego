using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : PlayablePlayer
{
    void Start(){
        //Vector3Int posGrid = GC.grid.WorldToCell(transform.position);
        //GC.tiles[posGrid.x-GC.ogx, posGrid.y-GC.ogy].setPlayer(this);
    }

    public override void loseHealth(int health)
    {
        base.loseHealth(health);
    }

}
