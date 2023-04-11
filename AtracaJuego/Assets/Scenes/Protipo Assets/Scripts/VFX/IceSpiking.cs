using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpiking : MonoBehaviour
{
    private PlaceTiles PT;
    private GridController GC;
    void Awake(){
        PT=GameObject.Find("TileController").GetComponent<PlaceTiles>();
        GC=GameObject.Find("Grid").GetComponent<GridController>();
    }

    void SetIceSpike(){
        Vector3Int posInGrid=GC.grid.WorldToCell(transform.position);
        if(GC.tiles[posInGrid.x-GC.ogx,posInGrid.y-GC.ogy].GetTileEffect()==8)
        {PT.Charco.SetTile(posInGrid,PT.iceSpkT);}
    }
    void DestroyIceSpike(){
        
        Destroy(this.gameObject);
    }
}
