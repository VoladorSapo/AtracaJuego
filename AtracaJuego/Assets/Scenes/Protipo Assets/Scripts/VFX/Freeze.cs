using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    
    private PlaceTiles PT;
    private GridController GC;
    void Awake(){
        PT=GameObject.Find("TileController").GetComponent<PlaceTiles>();
        GC=GameObject.Find("Grid").GetComponent<GridController>();
    }

    void SetFreeze(){
        Vector3Int posInGrid=GC.grid.WorldToCell(transform.position);
        if(GC.tiles[posInGrid.x-GC.ogx,posInGrid.y-GC.ogy].GetTileEffect()==4 || GC.tiles[posInGrid.x-GC.ogx,posInGrid.y-GC.ogy].GetTileEffect()==12 || GC.tiles[posInGrid.x-GC.ogx,posInGrid.y-GC.ogy].GetTileEffect()==13)
        {PT.Charco.SetTile(posInGrid,PT.iceT);}
    }
    void DestroyFreeze(){
        
        Destroy(this.gameObject);
    }
}
