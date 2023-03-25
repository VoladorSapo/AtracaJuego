using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    bool turn;
    protected bool moving;
    private bool hasTurn;
    public int teamNumb;//El numero del jugador dentro del equipo
    [SerializeField] protected bool alive;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int currentHealth;
    List<Node> nodes;
    //Método Principal
    /*Método Secundario*/
    // Start is called before the first frame update
    void Start()
    {
        grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
        GC = grid.GetComponent<GridController>();
        startGame();
    }

    // Update is called once per frame
    public virtual void Update()
    {
       
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, grid.CellToWorld(nodes[0].pos) + new Vector3(0.5f, 0.5f, 0), 0.1f);


            //transform.position = Vector3.MoveTowards(transform.position, grid.CellToWorld(nodes[0].pos) + new Vector3(0.5f, 0.5f, 0), 0.1f);
            if (Vector3.Distance(grid.CellToWorld(nodes[0].pos) + new Vector3(0.5f, 0.5f, 0), transform.position) < 0.01f)
            {
                transform.position = nodes[0].pos + new Vector3(0.5f, 0.5f, 0);
                nodes.RemoveAt(0);
                if (nodes.Count <= 0)
                {
                    moving = false;
                    //Turn();
                    Vector3Int tilepos= grid.WorldToCell(transform.position- new Vector3(0.5f +GC.ogx, GC.ogy+ 0.5f, 0));
                    CustomTileClass tile = GC.tiles[tilepos.x, tilepos.y];
                    tile.setPlayer(this);
                    SPM.endTurn(teamNumb,false);
                }
            }
        }
    }
    public virtual void startTurn() 
    { }

    
    //Mueve al jugador a la posición indicada
    protected virtual void Move(Vector3 position)
    {
        
        List<Node> newPos = GC.GetPath(this.transform.position,position);
        print(newPos.Count);
        if (newPos.Count > 0)
        {
            nodes = newPos;
            moving = true;
            turn = false;
        }

        int newX = Mathf.RoundToInt(this.transform.position.x) - GC.ogx;
        int newY = Mathf.RoundToInt(this.transform.position.y) - GC.ogy;
        

        
        /*switch(this.name){
            case "Player1": GC.tiles[newX,newY].SetPlayerOnTop(name); if(prevX[i]!=null){GC.tiles[prevX[i],prevY[i]].SetPlayerOnTop("null");} prevX[i]=newX; prevY[i]=newY; break;
            case "Player2": ChangeOnTop(newX, newY, "p2", 1); break;
            case "Player3": ChangeOnTop(newX, newY, "p3", 2); break;
            case "Player4": ChangeOnTop(newX, newY, "p4", 3); break;
            case "Player5": ChangeOnTop(newX, newY, "p5", 4); break;
        }*/
        //Hablar con Diego
        
    }

    public virtual void Turn()
    {
        turn = true;
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
        if (Input.GetMouseButtonDown(1))
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

    public void setTurn(bool newTurn)
    {
        hasTurn = newTurn;
    }


    /*Intercambia los valores playerOnTop de las tiles*/
    private void ChangeOnTop(int newX, int newY, string name, int i){
        GC.tiles[newX,newY].SetPlayerOnTop(name); if(prevX[i]!=null){GC.tiles[prevX[i],prevY[i]].SetPlayerOnTop("null");} prevX[i]=newX; prevY[i]=newY;
    }
}
