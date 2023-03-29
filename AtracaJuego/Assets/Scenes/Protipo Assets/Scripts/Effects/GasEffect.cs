using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasEffect : MonoBehaviour
{
    //Este script es un script hijo en realidad pero para testeos esto servirá de momento
    [SerializeField] private Vector3 posBL;
    [SerializeField] private float w;
    [SerializeField] private float h;
    public GridController _GC;
    public CustomTileClass[,] tilesCopy;


    void Awake(){
        w=transform.localScale.x;
        h=transform.localScale.y;
        _GC=GameObject.Find("Grid").GetComponent<GridController>();
    }

    void Update(){
        
        /*Cuando se hagan los scripts con un script padre, este metodo se hace override*/

        if(Input.GetKeyDown("e")){
            print("bruh");
            if(tilesCopy!=null){
                for(int i=0; i<tilesCopy.GetLength(0); i++){
                    for(int j=0; j<tilesCopy.GetLength(1); j++){
                        print("Estaban guardadas las tiles: "+tilesCopy[i,j].tilePos.x+", "+tilesCopy[i,j].tilePos.y);
                        _GC.tiles[tilesCopy[i,j].tilePos.x, tilesCopy[i,j].tilePos.y]=tilesCopy[i,j];
                    }
                }
            }

        posBL=new Vector3(transform.position.x-(w/2),transform.position.y-(h/2),0);
        int filas=Mathf.RoundToInt(w/10); //w/tamaño tiles
        int columnas=Mathf.RoundToInt(h/10); //h/tamaño tiles
        Vector3Int tileO = _GC.grid.WorldToCell(posBL);
        print((tileO.x-_GC.ogx)+" y "+(tileO.y-_GC.ogy));
        print(filas);
        //tilesCopy= new CustomTileClass[filas,columnas];

        for(int i=0; i<filas; i++){
            for(int j=0; j<columnas; j++){
                int i1=tileO.x+i-_GC.ogx;
                int j1=tileO.y+j-_GC.ogy;

                //tilesCopy[i,j]=Clone(_GC.tiles[i1,j1].tileSpriteId,_GC.tiles[i1,j1].tileState,_GC.tiles[i1,j1].tileEffect,_GC.tiles[i1,j1].tilePos, _GC.tiles[i1,j1].tileFadeEffect);

                //condiciones a 0 de momento, hay que organizar la tabla
                if(_GC.tiles[(i1),(j1)].GetTileEffect()==0 && _GC.tiles[(i1),(j1)].GetTileState()<5){

                   _GC.tiles[(i1),(j1)].SetTileEffect(1);
                   _GC.tiles[(i1),(j1)].SetTileFade(3); //3 por ejemplo
                   //Cuando se tengan sprites de humo hacer SetTile en la capa de effectos
                }
            }
        }
        

        }

    }

    private CustomTileClass Clone(int sprite, int state, int effect, Vector3Int pos, int fade){
        CustomTileClass n = new CustomTileClass(sprite, state, effect, pos, fade);
        return n;
    }
}
