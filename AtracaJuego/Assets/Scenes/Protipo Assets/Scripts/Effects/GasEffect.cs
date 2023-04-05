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
        int filas=Mathf.RoundToInt(w/10); // w/tamaño tiles
        int columnas=Mathf.RoundToInt(h/10); // h/tamaño tiles
        Vector3Int tileO = _GC.grid.WorldToCell(posBL);
        print((tileO.x-_GC.ogx)+" y "+(tileO.y-_GC.ogy));
        print(filas);


        for(int i=0; i<filas; i++){
            for(int j=0; j<columnas; j++){
                int i1=tileO.x+i-_GC.ogx;
                int j1=tileO.y+j-_GC.ogy;
                _GC.tiles[i1,j1].addEffect(1,false,0,-1);
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
