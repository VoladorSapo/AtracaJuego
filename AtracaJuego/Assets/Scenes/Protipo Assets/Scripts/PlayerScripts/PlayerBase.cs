using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerBase : MonoBehaviour
{
    protected int effect;
    protected bool bypass;
    protected int direction;
    [SerializeField] private Grid grid;
    [SerializeField] public int Mode; //Si esta atacando (2),moviendose(1) o ninguna (0)
    public GridController GC;
    public gameController _gamecontroller;
    [SerializeField] private tunController _turnController;
    [SerializeField] protected ScriptPlayerManager SPM;
    [SerializeField] protected int MaxDistance;
    private int[] prevX= new int[5];
    private int[] prevY= new int[5];
    public bool team;
    protected bool moving;
   [SerializeField] protected bool hasTurn;
    [SerializeField] protected bool hasMove;
    [SerializeField] protected bool hasAttack;
    public int Cooldowns=0;
    public Animator animator;
    public SpriteRenderer sprite;
    public int teamNumb;//El numero del jugador dentro del equipo
    [SerializeField] public bool alive;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int currentHealth;
    List<Node> nodes;
    private PlaceTiles PT;

    bool isRunning=false;
    //Método Principal
    /*Método Secundario*/
    // Start is called before the first frame update
    protected virtual void Awake(){
        grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
        GC = grid.GetComponent<GridController>();
        PT=FindObjectOfType<PlaceTiles>();
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        _turnController= GameObject.Find("Controller").GetComponent<tunController>();
        _gamecontroller=GameObject.Find("Controller").GetComponent<gameController>();
    }
    protected virtual void Start()
    {
        
        //startGame();

        //Vector3Int posGrid = grid.WorldToCell(transform.position);
        //GC.tiles[posGrid.x-GC.ogx, posGrid.y-GC.ogy].setPlayer(this);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (moving)
        {
           
            transform.position = Vector3.MoveTowards(transform.position, grid.CellToWorld(nodes[0].pos) + new Vector3(5f, 5f, 0), Time.deltaTime * 50);
            //transform.position = Vector3.MoveTowards(transform.position, grid.CellToWorld(nodes[0].pos) + new Vector3(0.5f, 0.5f, 0), 0.1f);
            if (Vector3.Distance(grid.CellToWorld(nodes[0].pos) + new Vector3(5f, 5f, 0), transform.position) < 0.00001f)
            {
                print("Batido PLeNysHakE" + this.name);
               // print(grid.CellToWorld(nodes[0].pos) + new Vector3(5f, 5f, 0));
                //print(nodes[0].pos);
                //print(grid.CellToWorld(nodes[0].pos));
                transform.position = grid.CellToWorld(nodes[0].pos) + new Vector3(5f, 5f, 0);
                //print(nodes[0].pos);
                nodes.RemoveAt(0);
                if (nodes.Count <= 0)
                {
                    moving = false;
                    animator.SetInteger("Anim", 0);
                    sprite.sortingOrder = -(grid.WorldToCell(transform.position).y- GC.ogy);
                    //Turn();
                    Vector3Int tilepos = grid.WorldToCell(transform.position- new Vector3(5f, 5f, 0))-new Vector3Int(GC.ogx,GC.ogy);

                    //print(tilepos);
                    CustomTileClass tile = GC.tiles[tilepos.x, tilepos.y];
                    tile.setPlayer(this);
                    hasMove = true;
                    if (hasAttack)
                    {
                        print("endturn");
                        // SPM.endTurn(teamNumb, false);
                        ChangeMapShown(0);
                    }
                    else
                    {
                        ChangeMapShown(2);
                    }
                }
                else
                {
                    print("icamefromalanddownunder");
                    print(-grid.WorldToCell(transform.position).y);
                    sprite.sortingOrder = -(grid.WorldToCell(transform.position).y - GC.ogy);
                    if (nodes[0].pos.x > grid.WorldToCell(transform.position).x)
                    {
                        sprite.flipX = false;
                    }
                    else if(nodes[0].pos.x < grid.WorldToCell(transform.position).x)
                    {
                        sprite.flipX = true;
                    }
                }
            }
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other){}

    public virtual void startTurn() 
    { }
    public virtual void ChangeMapShown(int setMode) { }
    


    
    //Mueve al jugador a la posición indicada
    protected virtual void Move(Vector3 position)
    {
        
        List<Node> newPos = GC.GetPath(this.transform.position,position,team);
        Debug.LogWarning("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAS" + name);
        if (newPos != null &&  newPos.Count > 0)
        {
            startMove(newPos);
        }
        
    }
    protected virtual void startMove(List<Node> newPos)
    {
        if (newPos != null && newPos.Count > 0)
        {
            Vector3Int tilepos = grid.WorldToCell(transform.position) - new Vector3Int(GC.ogx, GC.ogy);
            CustomTileClass tile = GC.tiles[tilepos.x, tilepos.y];
            tile.setPlayer(null);
            print(name);
            animator.SetInteger("Anim", 1);
            print(newPos.Count);
            nodes = newPos;
            moving = true;
            //turn = false;
        }
    }
    public virtual void Turn()
    {
        //turn = true;
    }

    public virtual bool GetAlive()
    {
        return alive;
    }

    public virtual void pressWinTile()
    {

    }
    public virtual void setGame()
    {
        
        Vector3Int tilepos = grid.WorldToCell(transform.position) - new Vector3Int(GC.ogx, GC.ogy);
        print(transform.position);
        print(tilepos + name);
        CustomTileClass tile = GC.tiles[tilepos.x, tilepos.y];
        sprite.sortingOrder = -(tilepos.y);
        tile.setPlayer(this);
        alive = true;
        currentHealth = maxHealth;
    }
    public virtual void Die()
    {
        alive = false;
        Vector3Int tilepos = grid.WorldToCell(transform.position);
        CustomTileClass tile = GC.tiles[tilepos.x -GC.ogx, tilepos.y -GC.ogy];
        //tile.setPlayer(null);
        sprite.enabled = false;
        SPM.playerDie(this);
    }

 
    public ScriptPlayerManager getSPM()
    {
        return SPM;
    }
    public virtual void loseHealth(int health)
    {
        animator.SetInteger("Anim", 4);
        currentHealth -= health;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual int GetMaxHealth()
    {
        return maxHealth;
    }

    public virtual int GetCurrentHealth()
    {
        return currentHealth;
    }
    public virtual void InstantiatePrefab()
    {

    }

    public virtual void BeIdle(){
        animator.SetInteger("Anim",0);
    }

    public bool getTurn()
    {
        return hasTurn;
    }
    public bool getTeam()
    {
        return team;
    }
    public bool getAttack()
    {
        return hasAttack;
    }
    public bool getMove()
    {
        return hasMove;
    }
    public virtual void setTurn(bool newTurn)
    {
       hasAttack= hasMove= hasTurn = newTurn;
    }

    public void Push(int dx, int dy, int distance){
        
        if(!isRunning){StartCoroutine(GetPush(dx,dy, distance));}
    }
    public IEnumerator GetPush(int dx, int dy, int distance){
        isRunning=true;
        Vector3Int tileO = GC.grid.WorldToCell(transform.position);
        int x=tileO.x-GC.ogx;
        int y=tileO.y-GC.ogy;
        
        WaitForSeconds wfs=new WaitForSeconds(0);
        int speed=60;
        bool stop=false;
        Vector3 newPos=transform.position+new Vector3(10f*dx,10f*dy,0f);
        Debug.LogWarning(transform.position); Debug.LogWarning(newPos);
        
        if(GC.tiles[x + dx,y + dy].GetTileState()==9){GC.tiles[x + dx,y + dy].SetTileStats(1,0,0,0); PT.PlaceAfterBreak(x,y,dx,dy,GC.ogx,GC.ogy);}
        if(GC.tiles[x + dx, y + dy].GetTileState()<5 || GC.tiles[x + dx, y + dy].GetTileState()==9){
        while(!stop && distance>0){
            GC.tiles[x,y].setPlayer(null);
            //&& _GC.tiles[posGrid.x-_GC.ogx + dx,posGrid.y-_GC.ogy + dy].GetTileState()>=5
            //newPos=transform.position+new Vector3(10f*dx,10f*dy,0f);}
            if(GC.tiles[x + dx,y + dy].GetPlayer()==null){transform.position = Vector3.MoveTowards(transform.position, newPos, speed*Time.deltaTime);}else{
            GC.tiles[x,y].setPlayer(this); GC.tiles[x + dx,y + dy].GetPlayer().Push(dx,dy, distance); break;  
            }

            if(transform.position==newPos || GC.tiles[x + dx,y + dy].GetPlayer()!=null){
                x=GC.grid.WorldToCell(transform.position).x-GC.ogx;
                y=GC.grid.WorldToCell(transform.position).y-GC.ogy;
                GC.tiles[x,y].setPlayer(this); GC.tiles[x,y].addEffect(effect,bypass,direction,-1);
                newPos=transform.position+new Vector3(10f*dx,10f*dy,0f);

                if(GC.tiles[x + dx,y + dy].GetTileState()>=5 && GC.tiles[x + dx,y + dy].GetTileState()!=9){ break;}
                if(GC.tiles[x + dx,y + dy].GetTileState()==9){GC.tiles[x + dx,y + dy].SetTileStats(1,0,0,0); PT.PlaceAfterBreak(x,y,dx,dy,GC.ogx,GC.ogy);}
                if(GC.tiles[x + dx,y + dy].GetPlayer()!=null){GC.tiles[x + dx,y + dy].GetPlayer().Push(dx,dy, distance); break;}
                distance--;
            }
        
        
        
        yield return null;
        }
        Debug.LogWarning(transform.position==newPos);
        Debug.LogWarning("Hecho");
        yield return null;
        }
    }



    /*Intercambia los valores playerOnTop de las tiles*/
}
