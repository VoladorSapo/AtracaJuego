using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Player1 : PlayablePlayer
{   
    void Start(){
        Vector3Int posGrid = GC.grid.WorldToCell(transform.position);
        GC.tiles[posGrid.x-GC.ogx, posGrid.y-GC.ogy].setPlayer(this);
    }

}
