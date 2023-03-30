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
    public MapManager _MM;
    public CustomTileClass[,] tilesCopy;


    void Awake(){
        w=transform.localScale.x;
        h=transform.localScale.y;
        _GC=GameObject.Find("Grid").GetComponent<GridController>();
        _MM=GameObject.Find("MapManager").GetComponent<MapManager>();
    }

    void Start(){
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
                if(_GC.tiles[(i1),(j1)].GetTileState()<8){
                    switch(_GC.tiles[(i1),(j1)].GetTileEffect()){
                        case 0: _GC.tiles[(i1),(j1)].SetTileEffect(1); _GC.tiles[(i1),(j1)].SetTileFade(0,3); break;
                        case 1: _GC.tiles[(i1),(j1)].SetTileFade(0,3); break;
                        case 2: _GC.tiles[(i1),(j1)].SetTileEffect(14); _GC.tiles[(i1),(j1)].SetTileFade(0,3); break;
                        case 3: _GC.tiles[(i1),(j1)].SetTileEffect(17); _GC.tiles[(i1),(j1)].SetTileFade(0,3); break;
                        case 5: _MM.SpreadFireEffect(i1,j1); break;
                        case 6: _GC.tiles[(i1),(j1)].SetTileEffect(11); _GC.tiles[(i1),(j1)].SetTileFade(0,3); break;
                        case 7: _GC.tiles[(i1),(j1)].SetTileEffect(18); break;
                        case 9:  _GC.tiles[(i1),(j1)].SetTileEffect(19); break;
                    }
                }
            }
        }
        StartCoroutine(DestroyEffect(2));
    }

    /*private CustomTileClass Clone(int sprite, int state, int effect, Vector3Int pos, int fade){
        CustomTileClass n = new CustomTileClass(sprite, state, effect, pos, fade);
        return n;
    }*/

    IEnumerator DestroyEffect(float sec){
        WaitForSeconds wfs=new WaitForSeconds(sec);
        yield return wfs;
        Destroy(this.gameObject);
    }
}
