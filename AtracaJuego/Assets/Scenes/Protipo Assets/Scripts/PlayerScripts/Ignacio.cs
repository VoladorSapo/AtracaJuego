using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignacio : MonoBehaviour
{
    public GameObject FirePrefab;
    public GridController _GC;
    public int FireCooldown;
    public ScriptPlayerManager _SCP;
    private int x,y;
    void Start()
    {
    FireCooldown=0;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3Int tileO = _GC.grid.WorldToCell(transform.position);
        
        x=tileO.x-_GC.ogx;
        y=tileO.y-_GC.ogy;

        if(FireCooldown==0 && _SCP.currentPlayer==0){
        if(Input.GetKeyDown(KeyCode.UpArrow) && (_GC.tiles[x,y+1].GetTileState()<5 || _GC.tiles[x,y+1].GetTileState()==11 || _GC.tiles[x,y+1].GetTileState()==10)){    
            Vector3 posNew=transform.position+new Vector3(0,10,0);
            Instantiate(FirePrefab, posNew, Quaternion.identity);
            FireCooldown++;
        }

        if(Input.GetKeyDown(KeyCode.DownArrow) && (_GC.tiles[x,y-1].GetTileState()<5 || _GC.tiles[x,y+1].GetTileState()==11 || _GC.tiles[x,y+1].GetTileState()==10)){
            Vector3 posNew=transform.position+new Vector3(0,-10,0);
            Instantiate(FirePrefab, posNew, Quaternion.identity);
            FireCooldown++;
        }

        if(Input.GetKeyDown(KeyCode.RightArrow) && (_GC.tiles[x+1,y].GetTileState()<5 || _GC.tiles[x,y+1].GetTileState()==11 || _GC.tiles[x,y+1].GetTileState()==10)){
            Vector3 posNew=transform.position+new Vector3(10,0,0);
            Instantiate(FirePrefab, posNew, Quaternion.identity);
            FireCooldown++;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow) && (_GC.tiles[x-1,y].GetTileState()<5 || _GC.tiles[x,y+1].GetTileState()==11 || _GC.tiles[x,y+1].GetTileState()==10)){
            Vector3 posNew=transform.position+new Vector3(-10,0,0);
            Instantiate(FirePrefab, posNew, Quaternion.identity);
            FireCooldown++;
        }
        }
    }
}
