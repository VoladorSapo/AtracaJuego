using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class FernandoBrazada : EnemyCharacter
{
    PlayerBase LastPlayer;
    public override void startTurn()
    {
        GC.setReachablePos(transform.position, MaxDistance, true, false, team, false);
        List<Node> path = new List<Node>();
        string elname = "Null";
        for (int i = 0; i < protas.players.Count; i++)
        {
            if (LastPlayer != protas.players[i])
            {
                List<Node> newpath = GC.GetPath(transform.position, protas.players[i].transform.position, true,false);
                if (newpath != null && (newpath.Count < path.Count || path.Count == 0))
                {
                    elname = protas.players[i].name;
                    if (newpath.Count < detectDistance)
                    {
                        activated = true;
                    }
                    path = newpath;
                }
            }
        }
        hit = path[path.Count - 1].pos;
        objective = path[path.Count - 2].pos;

        if (path != null && activated)
        {
            List<Node> turnpath = new List<Node>();
            foreach (Node nodo in path)
            {
                if (Array.Exists(GC.ReachablePos, s => s == nodo.pos))
                {
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
        if (GC.grid.WorldToCell(transform.position) == objective)
        {
            Vector3Int tilepos = GC.grid.WorldToCell(transform.position - new Vector3(5f, 5f, 0)) - new Vector3Int(GC.ogx, GC.ogy);

            CustomTileClass tile = GC.tiles[tilepos.x, tilepos.y];
            CustomTileClass tile2 = GC.tiles[hit.x - GC.ogx, hit.y - GC.ogy];
            CDH.AttackDialogue(GetType().ToString(), tile, tile2);
            animator.SetInteger("Anim", 2);
        }
        else
        {
            hasTurn = true;
            SPM.nextTurn(teamNumb, false);
        }
    }
    public override void InstantiatePrefab()
    {
        LastPlayer = GC.tiles[hit.x - GC.ogx, hit.y - GC.ogy].GetPlayer();
        print(GC.grid.WorldToCell(transform.position).x.CompareTo(hit.x));
        print(GC.grid.WorldToCell(transform.position).y.CompareTo(hit.y));

       // print( hit.x + ";" + GC.grid.WorldToCell(transform.position).co);
        _MM.Damage(codeDamage, hit.x - GC.ogx, hit.y - GC.ogy);
       // int dx = hit.x.com
        GC.tiles[hit.x - GC.ogx, hit.y - GC.ogy].GetPlayer().Push(hit.x.CompareTo(GC.grid.WorldToCell(transform.position).x), hit.y.CompareTo(GC.grid.WorldToCell(transform.position).y),8,50);
        hasTurn = true;
        SPM.nextTurn(teamNumb, false);

    }

}
