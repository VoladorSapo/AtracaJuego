using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Limpiador : EnemyCharacter
{
    // Start is called before the first frame update

    [SerializeField] GameObject spawn;
    [SerializeField] bool hasClean;
    // Update is called once per frame
    public override void startTurn()
    {
        hasClean = false;
        Node nodo = GC.GetNodeEffect(transform.position);
        if (nodo != null)
        {
            List<Node> path = GC.GetPath(transform.position, GC.grid.CellToWorld(nodo.pos),true, false);
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
        if (hasClean)
        {
            hasTurn = true;
            SPM.nextTurn(teamNumb, false);
        }
       else if (GC.grid.WorldToCell(transform.position) == objective && !hasClean)
        {
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
        GC.tiles[hit.x - GC.ogx, hit.y - GC.ogy].addEffect(0, true, -1, -1);
        hasClean = true;
       

    }
    public override void BeIdle()
    {
        base.BeIdle();
        goBack();
    }
    public void goBack()
    {
        List<Node> path = GC.GetPath(transform.position, spawn.transform.position, true,false);
        if(path!= null)
        {
            GC.setReachablePos(transform.position, MaxDistance, true, false, team, false);
            print(GC.ReachablePos.Length);
            List<Node> turnpath = new List<Node>();

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
        
    }
}
