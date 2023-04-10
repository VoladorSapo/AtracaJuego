using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    private PlaceTiles PT;
    private GridController GC;
    void Awake(){
        PT=GameObject.Find("TileController").GetComponent<PlaceTiles>();
        GC=GameObject.Find("Grid").GetComponent<GridController>();
    }

    void SetAfire(){
        Vector3Int posInGrid=GC.grid.WorldToCell(transform.position);
        if(GC.tiles[posInGrid.x-GC.ogx,posInGrid.y-GC.ogy].GetTileEffect()==4 || GC.tiles[posInGrid.x-GC.ogx,posInGrid.y-GC.ogy].GetTileEffect()==12 || GC.tiles[posInGrid.x-GC.ogx,posInGrid.y-GC.ogy].GetTileEffect()==13)
        {PT.Charco.SetTile(posInGrid,PT.fireT);}
    }
    void DestroyExplosion(){
        
        Destroy(this.gameObject);
    }
}
