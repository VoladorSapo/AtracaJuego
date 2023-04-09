using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinEvent : EventTile
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void PressEvent(PlayerBase _player)
    {
        print("pisado");
        Vector3Int pos = GC.grid.WorldToCell(transform.position);
        print((pos.x - GC.ogx) + " " + (pos.y - GC.ogy));
        print(GC.tiles[pos.x - GC.ogx, pos.y - GC.ogy].GetPlayer());
        _player.pressWinTile();
        //GC.tiles[pos.x - GC.ogx, pos.y - GC.ogy].GetPlayer().pressWinTile();
    }
}
