using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Player1 : PlayerBase
{   
    //public ScriptPlayerManager SPM;
    public ScriptPlayerManager SPM;
    public GridController GC;

    [SerializeField] private int MaxDistance = 5;

    protected override void MoveClick(){
        Vector3 worldPos=transform.position;

        Vector2Int posGrid=WorldToGrid(worldPos);
        GC.oPlayerx=posGrid.x-GC.ogx;
        GC.oPlayery=posGrid.y-GC.ogy;
        
        if(SPM.Player1 && GC.canMoveHere && GC.distanceRun<=MaxDistance){
        base.MoveClick();

        posGrid=WorldToGrid(worldPos);
        GC.oPlayerx=posGrid.x-GC.ogx;
        GC.oPlayery=posGrid.y-GC.ogy;
        }
    }

    void OnMouseDown(){
        SPM.Player1=true;
        SPM.Player2=false;
    }

    /*Calcula la posición del Player en coordenadas de la Grid*/
    Vector2Int WorldToGrid(Vector3 worldPos){
        Vector3 cellSize = Vector3.one;

        Vector2 cellPos = new Vector2(Mathf.Floor(worldPos.x / cellSize.x), Mathf.Floor(worldPos.z / cellSize.z));
        Vector2 finalPos = new Vector2(cellPos.x * cellSize.x, cellPos.y * cellSize.z);

        return Vector2Int.RoundToInt(finalPos);
    }
}
