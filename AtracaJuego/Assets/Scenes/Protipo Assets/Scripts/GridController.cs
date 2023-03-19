using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GridController : MonoBehaviour
{
    private Grid grid;
    RaycastHit2D objectHit;

    [SerializeField] private Tilemap interactiveMap = null;
    [SerializeField] private Tilemap pathMap = null;
    [SerializeField] private Tilemap Top1 = null;
    [SerializeField] private Tile hoverTile = null;
    [SerializeField] private Tile hoverTileNope = null; //Sería usada para indicar que ciertas casillas son inaccesibles, por colisión o por estar fuera de rango
    [SerializeField] private Tile hoverTilePlayer = null; //Para indicar un posible cambio de Player
    [SerializeField] private pathFinder _path = null;
    int ogx,ogy;
    public Node[,] nodos;
    Tile TileToPlace;
    public bool canMoveHere;

    private Vector3Int previousMousePos = new Vector3Int();

    // Start is called before the first frame update
    void Start()
    {
        _path = GetComponent<pathFinder>();
        grid = gameObject.GetComponent<Grid>();
        canMoveHere = true;
        TileToPlace = hoverTile;
        nodos = new Node[pathMap.size.x, pathMap.size.y];
        ogx = pathMap.origin.x;
        ogy = pathMap.origin.y;
        for (int i = 0 ; i < pathMap.size.x; i++)
        {
            for (int j = 0; j <  pathMap.size.y; j++)
            {
                nodos[i, j] = new Node(new Vector3Int(i + ogx, j + ogy), !Top1.HasTile(new Vector3Int(i+ ogx, j + ogy)));
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse over -> highlight tile

        Vector3Int mousePos = GetMousePosition();
        if (!mousePos.Equals(previousMousePos))
        {
            Vector2 mousePos2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            objectHit = Physics2D.Raycast(mousePos2, Vector2.zero);
            TileToPlace=hoverTile;
            canMoveHere = true;
            if (objectHit.collider != null)
            {
                switch (objectHit.collider.name)
                {
                    case "Top1": TileToPlace = hoverTileNope; canMoveHere = false; break;
                    case "Player1": TileToPlace = hoverTilePlayer; break;
                    case "Player2": TileToPlace = hoverTilePlayer; break;
                        //Faltan los otros player o usar mejor tags pero bueno
                }
            }
            if (canMoveHere)
            {
                interactiveMap.SetTile(previousMousePos, null); //Quita la anterior tile de indicación
                interactiveMap.SetTile(mousePos, TileToPlace);
                previousMousePos = mousePos;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            List<Node> camino = _path.findPath(nodos[0, 0], nodos[grid.WorldToCell(mousePos).x-ogx, grid.WorldToCell(mousePos).y- ogy], nodos,ogx,ogy);
            print(grid.WorldToCell(mousePos).x+" "+ grid.WorldToCell(mousePos).y);
            foreach (Node nodo in camino)
            {
                print(nodo.pos.x + " " + nodo.pos.y);
            }
        }
    }

    //Transforma la posición del ratón a coordenadas dentro de la Grid
    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }
}