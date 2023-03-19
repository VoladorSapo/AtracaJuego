using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    private Grid grid;
    private tunController _turnController;

    bool turn;
    bool moving;
    List<Node> nodes;
    //Método Principal
    /*Método Secundario*/
    // Start is called before the first frame update
    void Start()
    {
        grid=GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0)){
            if (turn)
            {
                MoveClick();
            }
        }
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, grid.CellToWorld(nodes[0].pos) + new Vector3(0.5f, 0.5f, 0), 0.1f);
            if (Vector3.Distance(grid.CellToWorld( nodes[0].pos) + new Vector3(0.5f,0.5f,0), transform.position) < 0.01f)
            {
                transform.position = nodes[0].pos + new Vector3(0.5f, 0.5f, 0);
                nodes.RemoveAt(0);
                if (nodes.Count <= 0)
                {
                    moving = false;
                    //Turn();
                    _turnController.nextTurn(this);
                }
            }
        }
    }

    //Mueve al jugador a la posición indicada
    protected virtual void MoveClick(){
        List<Node> newPos = GetMousePosition();
        nodes = newPos;
        moving = true;
        turn = false;
    }
    public virtual void Turn()
    {
        turn = true;
    }

    /*Calcula la posición del ratón en coordenadas de la Grid*/
    List<Node> GetMousePosition(){
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.GetComponent<GridController>().GetPath(this.transform.position);
    }
}
