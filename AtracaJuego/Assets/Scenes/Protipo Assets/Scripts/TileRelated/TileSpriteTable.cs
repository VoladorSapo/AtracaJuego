using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class TileSpriteTable : MonoBehaviour
{

    public Tile[] tileList;

    void Awake(){
        
    }

    public Tile SetNewTile(int id){
        Tile tileChange;
        tileChange=tileList[id];
        return tileChange;
    }

    //Solo se usa para inicializar el array del mapa
    public int[] GetTileStats(Tile actualTile){
        int[] id=new int[3];
        //[Sprite, caracteristicas]
        switch(actualTile.name){
            case "sheet_160": id[0]=0; id[1]=0; id[2]=0; break; //0 es que no tiene ningun effecto
            case "sheet_191": id[0]=1; id[1]=1; id[2]=0; break;
        }

        return id;
    }
}
