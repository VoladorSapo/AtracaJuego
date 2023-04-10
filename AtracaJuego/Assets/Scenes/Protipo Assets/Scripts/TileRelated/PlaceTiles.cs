using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class PlaceTiles : MonoBehaviour
{
    private GridController _GC;
    public Tilemap Charco;
    public Tilemap CharcoE;
    public Tilemap Gas;
    public Tilemap GasE;
    public Tilemap Ground;
    
    //Podria ser array pero para que tan solo tenga unos 10 elementos mejor que tenga cada uno un nombre especifico
    public RuleTile elecT;
    public RuleTile fireT;
    public RuleTile iceT;
    public RuleTile iceSpkT;
    public RuleTile wetT;
    public RuleTile gasT;
    public RuleTile gasolineT;
    public RuleTile gasolineFrzT;
    public RuleTile gasolineFrzSpkT;
        void Awake(){
        _GC=GameObject.Find("Grid").GetComponent<GridController>();
        Charco=GameObject.Find("Charcos").GetComponent<Tilemap>();
        CharcoE=GameObject.Find("CharcosElec").GetComponent<Tilemap>();
        Gas=GameObject.Find("Gases").GetComponent<Tilemap>();
        GasE=GameObject.Find("GasesElec").GetComponent<Tilemap>();
        Ground=GameObject.Find("Ground").GetComponent<Tilemap>();
    }

    public void PlaceAfterBreak(int x, int y, int dx, int dy, int ogx, int ogy){
        Vector3Int pos= new Vector3Int(x+ogx,y+ogy,0);
        TileBase tileDefault = Ground.GetTile(pos);
        Vector3Int newPos=pos+new Vector3Int(dx,dy,0);
        Ground.SetTile(newPos,tileDefault);
    }
}
