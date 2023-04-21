using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using System.Linq;
using UnityEngine.EventSystems;

public class GridController : MonoBehaviour
{
    public Grid grid;
    public MapManager _mapManager; //Para obtener referencias de las tiles y sus propiedades
    RaycastHit2D objectHit;
    [SerializeField] private Tilemap interactiveMap = null;
    [SerializeField] private Tilemap pathMap = null;
    public Tilemap Top;
    public Tilemap ground = null;
    [SerializeField] private Tilemap gasesE = null;
    [SerializeField] private Tilemap gases = null;
    [SerializeField] private Tilemap charcosE = null;
    [SerializeField] private Tilemap charcos = null;
    public Tilemap canMove = null;
    public Tilemap enemyMove = null;

    public Tilemap CanAttackMap = null;
    [SerializeField] private Tile hoverTile = null;
    [SerializeField] private Tile hoverTileNope = null; //Sería usada para indicar que ciertas casillas son inaccesibles, por colisión o por estar fuera de rango
    [SerializeField] private Tile hoverTilePlayer = null; //Para indicar un posible cambio de Player
    [SerializeField] private Tile canMoveTile = null;
    [SerializeField] private Tile enemyMoveTile = null;
    [SerializeField] private Tile attackTile=null;
    
    [SerializeField] EventTileList _eventtileparent;
    public pathFinder _path = null;
    public int ogx, ogy;
    public int distanceRun;
    public Node[,] nodos;
    [SerializeField] gameController _gc;
    public Vector2[] posArrayPlayers;
    Tile TileToPlace;
    public bool canMoveHere;

