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
            case "sheet_191": id[0]=1; id[1]=8; id[2]=16; break;
            case "sheet_80": id[0]=2; id[1]=9; id[2]=16; break;
            case "sheet_60": id[0]=3; id[1]=1; id[2]=0; break; //Quizas 16 es lo mejor
            case "piso1recepcion_3": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_17": id[0] = 1; id[1] = 8; id[2] = 16; break;

            case "piso1recepcion_45": id[0] = 1; id[1] = 8; id[2] = 16; break;

            case "piso1recepcion_46": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_47": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_48": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_49": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_64": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_65": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_66": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_67": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_68": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_69": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_75": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_76": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_77": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_78": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_79": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_80": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_86": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_87": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_88": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_89": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_90": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_91": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion_4": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion_5": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion_16": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion_17": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion_18": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion_19": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion_26": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion_27": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion_28": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion_32": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion_33": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion_34": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion_35": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion_36": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion_37": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion_38": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion_44": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion_45": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion_46": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion_47": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion_48": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion_49": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion_50": id[0] = 1; id[1] = 8; id[2] = 16; break;
   
            case "ampliacionTileSheetRecepcion2jardin_10": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion2jardin_11": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion2jardin_12": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion2jardin_13": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion2jardin_14": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion2jardin_19": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion2jardin_20": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion2jardin_21": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion2jardin_22": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion2jardin_23": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion2jardin_26": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion2jardin_27": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion2jardin_28": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion2jardin_29": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion2jardin_30": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion2jardin_31": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion2jardin_32": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion2jardin_33": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion2jardin_34": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion2jardin_35": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion2jardin_36": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion2jardin_45": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "ampliacionTileSheetRecepcion2jardin_46": id[0] = 1; id[1] = 8; id[2] = 16; break;

                //case "sheet_191": id[0] = 1; id[1] = 8; id[2] = 16; break;
                //case "sheet_191": id[0] = 1; id[1] = 8; id[2] = 16; break;
        }

        return id;
    }
}
