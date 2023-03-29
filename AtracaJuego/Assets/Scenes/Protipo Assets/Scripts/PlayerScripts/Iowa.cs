using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iowa : MonoBehaviour
{
    
    public GameObject PushPrefab;
    public GridController _GC;
    private Vector3 posBase;

    public int PushCooldown;
    public ScriptPlayerManager _SCP;
    private int x,y;
    void Start()
    {
    PushCooldown=0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3Int tileO = _GC.grid.WorldToCell(transform.position);

        x=tileO.x-_GC.ogx;
        y=tileO.y-_GC.ogy;

        if(PushCooldown==0 && _SCP.currentPlayer==0){
        if(Input.GetKeyDown(KeyCode.UpArrow) && (_GC.tiles[x,y+1].GetTileState()<5 || _GC.tiles[x,y+1].GetTileState()==11 || _GC.tiles[x,y+1].GetTileState()==12)){
            PushPrefab.GetComponent<PushEffect>().direction = 3;
            
            Vector3 posNew=transform.position+new Vector3(0,10,0);
            Instantiate(PushPrefab, posNew, Quaternion.identity);
            PushCooldown++;
        }

        if(Input.GetKeyDown(KeyCode.DownArrow) && (_GC.tiles[x,y-1].GetTileState()<5 || _GC.tiles[x,y+1].GetTileState()==11 || _GC.tiles[x,y+1].GetTileState()==12)){
            PushPrefab.GetComponent<PushEffect>().direction = 4;
            Vector3 posNew=transform.position+new Vector3(0,-10,0);
            Instantiate(PushPrefab, posNew, Quaternion.identity);
            PushCooldown++;
        }

        if(Input.GetKeyDown(KeyCode.RightArrow) && (_GC.tiles[x+1,y].GetTileState()<5 || _GC.tiles[x,y+1].GetTileState()==11 || _GC.tiles[x,y+1].GetTileState()==12)){
            PushPrefab.GetComponent<PushEffect>().direction = 1;
            Vector3 posNew=transform.position+new Vector3(10,0,0);
            Instantiate(PushPrefab, posNew, Quaternion.identity);
            PushCooldown++;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow) && (_GC.tiles[x-1,y].GetTileState()<5 || _GC.tiles[x,y+1].GetTileState()==11 || _GC.tiles[x,y+1].GetTileState()==12)){
            PushPrefab.GetComponent<PushEffect>().direction = 2;
            Vector3 posNew=transform.position+new Vector3(-10,0,0);
            Instantiate(PushPrefab, posNew, Quaternion.identity);
            PushCooldown++;
        }
        }
    }

}
