using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasolSpiking : MonoBehaviour
{
    private PlaceTiles PT;
    private GridController GC;
    void Awake(){
        PT=GameObject.Find("TileController").GetComponent<PlaceTiles>();
        GC=GameObject.Find("Grid").GetComponent<GridController>();
    }

    void SetGasolSpike(){
        Vector3Int posInGrid=GC.grid.WorldToCell(transform.position);
        if(GC.tiles[posInGrid.x-GC.ogx,posInGrid.y-GC.ogy].GetTileEffect()==10 || GC.tiles[posInGrid.x-GC.ogx,posInGrid.y-GC.ogy].GetTileEffect()==15)
        {PT.Charco.SetTile(posInGrid,PT.gasolineFrzSpkT);}
    }
    void DestroyGasolSpike(){
        
        Destroy(this.gameObject);
    }
}
