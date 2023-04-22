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
        print(actualTile);
        switch(actualTile.name){
            case "sheet_160": id[0]=0; id[1]=0; id[2]=0; break; //0 es que no tiene ningun effecto
            case "sheet_191": id[0]=1; id[1]=8; id[2]=16; break;
            case "sheet_80": id[0]=2; id[1]=9; id[2]=16; break;
            case "sheet_201": id[0]=4; id[1]=6; id[2]=16; break;
            case "sheet_60": id[0]=3; id[1]=1; id[2]=16; break; //Quizas 16 es lo mejor
           // case "piso1recepcion_3": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_17": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_36": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_45": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_46": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_47": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_48": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_49": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_50": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "piso1recepcion_59": id[0] = 1; id[1] = 8; id[2] = 16; break;
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
            case "piso1recepcion_82": id[0] = 1; id[1] = 8; id[2] = 16; break;
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
            case "estanteriabaja 1": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "estanteriabaja 2 1": id[0] = 1; id[1] = 8; id[2] = 16; break;    
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
            case "tilenegro": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "cubiculo 1": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "cubiculo 1_0": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "cubiculo 1_1": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "cubiculo 1_2": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "cubiculo 1_3": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "cubiculo 1_4": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "cubiculo 1_5": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "cubiculo 1_6": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "cubiculo 1_7": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "cubiculo 1_8": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "cubiculo 1_9": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "jabon": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "pila1 1": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "pila1": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_1": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_2": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_3": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_4": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_5": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_6": id[0] = 2; id[1] = 9; id[2] = 16; break;
            case "tilesetBaño_7": id[0] = 2; id[1] = 9; id[2] = 16; break;
            case "tilesetBaño_8": id[0] = 2; id[1] = 9; id[2] = 16; break;
            case "tilesetBaño_10": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_11": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_12": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_13": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_14": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_15": id[0] = 2; id[1] = 9; id[2] = 16; break;
            case "tilesetBaño_16": id[0] = 2; id[1] = 9; id[2] = 16; break;
            case "tilesetBaño_17": id[0] = 2; id[1] = 9; id[2] = 16; break;
            case "tilesetBaño_19": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_20": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_21": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_22": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_23": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_24": id[0] = 2; id[1] = 9; id[2] = 16; break;
            case "tilesetBaño_25": id[0] = 2; id[1] = 9; id[2] = 16; break;
            case "tilesetBaño_26": id[0] = 2; id[1] = 9; id[2] = 16; break;
            case "tilesetBaño_27": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_28": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_29": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_30": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_31": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_32": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_33": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_34": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_35": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_36": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_37": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_38": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_39": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_40": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_41": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_42": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_43": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_44": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_45": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_46": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_47": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_48": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_49": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_50": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_51": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_52": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBaño_53": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "urinario": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_4": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_5": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_6": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_7": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_8": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_13": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_14": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_15": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_16": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_19": id[0] = 1; id[1] = 8; id[2] = 16; break;
             case "tilesetExposicion_20": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_21": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "maletin2lavenganza": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_30": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_31": id[0] = 1; id[1] = 8; id[2] = 16; break;
             case "tilesetExposicion_32": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_33": id[0] = 1; id[1] = 8; id[2] = 16; break;

            case "tilesetExposicion_37": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_25": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_26": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_27": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_28": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_34": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_35": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_36": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_38": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_39": id[0] = 1; id[1] = 8; id[2] = 16; break;

            case "tilesetExposicion_40": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExposicion_41": id[0] = 1; id[1] = 8; id[2] = 16; break;
             case "tilesetExposicion_42": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "estanteriabaja": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetRegalos_2": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetRegalos_3": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetRegalos_4": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetRegalos_7": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetRegalos_9": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetRegalos_10": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_0": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_1": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_2": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_3": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_6": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_7": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_8": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_9": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_10": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_11": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_12": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_13": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_16": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_23": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_26": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_27": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_28": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_29": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_30": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_31": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_32": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_33": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_34": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_35": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetdescanso_36": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_0": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_1": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_2": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_3": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_4": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_5": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_6": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_7": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_8": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_9": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_10": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_11": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_12": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_13": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_14": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_15": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_16": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_17": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_18": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_19": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_20": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_23": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_24": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_25": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_26": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_27": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_28": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_29": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_33": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_34": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_35": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_36": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetOfi_37": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "mesacanto": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "mesacanto2": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "mesapata": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "mesapata2": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "mesapaton": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "mesapaton2": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_0": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_1": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_2": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_3": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_4": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_5": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_6": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_7": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_8": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_9": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_10": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_11": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_12": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_13": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_14": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_15": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_16": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_17": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_18": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_19": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_20": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_21": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_22": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_23": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_24": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_25": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_26": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_27": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_28": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_29": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_30": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_31": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_32": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_33": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_34": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_35": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_36": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_37": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_38": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_39": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_40": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_41": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_42": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_43": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_44": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_45": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_46": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_47": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_48": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_49": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_50": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "TilesetAlmacen_51": id[0]=3; id[1]=1; id[2]=16; break;
            case "TilesetAlmacen_52": id[0]=3; id[1]=2; id[2]=16; break;
            case "TilesetAlmacen_53": id[0]=4; id[1]=1; id[2]=16; break;
            case "TilesetAlmacen_54": id[0]=4; id[1]=2; id[2]=16; break;
            case "TilesetAlmacen_55": id[0] = 5; id[1] = 6; id[2] = 16; break;
            case "TilesetAlmacen_56": id[0] = 5; id[1] = 7; id[2] = 16; break;
            case "tilesetBossfight_0": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_1": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_2": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_3": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_7": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tlesetBossfight_8": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_9": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_10": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_11": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_12": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_18": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_19": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_20": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_21": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_22": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_23": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_29": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_30": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_31": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_32": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_33": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_34": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_40": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_41": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_44": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetBossfight_45": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tirao_0": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tirao_1": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tirao_2": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tirao_3": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tirao_4": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tirao_5": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tirao_6": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tirao_7": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tirao_8": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tirao_9": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_0": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_1": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_2": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_3": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_4": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_5": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_6": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_7": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_8": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_9": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_10": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_11": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_12": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_13": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_14": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_15": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_16": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_17": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_18": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_19": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_20": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_21": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_22": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_23": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_24": id[0] = 1; id[1] = 8; id[2] = 16; break;
            case "tilesetExtra_25": id[0] = 1; id[1] = 8; id[2] = 16; break;
                //case "sheet_191": id[0] = 1; id[1] = 8; id[2] = 16; break;
                //case "sheet_191": id[0] = 1; id[1] = 8; id[2] = 16; break;
        }

        return id;
    }
}


