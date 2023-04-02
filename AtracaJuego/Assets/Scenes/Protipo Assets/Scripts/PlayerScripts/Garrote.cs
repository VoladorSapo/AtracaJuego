using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garrote : EnemyCharacter
{
    // Start is called before the first frame update
    public override void startTurn()
    {
        GC.setReachablePos(transform.position, MaxDistance, true, false, team, false);
        print("hei");
        List<Node> path = new List<Node>();
        for (int i = 0; i < protas.players.Count; i++)
        {
            List<Node> newpath = GC.GetPath(transform.position, protas.players[i].transform.position, true);
            if(newpath != null && newpath.Count <= newpath.Count)
            {
                path = newpath;
            }
        }
        int z = 0;
        bool poswalkable;
        Vector3 pos;

       // Move(pos);
    }
}
