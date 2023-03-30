using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] private Grid grid;
    public GridController GC;
    public gameController _gamecontroller;
    [SerializeField] private tunController _turnController;
    [SerializeField] protected ScriptPlayerManager SPM;
    [SerializeField] protected int MaxDistance = 5;
    private int[] prevX= new int[5];
    private int[] prevY= new int[5];
    protected bool team;
    protected bool moving;
    private bool hasTurn;

    public int Cooldowns=0;
    public Animator animator;
    public SpriteRenderer sprite;
    public int teamNumb;//El numero del jugador dentro del equipo
    [SerializeField] protected bool alive;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int currentHealth;
    List<Node> nodes;
    //Método Principal
    /*Método Secundario*/
    // Start is called before the first frame update
    void Awake(){

    }
    void Start()
    {
        print("madremiawilliam" );
        grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        GC = grid.GetComponent<GridController>();
        startGame();
    }

    // Update is called once per frame
    public virtual void Update()
    {
       
        if (moving)
        {
           
            transform.position = Vector3.MoveTowards(transform.position, grid.CellToWorld(nodes[0].pos) + new Vector3(5f, 5f, 0), 0.8f);
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
                    //Turn();
                    Vector3Int tilepos= grid.WorldToCell(transform.position- new Vector3(5f, 5f, 0))-new Vector3Int(GC.ogx,GC.ogy);

                    //print(tilepos);
                    CustomTileClass tile = GC.tiles[tilepos.x, tilepos.y];
                    tile.setPlayer(this);
                    SPM.endTurn(teamNumb,false);
                }
                else
                {
                    print("icamefromalanddownunder");
                    print(-grid.WorldToCell(transform.position).y);
                    sprite.sortingOrder = -grid.WorldToCell(transform.position).y;
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
    public virtual void startTurn() 
    { }

    
    //Mueve al jugador a la posición indicada
    protected virtual void Move(Vector3 position)
    {
        
        List<Node> newPos = GC.GetPath(this.transform.position,position,team);
        Debug.LogWarning("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAS" + name);
        print(newPos.Count);
        if (newPos.Count > 0)
        {
            Vector3Int tilepos = grid.WorldToCell(transform.position - new Vector3(5f, 5f, 0)) - new Vector3Int(GC.ogx, GC.ogy);
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

    public void Die()
    {
        alive = false;
        Vector3Int tilepos = grid.WorldToCell(transform.position - new Vector3(0.5f + GC.ogx, GC.ogy + 0.5f, 0));
        CustomTileClass tile = GC.tiles[tilepos.x, tilepos.y];
        tile.setPlayer(null);
        GetComponent<SpriteRenderer>().enabled = false;
        SPM.playerDie(this);
    }

    public void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            loseHealth(1);
        }
    }

    public void loseHealth(int health)
    {
        currentHealth -= health;
        print(currentHealth);
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

    public virtual void startGame()
    {
        currentHealth = maxHealth;
    }

    public bool getTurn()
    {
        return hasTurn;
    }
    public bool getTeam()
    {
        return team;
    }
    public void setTurn(bool newTurn)
    {
        hasTurn = newTurn;
    }


    /*Intercambia los valores playerOnTop de las tiles*/
    private void ChangeOnTop(int newX, int newY, string name, int i){
        GC.tiles[newX,newY].setPlayer(this); if(prevX[i]!=null){GC.tiles[prevX[i],prevY[i]].setPlayer(null);} prevX[i]=newX; prevY[i]=newY;
    }
}
