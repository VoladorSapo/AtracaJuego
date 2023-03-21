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

    public CustomTileClass[,] tiles;
    public TileSpriteTable tileTable;
    [SerializeField] private Vector3Int mousePos;
    void Awake()
    {
        //Metodos de otros scripts
        tileTable=GameObject.Find("MapManager").GetComponent<TileSpriteTable>();

        //De este script
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

        tiles=new CustomTileClass[pathMap.size.x, pathMap.size.y];

        for (int i = 0 ; i < pathMap.size.x; i++)
        {
            for (int j = 0; j <  pathMap.size.y; j++)
            {
                print(i + ogx);
                
                //nodos[i, j] = new Node(new Vector3Int(i + ogx, j + ogy), (!Top1.HasTile(new Vector3Int(i+ ogx, j + ogy)) && ground.HasTile(new Vector3Int(i+ ogx, j + ogy)))); Salta error

                Vector3Int posTiles=new Vector3Int(i + ogx ,j + ogy,0);
                Tile actualTile = ground.GetTile<Tile>(posTiles);
                Vector3Int posTileInGrid= new Vector3Int (i,j,0);

                int[] stats=tileTable.GetTileStats(actualTile);
                print("Tile en: "+(i + ogx)+","+(j + ogy)+" tiene el sprite: "+stats[0]);
                tiles[i,j]= new CustomTileClass(stats[0],stats[1],stats[2],posTileInGrid);
                print("Tile guardada con v3 de: "+tiles[i,j].GetTilePos());
                nodos[i, j] = new Node(new Vector3Int(i + ogx, j + ogy), isWakable(new Vector3Int(i + ogx, j + ogy))); //Lo dejo así de forma Temporal 
            }

        }

        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("a")){
            mousePos = GetMousePosition();
            int difX=mousePos.x-ogx;
            int difY=mousePos.y-ogy;
            
            print("Tile en: "+(0 + difX)+","+(0 + difY)+" tiene el sprite: "+tiles[0 + difX, 0 + difY].tileSpriteId+" y tiene las propiedades "+tiles[0 + difX, 0 + difY].tileState+" y "+tiles[0 + difX, 0 + difY].tileEffect);
            print("y "+tiles[difX,difY].tilePos);
        }

        if(Input.GetKeyDown("s")){
            mousePos = GetMousePosition();
            int difX=mousePos.x-ogx;
            int difY=mousePos.y-ogy;
            print("s");
            tiles[0 + difX, 0 + difY].SetTileStats(1,1,0);
            Vector3Int pos=new Vector3Int(mousePos.x,mousePos.y,0);
            Tile newTileToPlace=tileTable.SetNewTile(1);
            ground.SetTile(pos,newTileToPlace);
            ground.RefreshTile(pos);

        }

        mousePos = GetMousePosition();
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
                interactiveMap.SetTile(previousMousePos, null); //Quita la anterior tile de indicación
                interactiveMap.SetTile(mousePos, TileToPlace);
                previousMousePos = mousePos;
            if (_mapManager.walkable)
            {
                
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
    public List<Node> GetPath(Vector3 startpos,Vector3 endpos)
    {
        //print(grid.WorldToCell(position).x);
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        List<Node> camino = _path.findPath(nodos[grid.WorldToCell(startpos).x - ogx, grid.WorldToCell(startpos).y - ogy], nodos[grid.WorldToCell(endpos).x - ogx, grid.WorldToCell(endpos).y - ogy], nodos, ogx, ogy);
        return camino;
    }
    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }
    public bool isWakable(Vector3 position)
    {
        print(position.x);
        print(grid.WorldToCell(position).x - ogx);
        print(tiles.GetLength(0));
        print(position.y);
        print(grid.WorldToCell(position).y - ogy);
        print(tiles.GetLength(1));
        if (tiles[grid.WorldToCell(position).x - ogx, grid.WorldToCell(position).y - ogy].tileState == 1)
        {
            return false;
        }
        return true;
    }
}