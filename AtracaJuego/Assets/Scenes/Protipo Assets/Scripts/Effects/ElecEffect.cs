using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ElecEffect : MonoBehaviour
{
    public int direction;
    public Tile activatedTile;
    public GridController _GC;
    public PalancaTest _palanca;
    // Start is called before the first frame update
    void Awake(){
        _GC=GameObject.Find("Grid").GetComponent<GridController>();
    }
    void Start()
    {
        Vector3Int tileO=_GC.grid.WorldToCell(transform.position);
        int x=tileO.x-_GC.ogx;
        int y=tileO.y-_GC.ogy;

        
        if(_GC.tiles[x,y].player!=null){
            if(_GC.tiles[x,y].player.tag=="Player" && !_GC.tiles[x,y].player.GetAlive() && _GC.tiles[x,y].TileIsSafe()){PlayablePlayer pl =_GC.tiles[x,y].player as PlayablePlayer;  pl.Revive(_GC.tiles[x,y].player);}
            else if(_GC.tiles[x,y].player is Iowa && _GC.tiles[x,y].player.GetAlive()){ _GC.tiles[x,y].GetPlayer().GetComponent<Iowa>().StartRage(direction);}
            else if(_GC.tiles[x,y].player.tag!="Player"){_GC.tiles[x,y].addEffect(5,true,direction,-1);}
            //if(!_GC.tiles[x,y].player.GetAlive()){print("Revive");}
        }else{_GC.tiles[x,y].addEffect(5,true,direction,-1);}

        if(_GC.tiles[x,y].GetTileState()==6){_GC.tiles[x,y].SetTileState(7); _GC.ground.SetTile(new Vector3Int(tileO.x,tileO.y,0),activatedTile);}
        else if(_GC.tiles[x,y].GetTileState()==7){_palanca.ResetActive(x,y);}
        //StartCoroutine(DestroyEffect(2.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyEffect(float sec){
        WaitForSeconds wfs=new WaitForSeconds(sec);
        yield return wfs;
        Destroy(this.gameObject);
    }
}
