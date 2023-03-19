using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node
{
    public bool canWalk;
    public Vector3Int pos;
    public int gCost;
    public int hCost;
    public int fCost;

    public Node previousNode;

    public Node (Vector3Int newpos,bool walk)
    {
        pos = newpos;
        canWalk = walk;
    }
    public void CalculateF()
    {
        fCost = gCost + hCost;
    }
    public void Reset()
    {
        gCost = int.MaxValue;
        CalculateF();
        previousNode = null;
    }
}
