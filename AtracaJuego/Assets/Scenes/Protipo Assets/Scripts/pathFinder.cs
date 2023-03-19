using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class pathFinder : MonoBehaviour
{
    private List<Node> openList;
    private List<Node> closeList;
    
    public List<Node> findPath(Node startNode, Node endNode, Node[,] nodos,int ogx,int ogy)
    {
        List<Node> list = new List<Node>();
        openList = new List<Node> { startNode};
        closeList = new List<Node> ();
        for (int i =0; i < nodos.GetLength(0); i++)
        {
            for (int j = 0; j <  nodos.GetLength(1); j++)
            {
                nodos[i, j].Reset();
            }

        }
        startNode.gCost = 0;
        startNode.hCost = Distance(startNode,endNode);
        startNode.CalculateF();
        
        while(openList.Count > 0)
        {
            Node currentNode = LowestFCost(openList);
            if (currentNode == endNode)
            {
                return fullPath(currentNode);
            }
            openList.Remove(currentNode);
            closeList.Add(currentNode);
            foreach (Node nodoAdayacente in nodosAdyacentes(currentNode,nodos,ogx,ogy))
            {
                if (closeList.Contains(nodoAdayacente)) continue;
                if (!nodoAdayacente.canWalk) continue;
                int tempG = currentNode.gCost + Distance(currentNode, nodoAdayacente);
                if(tempG < nodoAdayacente.gCost)
                {
                    nodoAdayacente.previousNode = currentNode;
                    nodoAdayacente.gCost = tempG;
                    nodoAdayacente.hCost = Distance(nodoAdayacente, endNode);
                    nodoAdayacente.CalculateF();
                    if (!openList.Contains(nodoAdayacente))
                    {
                        openList.Add(nodoAdayacente);
                    }
                }
            }
        }
        return null;
    }
    private List<Node> nodosAdyacentes(Node nodo,Node[,] nodos,int ogx,int ogy)
    {
        List<Node> list = new List<Node>();
        if(nodo.pos.x - ogx + 1 <= nodos.GetLength(0))
        {
            list.Add(nodos[nodo.pos.x - ogx + 1, nodo.pos.y - ogy]);
        }
        if (nodo.pos.x -ogx - 1 >= 0)
        {
            list.Add(nodos[nodo.pos.x - ogx - 1, nodo.pos.y - ogy]);
        }
        if (nodo.pos.y -ogy + 1 <= nodos.GetLength(1))
        {
            list.Add(nodos[nodo.pos.x - ogx, nodo.pos.y - ogy + 1]);
        }
        if (nodo.pos.y -ogy - 1 >= 0)
        {
            list.Add(nodos[nodo.pos.x - ogx, nodo.pos.y- ogy - 1]);
        }

        return list;
    }
    private List<Node> fullPath(Node endNode)
    {
        List<Node> list = new List<Node>();
        list.Add(endNode);
        Node currentNode = endNode;
        while(currentNode.previousNode != null)
        {
            list.Add(currentNode.previousNode);
            currentNode = currentNode.previousNode;
        }
        list.Reverse();
        return list;
    }
    private Node LowestFCost(List<Node> nodes)
    {
        Node lowCost = nodes[0];
        for (int i = 0; i < nodes.Count; i++)
        {
            if(nodes[i].fCost < lowCost.fCost)
            {
                lowCost = nodes[i];
            }
        }
        return lowCost;
    }
    private int Distance(Node a, Node b)
    {

        return Mathf.Abs(b.pos.x - a.pos.x) + Mathf.Abs(b.pos.y - a.pos.y);
    }

}
