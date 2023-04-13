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

    public RuleTile[] tilesRotas;
    void Awake(){
        _GC=GameObject.Find("Grid").GetComponent<GridController>();
        Charco=GameObject.Find("Charcos").GetComponent<Tilemap>();
        CharcoE=GameObject.Find("CharcosElec").GetComponent<Tilemap>();
        Gas=GameObject.Find("Gases").GetComponent<Tilemap>();
        GasE=GameObject.Find("GasesElec").GetComponent<Tilemap>();
        Ground = GameObject.Find("Ground").GetComponent<Tilemap>();
    }

    public void PlaceAfterBreak(int x, int y, int dx, int dy, int ogx, int ogy){
        Vector3Int pos= new Vector3Int(x,y,0);
        Vector3Int newPos=pos+new Vector3Int(dx,dy,0);
        Vector3 posOffGrif=_GC.grid.CellToWorld(newPos)+ new Vector3 (_GC.ogx*10,_GC.ogy*10,0);
        Vector3Int posOutGrid=new Vector3Int(Mathf.FloorToInt(posOffGrif.x),Mathf.FloorToInt(posOffGrif.y),0);
        
        
        
        switch(_GC.tiles[newPos.x,newPos.y].GetSpriteId()){
            case 2: Debug.LogWarning(posOutGrid+"_;"); RepeatBreak(posOutGrid,newPos,2); Ground.RefreshAllTiles(); break;
        }
        
    }

    public void RepeatBreak(Vector3Int pos, Vector3Int posInted, int id){
        Ground.SetTile(_GC.grid.WorldToCell(pos),tilesRotas[0]); _GC.Top.SetTile(_GC.grid.WorldToCell(pos),null);
        _GC.tiles[posInted.x,posInted.y].SetTileStats(1,0,16,0);
        Debug.LogWarning(posInted);
        if(_GC.tiles[posInted.x+1,posInted.y].GetSpriteId()==id){RepeatBreak(pos+new Vector3Int(10,0,0),posInted+new Vector3Int(1,0,0),2);}
        if(_GC.tiles[posInted.x-1,posInted.y].GetSpriteId()==id){RepeatBreak(pos+new Vector3Int(-10,0,0),posInted+new Vector3Int(-1,0,0),2);;}
        if(_GC.tiles[posInted.x,posInted.y+1].GetSpriteId()==id){RepeatBreak(pos+new Vector3Int(0,10,0),posInted+new Vector3Int(0,1,0),2);;}
        if(_GC.tiles[posInted.x,posInted.y-1].GetSpriteId()==id){RepeatBreak(pos+new Vector3Int(0,-10,0),posInted+new Vector3Int(0,-1,0),2);;}
    }
    
}
