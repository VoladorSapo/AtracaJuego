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

    void DestroyExplosion(){
        Vector3Int posInGrid=GC.grid.WorldToCell(transform.position);
        PT.Charco.SetTile(posInGrid,PT.wetT);
        Destroy(this);
    }
}
