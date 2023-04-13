using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Garrote : EnemyCharacter
{
    // Start is called before the first frame update
     //The tile of the player you want to hit
    public override void startTurn()
    {
        GC.setReachablePos(transform.position, MaxDistance, true, false, team, false);
        List<Node> path = new List<Node>();
        string elname = "Null";
        for (int i = 0; i < protas.players.Count; i++)
        {
            List<Node> newpath = GC.GetPath(transform.position, protas.players[i].transform.position, true);
            if(newpath != null && (newpath.Count < path.Count || path.Count == 0))
            {
                elname = protas.players[i].name;
                if(newpath.Count < detectDistance)
                {
                    activated = true;
                }
                path = newpath;
            }
        }
        hit = path[path.Count - 1].pos;
        objective = path[path.Count - 2].pos;

        if(path != null && activated)
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
            startMove(path);
        }
        else
        {
           hasTurn = true;
            ChangeMapShown(0);
        }

    }
    public override void ChangeMapShown(int setMode)
    {
        print("jodeeeer");
        if(GC.grid.WorldToCell(transform.position) == objective)
        {
            animator.SetInteger("Anim", 2);
        }
        else
        {
            hasTurn = true;
        }
        SPM.nextTurn(teamNumb, false);
    }
    public override void InstantiatePrefab()
    {
        _MM.Damage(codeDamage, hit.x - GC.ogx, hit.y - GC.ogy);
        hasTurn = true;
    }

    
}
