using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecEffect : MonoBehaviour
{
    public int direction;
    public GridController _GC;
    public MapManager _MM;
    public PlayablePlayer _PP;
    // Start is called before the first frame update
    void Awake(){
        _GC=GameObject.Find("Grid").GetComponent<GridController>();
        _MM=GameObject.Find("MapManager").GetComponent<MapManager>();
        _PP=GameObject.Find("PlayerController").GetComponent<PlayablePlayer>();
    }
    void Start()
    {
        Vector3Int tileO=_GC.grid.WorldToCell(transform.position);
        int x=tileO.x-_GC.ogx;
        int y=tileO.y-_GC.ogy;

        
        if(_GC.tiles[x,y].player!=null){
            if(_GC.tiles[x,y].player.name=="Player2" && _GC.tiles[x,y].player.GetAlive()){GameObject.Find("Player2").GetComponent<Iowa>().StartRage(direction);}
            if(_GC.tiles[x,y].player.tag=="Player" && !_GC.tiles[x,y].player.GetAlive() && _GC.tiles[x,y].TileIsSafe()){_PP.Revive(_GC.tiles[x,y].player);}
            //if(!_GC.tiles[x,y].player.GetAlive()){print("Revive");}
        }else{_GC.tiles[x,y].addEffect(5,true,direction,-1);}

        StartCoroutine(DestroyEffect(2.0f));
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