    private Vector3Int previousMousePos = new Vector3Int();
    public Vector3Int[] ReachablePos; //Basicamente la lista de tiles que puedes seleccionar. Puede ser hasta donde te mueves o donde puedes hacer un ataque
    public Vector3Int[] AttackPos;
    public bool freeCursor; //El cursor solo esta limitado cuando tienen que elegir una posicion. En otros casos lo puedes mover donde sea.
    public CustomTileClass[,] tiles;
    public List<CustomTileClass> tilesConEffects=new List<CustomTileClass>();
    public TileSpriteTable tileTable;
    [SerializeField] private Vector3Int mousePos;
    private StartEffect _SE;
    public ObjectStuff[] _OS;
    void Awake()
    {
        grid = gameObject.GetComponent<Grid>();
        freeCursor = true;
        charcosE=GameObject.Find("CharcosElec").GetComponent<Tilemap>();
        Top=GameObject.Find("Top").GetComponent<Tilemap>();
        gasesE=GameObject.Find("GasesElec").GetComponent<Tilemap>();
        enemyMove = GameObject.Find("enemyMove").GetComponent<Tilemap>();

        //Metodos de otros scripts
        tileTable = GameObject.Find("MapManager").GetComponent<TileSpriteTable>();
        _gc = GameObject.Find("Controller").GetComponent<gameController>();
        _eventtileparent = GameObject.Find("EventTileParent").GetComponent<EventTileList>();
        //De este script
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        distanceRun = 0;
        _path = GetComponent<pathFinder>();
        
        canMoveHere = true;
        TileToPlace = hoverTile;
        nodos = new Node[pathMap.size.x, pathMap.size.y];
        _SE= GameObject.Find("MapManager").GetComponent<StartEffect>();
        

        tiles = new CustomTileClass[pathMap.size.x, pathMap.size.y];
        _OS=FindObjectsOfType<ObjectStuff>();

    }
    public void setGame()
    {

        ogx = pathMap.origin.x;
        ogy = pathMap.origin.y;
        print(pathMap.size + "tamaño");
        tiles = new CustomTileClass[pathMap.size.x, pathMap.size.y];

        for (int i = 0; i < pathMap.size.x; i++)
        {
            for (int j = 0; j < pathMap.size.y; j++)
            {
                print("heh");
                //nodos[i, j] = new Node(new Vector3Int(i + ogx, j + ogy), (!Top1.HasTile(new Vector3Int(i+ ogx, j + ogy)) && ground.HasTile(new Vector3Int(i+ ogx, j + ogy)))); Salta error

                Vector3Int posTiles = new Vector3Int(i + ogx, j + ogy, 0);
                Tile actualTile = ground.GetTile<Tile>(posTiles);
                Vector3Int posTileInGrid = new Vector3Int(i, j, 0);
                print(posTileInGrid);
                int[] stats = tileTable.GetTileStats(actualTile);
                //print("Tile en: "+(i + ogx)+","+(j + ogy)+" tiene el sprite: "+stats[0]);
                
                tiles[i, j] = new CustomTileClass(stats[0], stats[1], stats[2], posTileInGrid, 0);

                //print("Tile guardada con v3 de: "+tiles[i,j].GetTilePos());
                nodos[i, j] = new Node(new Vector3Int(i + ogx, j + ogy), isEmpty(grid.CellToWorld(new Vector3Int(i + ogx, j + ogy)), false, 1)); //Lo dejo así de forma Temporal 
            }

        }
        foreach (ObjectStuff os in _OS){
            os.StartObject();
        }
        _eventtileparent.setgame();
        Component[] eventtiles = _eventtileparent.GetComponentsInChildren<EventTile>();
        foreach (EventTile _event in eventtiles)
        {
            _event.SetGame();
        }
        charcosE.ClearAllTiles();
        charcos.ClearAllTiles();
        gasesE.ClearAllTiles();
        gases.ClearAllTiles();
        charcos.RefreshAllTiles();
        gases.RefreshAllTiles();

        _SE.StartEff();
        SoundManager.InstanceSound.ChangeMusic(0.3f,0.25f,null);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a") && !_gc.Pause)
        {
            mousePos = GetMousePosition();
            int difX = mousePos.x - ogx;
            int difY = mousePos.y - ogy;
            tiles[difX, difY].DisplayStats();
            /*foreach (ObjectStuff os in _OS){
            os.startTurn();
            }*/
            //tiles[difX, difY].addEffect(1,false,0,-1);
            //print("Tile en: " + (0 + difX) + "," + (0 + difY) + " tiene el sprite: " + tiles[0 + difX, 0 + difY].tileSpriteId + " y tiene las propiedades " + tiles[0 + difX, 0 + difY].tileState + " y " + tiles[0 + difX, 0 + difY].tileEffect);
            //print("y " + tiles[difX, difY].tilePos);
        }

        if (Input.GetKeyDown("t") && !_gc.Pause)
        {
            mousePos = GetMousePosition();
            int difX = mousePos.x - ogx;
            int difY = mousePos.y - ogy;
            tiles[difX,difY].cleanEffects(2);
            //print("Tile en: " + (0 + difX) + "," + (0 + difY) + " tiene el sprite: " + tiles[0 + difX, 0 + difY].tileSpriteId + " y tiene las propiedades " + tiles[0 + difX, 0 + difY].tileState + " y " + tiles[0 + difX, 0 + difY].tileEffect);
            //print("y " + tiles[difX, difY].tilePos);
        }
        if (!_gc.Pause) {
            mousePos = GetMousePosition();
        }
        if (!mousePos.Equals(previousMousePos) && !_gc.Pause || EventSystem.current.IsPointerOverGameObject())
        {

            /*Vector2 mousePos2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            objectHit = Physics2D.Raycast(mousePos2, Vector2.zero);
            TileToPlace = hoverTile;
            canMoveHere = true;
            if (objectHit.collider != null)
            {
                switch (objectHit.collider.tag)
                {
                    case "Top1": TileToPlace = hoverTileNope; canMoveHere = false; break;
                    case "Player": TileToPlace = hoverTilePlayer; break;
                }
            }*/
            interactiveMap.SetTile(previousMousePos, null); //Quita la anterior tile de indicación
            if (!EventSystem.current.IsPointerOverGameObject()) { 
            interactiveMap.SetTile(mousePos, TileToPlace);
            previousMousePos = mousePos;
        }
        }

    }

