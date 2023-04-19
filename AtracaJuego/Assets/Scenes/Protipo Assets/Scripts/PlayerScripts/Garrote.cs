using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Garrote : EnemyCharacter
{
    // Start is called before the first frame update
     //The tile of the player you want to hit

    
     protected override void Awake(){
        base.Awake();
        effect=-1;
     }
    public override void startTurn()
    {
        GC.setReachablePos(transform.position, MaxDistance, true, false, team, false);

        print(name + "Start");
        int[] distancias = getDistances();
        List<Node> path = new List<Node>();
        string elname = "Null";
        int currentlength = detectDistance;

        for (int i = 0; i < distancias.Length; i++)
        {
            if (distancias[i] <= currentlength)
            {
                print(name);
                List<Node> newpath = GC.GetPath(transform.position, protas.players[i].transform.position, true, false);
                if (newpath != null && (newpath.Count < path.Count || path.Count == 0))
                {
                    print(newpath.Count);
                    elname = protas.players[i].name;
                    if (newpath.Count < detectDistance)
                    {
                        activated = true;
                    }
                    currentlength = newpath.Count;
                    path = newpath;
                }
            }
            else
            {
                print(distancias[i] + " " + detectDistance + name);
            }
        }

        if (path != null && activated)
        {

            print(path.Count);
            hit = path[path.Count - 1].pos;
            objective = path[path.Count - 2].pos;
            List<Node> turnpath = new List<Node>();
            foreach (Node nodo in path)
            {
                if (Array.Exists(GC.ReachablePos, s => s == nodo.pos) ||GC.tiles[nodo.pos.x - GC.ogx, nodo.pos.y - GC.ogy].GetPlayer().team == team)
                {
                    turnpath.Add(nodo);
                }
            }
            List<Node> deletelist = new List<Node>();
            for (int i = turnpath.Count-1; i >= 0; i--)
            {
                print(i);
                if(GC.tiles[turnpath[i].pos.x - GC.ogx, turnpath[i].pos.y - GC.ogy].GetPlayer() != null && GC.tiles[turnpath[i].pos.x - GC.ogx, turnpath[i].pos.y - GC.ogy].GetPlayer() != null == team)
                {
                    deletelist.Add(turnpath[i]);
                }
                else
                {
                    break;
                }
            }
            foreach (Node nodo in deletelist)
            {
                turnpath.Remove(nodo);
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
    public int[] getDistances()
    {
        int[] distances = new int[protas.players.Count];
        for (int i = 0; i < distances.Length; i++)
        {
            Vector3Int mypos = grid.WorldToCell(transform.position /*- new Vector3(5f, 5f, 0)*/);
            print(mypos);
            Vector3Int theirpos = grid.WorldToCell(protas.players[i].transform.position /*- new Vector3(5f, 5f, 0)*/);
            print((theirpos-new Vector3Int(GC.ogx,GC.ogy,0)) + protas.players[i].name);
            Vector3Int dis = mypos - theirpos;
            print(dis + protas.players[i].name);
            distances[i] = Mathf.Abs(dis.x) + Mathf.Abs(dis.y);
        }
        return distances;
    }
    public override void ChangeMapShown(int setMode)
    {
        
        if(GC.grid.WorldToCell(transform.position) == objective)
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
        _MM.Damage(codeDamage, hit.x - GC.ogx, hit.y - GC.ogy);
        hasTurn = true;
        print("waka waka");
        SPM.nextTurn(teamNumb, false);

    }


}
