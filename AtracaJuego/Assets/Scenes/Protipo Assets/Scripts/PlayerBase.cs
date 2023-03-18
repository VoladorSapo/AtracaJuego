using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    private Grid grid;
    [SerializeField] protected ScriptPlayerManager SPM;
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
        if(Input.GetMouseButtonDown(0) && !ChangePlayer()){
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

    private bool ChangePlayer(){
        bool ClickPlayer=false;
        /*RaycastHit raycastHit;
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             if (Physics.Raycast(ray, out raycastHit, 100f))
             {
                 if (raycastHit.transform != null)
                 {
                    ClickPlayer=true;
                    Debug.Log("Pressed middle click.");
                    switch(raycastHit.transform.gameObject.tag){
                        case "P1":  SPM.Player1=false;
                                    SPM.Player2=true;
                                    break;
                        case "P2":  SPM.Player1=false;
                                    SPM.Player2=true;
                                    break;
                    }

                 }
             }*/ //No funciona este método
        return ClickPlayer;
    }

}