    //Transforma la posición del ratón a coordenadas dentro de la Grid
    public List<Node> GetPath(Vector3 startpos, Vector3 endpos, bool team,bool safe,bool throughTeam, int distance)
    {
        if (ReachablePos.Contains(grid.WorldToCell(endpos))||team)
        {
            //print(grid.WorldToCell(position).x);
            Vector3 mouseWorldPos = endpos;
            if (tiles[grid.WorldToCell(mouseWorldPos).x - ogx, grid.WorldToCell(mouseWorldPos).y - ogy].GetPlayer() == null || team)
            {
                List<Node> camino = null;
                if (tiles[grid.WorldToCell(endpos).x - ogx, grid.WorldToCell(endpos).y - ogy].TileIsSafe()) {
                    camino = _path.findPath(nodos[grid.WorldToCell(startpos).x - ogx, grid.WorldToCell(startpos).y - ogy], nodos[grid.WorldToCell(endpos).x - ogx, grid.WorldToCell(endpos).y - ogy], nodos, ogx, ogy, team, safe,throughTeam);
                    print(camino == null);
                }
                if(camino == null && safe || camino != null && camino.Count > distance && safe)
                {
                    print("jdr");
                   tiles[grid.WorldToCell(startpos).x - ogx, grid.WorldToCell(startpos).y - ogy].GetPlayer().Caca();
                    camino = _path.findPath(nodos[grid.WorldToCell(startpos).x - ogx, grid.WorldToCell(startpos).y - ogy], nodos[grid.WorldToCell(endpos).x - ogx, grid.WorldToCell(endpos).y - ogy], nodos, ogx, ogy, team, false,throughTeam);

                }
                return camino;
            }
        }
        else
        {
            print("quien es ese wachin");
        }
        return null;
        }
    public Node GetNodeEffect(Vector3 startpos,int distance)
    {
        return _path.buscarNodoEffect(nodos[grid.WorldToCell(startpos).x - ogx, grid.WorldToCell(startpos).y - ogy], nodos, tiles, ogx, ogy,distance);
    }
    //Cambio visual para el mapa de tiles entre mover o atacar
    public void changeAttackOrMove(bool displayMode){ //Falso, mover. True, atacar
        if(displayMode){CanAttackMap.ClearAllTiles(); CanAttackMap.RefreshAllTiles();}else{canMove.ClearAllTiles(); canMove.RefreshAllTiles();}
    }
    public Vector3Int GetMousePosition()
    {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    
    }

    public void setReachablePos(Vector3 pos, int var, bool isDist, int showTiles, bool team, bool reset,bool throughTeam)
    {   
        List<Node> reachableNodes;
        if (!reset) {
            Vector3Int convertedPos = grid.WorldToCell(pos);
            reachableNodes = _path.nodosEnDistancia(nodos[convertedPos.x - ogx, convertedPos.y - ogy], nodos, tiles, ogx, ogy, var, isDist, team,throughTeam);
            ReachablePos = new Vector3Int[reachableNodes.Count];
            if (showTiles < 2) {canMove.ClearAllTiles(); }
            for (int i = 0; i < reachableNodes.Count; i++)
            {
                ReachablePos[i] = reachableNodes[i].pos;
                if (showTiles == 1)
                {
                    canMove.SetTile(ReachablePos[i], canMoveTile);
                }
                if (showTiles == 2)
                {
                    enemyMove.SetTile(ReachablePos[i], enemyMoveTile);
                }
            }
            canMove.RefreshAllTiles();
            freeCursor = false;
        } else { if (showTiles < 2) { Debug.LogWarning("aiuda"); canMove.ClearAllTiles(); CanAttackMap.RefreshAllTiles(); reachableNodes = null; } else { enemyMove.ClearAllTiles(); } }
        }
    
