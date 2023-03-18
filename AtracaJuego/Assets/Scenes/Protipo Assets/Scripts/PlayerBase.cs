using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    private Grid grid;
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
            MoveClick();
        }
    }

    //Teletransporta(de momento) al jugador a la posición indicada
    protected virtual void MoveClick(){
        Vector3 newPos = GetMousePosition();
        newPos += new Vector3(0.5f,0.3f,0f);
        transform.position=newPos;
    }

    /*Calcula la posición del ratón en coordenadas de la Grid*/
    Vector3Int GetMousePosition(){
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }
}
