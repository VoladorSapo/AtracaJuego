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
        GC.setReachablePos(transform.position, MaxDistance, true, false, team, false);

        Node nodo = GC.GetNodeEffect(transform.position);
        if (nodo != null)
        {
            List<Node> path = GC.GetPath(transform.position, GC.grid.CellToWorld(nodo.pos),true);
            if(path != null)
            {
                hit = path[path.Count - 1].pos;
                objective = path[path.Count - 2].pos;
                List<Node> turnpath = new List<Node>();
                foreach (Node newnodo in path)
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
}