    //
    public List<Node> setAttackPos(Vector3 pos, int range, bool isDist, bool showTiles, bool team, int playerMode, bool reset)
    {
        List<Node> attackableNodes;
        if(!reset){
        Vector3Int convertedPos = grid.WorldToCell(pos);
        attackableNodes = _path.nodosEnAtaque(nodos[convertedPos.x - ogx, convertedPos.y - ogy], nodos, tiles, ogx, ogy, range, isDist, team, playerMode);
        AttackPos = new Vector3Int[attackableNodes.Count];
        CanAttackMap.ClearAllTiles();
        print("jajaja");
        for (int i = 1; i < attackableNodes.Count; i++)
        {
            AttackPos[i] = attackableNodes[i].pos;
            if (showTiles)
            {
                CanAttackMap.SetTile(AttackPos[i], attackTile);
            }
        }
        CanAttackMap.RefreshAllTiles();
        freeCursor = false;
        }else{  CanAttackMap.ClearAllTiles(); CanAttackMap.RefreshAllTiles(); attackableNodes=null;}
        return attackableNodes;
    }

    //
   /* public void cvv(Vector3Int pos){
                List<Node> reachableNodes = _path.nodosEnDistancia(nodos[pos.x - ogx, pos.y - ogy], nodos, tiles, ogx, ogy, tiles[pos.x - ogx, pos.y - ogy].GetTileEffect(), false, false);

    }*/
public bool isEmpty(Vector3 position, bool wantMove, int mode) //wantMove sirve para diferenciar cuando te quieres mover a la tile a cuando quieres saber si es accesible
    {
        //mode=1 Funciones para moverse
        //mode=2 Funciones para atacar
        bool empty=true;
        Vector3Int posInted;
        switch(mode){
        case 1:
        if ((tiles[grid.WorldToCell(position).x - ogx, grid.WorldToCell(position).y - ogy].tileState >= 5) || (!ReachablePos.Contains(grid.WorldToCell(position)) && wantMove) ||(tiles[grid.WorldToCell(position).x - ogx, grid.WorldToCell(position).y - ogy].GetPlayer() != null))
        {
            empty=false;
        }else { empty =true;} break;

        case 2:
        posInted= new Vector3Int(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y), 0);
        if (CanAttackMap.HasTile(posInted))
        {
            
            empty=false;
        }else{empty=true;} break;
        }

        return empty;
       
        /*if (tiles[grid.WorldToCell(position).x - ogx, grid.WorldToCell(position).y - ogy].tileState == 8 || (!ReachablePos.Contains(grid.WorldToCell(position)) && wantMove)|| tiles[grid.WorldToCell(position).x - ogx, grid.WorldToCell(position).y - ogy].GetPlayer() != null)
        {
            return false;
        }
        return true;*/
    }
    public bool isWalkable(Vector3 position, bool wantMove, bool team, bool safe, bool throughTeam) //Por ejemplo un personaje de tu equipo que puedes atravesar pero no te puedes poner encima
    {
       
      /*  if (tiles[grid.WorldToCell(position).x - ogx, grid.WorldToCell(position).y - ogy].GetPlayer() != null)
        {
            print((tiles[grid.WorldToCell(position).x - ogx, grid.WorldToCell(position).y - ogy].GetPlayer().getTeam() != team) + tiles[grid.WorldToCell(position).x - ogx, grid.WorldToCell(position).y - ogy].GetPlayer().name);
        }*/
        if (tiles[grid.WorldToCell(position).x - ogx, grid.WorldToCell(position).y - ogy].tileState >= 8 || /*(!ReachablePos.Contains(grid.WorldToCell(position)) && wantMove) */ (tiles[grid.WorldToCell(position).x - ogx, grid.WorldToCell(position).y - ogy].GetPlayer() != null && (!throughTeam || tiles[grid.WorldToCell(position).x - ogx, grid.WorldToCell(position).y - ogy].GetPlayer().getTeam() != team
         || tiles[grid.WorldToCell(position).x - ogx, grid.WorldToCell(position).y - ogy].GetPlayer().isObject))||safe && !tiles[grid.WorldToCell(position).x - ogx, grid.WorldToCell(position).y - ogy].TileIsSafe())
        {
            return false;
        }
        return true;
    }

}