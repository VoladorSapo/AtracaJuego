using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Garrote : EnemyCharacter
{

    // Start is called before the first frame update
    public override void startTurn()
    {
        GC.setReachablePos(transform.position, MaxDistance, true, false, team, false);
        print("hei");
        List<Node> path = new List<Node>();
        string elname = "Null";
        for (int i = 0; i < protas.players.Count; i++)
        {
            List<Node> newpath = GC.GetPath(transform.position, protas.players[i].transform.position, true);
            if (newpath == null)
            {
                print("tremendonullteaventaste");
            }
            else
            {
                print(newpath.Count);
            }
            if(newpath != null && (newpath.Count < path.Count || path.Count == 0))
            {
                elname = protas.players[i].name;
                path = newpath;
            }
        }
        print(path.Count);
        print(elname);
        if(path != null)
        {
            List<Node> turnpath = new List<Node>();
            foreach(Node nodo in path)
            {
                if (Array.Exists(GC.ReachablePos,s=> s == nodo.pos)){
                    turnpath.Add(nodo);
                }
                else
                {
                    break;
                }
            }
            path = turnpath;
        }
        print(path.Count);
        print(path[0].pos);
        startMove(path);
    }
    protected override void ChangeMapShown(int setMode)
    {
        SPM.endTurn(teamNumb, false);
    }
}
