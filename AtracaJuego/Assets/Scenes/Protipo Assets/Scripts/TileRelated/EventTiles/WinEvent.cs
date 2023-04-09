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
        Vector3Int pos = GC.grid.WorldToCell(transform.position);
        GC.tiles[pos.x - GC.ogx, pos.y - GC.ogy].GetPlayer().pressWinTile();
    }
}
