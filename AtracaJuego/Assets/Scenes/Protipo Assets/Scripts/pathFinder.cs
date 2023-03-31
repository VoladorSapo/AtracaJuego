using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class pathFinder : MonoBehaviour
{
    private List<Node> openList;
    private List<Node> closeList;
    private List<Node> nearList;
    public GridController GC;
    public List<Node> findPath(Node startNode, Node endNode, Node[,] nodos,int ogx,int ogy,bool team)
    {
        List<Node> list = new List<Node>();
        openList = new List<Node> {startNode};
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
        if(nodo.pos.x - ogx + 1 < nodos.GetLength(0))
        {
            list.Add(nodos[nodo.pos.x - ogx + 1, nodo.pos.y - ogy] );
        }
        if (nodo.pos.x -ogx - 1 >= 0)
        {
            list.Add(nodos[nodo.pos.x - ogx - 1, nodo.pos.y - ogy]);
        }
        if (nodo.pos.y -ogy + 1 < nodos.GetLength(1))
        {
            list.Add(nodos[nodo.pos.x - ogx, nodo.pos.y - ogy + 1]);
        }
        if (nodo.pos.y -ogy - 1 >= 0)
        {
            list.Add(nodos[nodo.pos.x - ogx, nodo.pos.y- ogy - 1]);
        }

        return list;
    }
    public List<Node> nodosEnDistancia(Node nodo,Node[,] nodos,CustomTileClass[,] tiles, int ogx, int ogy,int var,bool isDist,bool team)//Saca todas las posiciones a cierta distancia o de un tipo de elemnto juntos todos. var es distancia/tipo y isDist si busca distancia o tipo
    {
        nearList = new List<Node>();
        List<Node> borderList = new List<Node>();
        nearList.Add(nodo);
        borderList.Add(nodo);
        int vueltas = 0;
        int tilesoftype = 0;
        bool Continue = isDist ? vueltas < var : tilesoftype <= 0;
        while (Continue)
        {
            tilesoftype = 0;
            List<Node> newBorderList = new List<Node>(); ;
            foreach (Node nodoBorde in borderList)
            {
                List<Node> supportList = nodosAdyacentes(nodoBorde,nodos,ogx,ogy);
                for (int i = 0; i < supportList.Count; i++)
                {
                    bool shouldAdd = isDist ? GC.isWalkable(GC.grid.CellToWorld(supportList[i].pos),false,team) : tiles[supportList[i].pos.x -ogx, supportList[i].pos.y-ogy].GetTileEffect() == var;
                    //print(nearList.Contains(supportList[i]) + " " + supportList[i].pos);
                    if(!nearList.Contains(supportList[i]) && shouldAdd && !newBorderList.Contains(supportList[i])){
                        newBorderList.Add(supportList[i]);
                        //print(supportList[i].pos);
                        tilesoftype++;
                    }
                }
            }
            foreach(Node nodor in newBorderList)
            {
               //ogx loco
                if (GC.isEmpty(GC.grid.CellToWorld(nodor.pos), false, 1) || !isDist)
                {
                
                    nearList.AddRange(newBorderList);
                }
            }
            borderList.Clear();
            borderList.AddRange(newBorderList);
            vueltas++;
            Continue = isDist ? vueltas < var : tilesoftype <= 0;
        }
        return nearList;
    }

    public List<Node> nodosEnAtaque(Node nodo,Node[,] nodos,CustomTileClass[,] tiles, int ogx, int ogy,int var,bool isDist,bool team, int playerMode)//Saca todas las posiciones a cierta distancia o de un tipo de elemnto juntos todos. var es distancia/tipo y isDist si busca distancia o tipo
    {
        nearList = new List<Node>();
        List<Node> borderList = new List<Node>();
        nearList.Add(nodo);
        borderList.Add(nodo);
        int vueltas = 0;
        int tilesoftype = 0;
        bool Continue = isDist ? vueltas < var : tilesoftype <= 0;
        
        switch(playerMode){
        case 1: //Fuego y empuje
        Vector3Int posFE=nodo.pos;
        if(GC.tiles[posFE.x - ogx +1, posFE.y - ogy].GetTileState()<8){nearList.Add(nodos[posFE.x - ogx +1, posFE.y - ogy]);}
        if(GC.tiles[posFE.x - ogx -1, posFE.y - ogy].GetTileState()<8){nearList.Add(nodos[posFE.x - ogx -1, posFE.y - ogy]);}
        if(GC.tiles[posFE.x - ogx , posFE.y - ogy +1].GetTileState()<8){nearList.Add(nodos[posFE.x - ogx , posFE.y - ogy +1]);}
        if(GC.tiles[posFE.x - ogx , posFE.y - ogy -1].GetTileState()<8){nearList.Add(nodos[posFE.x - ogx , posFE.y - ogy -1]);}
        break;
        
        case 2: //Gas
        Vector3Int posG=nodo.pos-new Vector3Int(3,3,0); //offset de Rango del ataque/2
        for(int i=0; i<7; i++){
            for(int j=0; j<7; j++){
                if(GC.tiles[posG.x - ogx +i, posG.y - ogy +j].GetTileState()<8){
                if((i==3 || j==3) && i!=j){
                print(i+","+j);
                nearList.Add(nodos[posG.x - ogx + i, posG.y - ogy + j]);
                }
                }
            }
        }
        
        break;

        case 3: //Hielo
        Vector3Int posH=nodo.pos-new Vector3Int(2,2,0);
        
        for(int i=0; i<5; i++){
            for(int j=0; j<5; j++){
                if(GC.tiles[posH.x - ogx +i, posH.y - ogy +j].GetTileState()<8){
                nearList.Add(nodos[posH.x - ogx + i, posH.y - ogy + j]);
                }
            }
        }
        
        break;

        case 4: //Electricidad
        Vector3Int posE=nodo.pos-new Vector3Int(2,2,0);
        if(GC.tiles[posE.x - ogx +2, posE.y - ogy].GetTileState()<5){nearList.Add(nodos[posE.x - ogx +2, posE.y - ogy]);}
        if(GC.tiles[posE.x - ogx, posE.y - ogy +2].GetTileState()<5){nearList.Add(nodos[posE.x - ogx, posE.y - ogy +2]);}
        if(GC.tiles[posE.x - ogx +2, posE.y - ogy +4].GetTileState()<5){nearList.Add(nodos[posE.x - ogx +2, posE.y - ogy +4]);}
        if(GC.tiles[posE.x - ogx +4, posE.y - ogy +2].GetTileState()<5){nearList.Add(nodos[posE.x - ogx +4, posE.y - ogy +2]);}

        break;
        }

        return nearList;
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
