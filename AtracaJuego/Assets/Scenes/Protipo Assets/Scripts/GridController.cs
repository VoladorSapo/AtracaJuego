using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GridController : MonoBehaviour
{
    private Grid grid;
    public MapManager _mapManager; //Para obtener referencias de las tiles y sus propiedades
    RaycastHit2D objectHit;

    [SerializeField] private Tilemap interactiveMap = null;
    [SerializeField] private Tilemap pathMap = null;
    [SerializeField] private Tilemap Top1 = null;
    [SerializeField] private Tilemap ground = null;
    [SerializeField] private Tile hoverTile = null;
    [SerializeField] private Tile hoverTileNope = null; //Sería usada para indicar que ciertas casillas son inaccesibles, por colisión o por estar fuera de rango
    [SerializeField] private Tile hoverTilePlayer = null; //Para indicar un posible cambio de Player
    public pathFinder _path = null;
    public int ogx,ogy;
    public int distanceRun;
    public Node[,] nodos;
    public Vector2[] posArrayPlayers;
    Tile TileToPlace;
    public bool canMoveHere;

    private Vector3Int previousMousePos = new Vector3Int();

    // Start is called before the first frame update
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        distanceRun =0;
        _path = GetComponent<pathFinder>();
        grid = gameObject.GetComponent<Grid>();
        canMoveHere = true;
        TileToPlace = hoverTile;
        nodos = new Node[pathMap.size.x, pathMap.size.y];
        ogx = pathMap.origin.x;
        ogy = pathMap.origin.y;
        print(nodos.GetLength(1));
        for (int i = 0 ; i < pathMap.size.x; i++)
        {
            for (int j = 0; j <  pathMap.size.y; j++)
            {
                nodos[i, j] = new Node(new Vector3Int(i + ogx, j + ogy), (!Top1.HasTile(new Vector3Int(i+ ogx, j + ogy)) && ground.HasTile(new Vector3Int(i+ ogx, j + ogy))));
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
                switch (objectHit.collider.tag)
                {
                    case "Top1": TileToPlace = hoverTileNope; canMoveHere = false; break;
                    case "Player": TileToPlace = hoverTilePlayer; break;
                }
            }

            if (_mapManager.walkable)
            {
                interactiveMap.SetTile(previousMousePos, null); //Quita la anterior tile de indicación
                interactiveMap.SetTile(mousePos, TileToPlace);
                previousMousePos = mousePos;
            }
        }
        
      /*  if (Input.GetMouseButtonDown(0))
        {
            List<Node> camino = _path.findPath(nodos[0, 0], nodos[grid.WorldToCell(mousePos).x-ogx, grid.WorldToCell(mousePos).y- ogy], nodos,ogx,ogy);
            print(grid.WorldToCell(mousePos).x+" "+ grid.WorldToCell(mousePos).y);
            distanceRun=0;
            foreach (Node nodo in camino)
            {
                print(nodo.pos.x + " " + nodo.pos.y);
                distanceRun++;
            }
            print(distanceRun);
        }*/
    }

    //Transforma la posición del ratón a coordenadas dentro de la Grid
    public List<Node> GetPath(Vector3 position)
    {
        //print(grid.WorldToCell(position).x);
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        List<Node> camino = _path.findPath(nodos[grid.WorldToCell(position).x - ogx, grid.WorldToCell(position).y - ogy], nodos[grid.WorldToCell(previousMousePos).x - ogx, grid.WorldToCell(previousMousePos).y - ogy], nodos, ogx, ogy);
        return camino;
    }
    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }
}