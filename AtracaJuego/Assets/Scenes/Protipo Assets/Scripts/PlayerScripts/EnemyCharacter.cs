using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : PlayerBase
{
    // Start is called before the first frame update

    // Update is called once per frame

    public override void startTurn()
    {
        print("hei");
        int i = 0;
        bool poswalkable;
        Vector3 pos;
        do
        {
            pos = new Vector3( Random.Range(GC.ogx, GC.tiles.GetLength(0)+GC.ogx), Random.Range(GC.ogy, GC.tiles.GetLength(1)+GC.ogy));
            print(GC.ogx);
            print(GC.tiles.GetLength(0) + GC.ogx);
            print(pos.x);
            print(GC.ogy);
            print(GC.tiles.GetLength(1) + GC.ogy);
            print(pos.y);
            poswalkable = GC.isWakable(pos);
            

            i++;
        } while (!poswalkable && i < 20);
        Move(pos);
    }
}
