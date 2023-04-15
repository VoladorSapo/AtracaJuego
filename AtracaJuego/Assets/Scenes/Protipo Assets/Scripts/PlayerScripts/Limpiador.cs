using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Limpiador : EnemyCharacter
{
    // Start is called before the first frame update


    // Update is called once per frame
    public override void startTurn()
    {

        Node nodo = GC.GetNodeEffect(transform.position);
        if (nodo != null)
        {
            List<Node> path = GC.GetPath(transform.position, GC.grid.CellToWorld(nodo.pos),true);
            print(path.Count);
            if(path != null)
            {
                hit = path[path.Count - 1].pos;
                objective = path[path.Count - 2].pos;
                List<Node> turnpath = new List<Node>();
                GC.setReachablePos(transform.position, MaxDistance, true, false, team, false);
                print(GC.ReachablePos.Length);
                foreach (Node newnodo in path)
                {
                    if (Array.Exists(GC.ReachablePos, s => s == newnodo.pos))
                    {
                        turnpath.Add(newnodo);
                    }
                    else
                    {

                        break;
                    }
                }
                print("jujujuj");
                path = turnpath;

                startMove(path);
            }
            else
            {
                print("nulaso2");
                ChangeMapShown(0);

            }
            print(nodo.pos - new Vector3(GC.ogx,GC.ogy));
        }
        else
        {
            print("nulaso");
            ChangeMapShown(0);
        }

    }
    public override void ChangeMapShown(int setMode)
    {
        if (GC.grid.WorldToCell(transform.position) == objective)
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
        GC.tiles[hit.x - GC.ogx, hit.y - GC.ogy].addEffect(0, true, -1, -1);
        hasTurn = true;
        SPM.nextTurn(teamNumb, false);

    }
}
