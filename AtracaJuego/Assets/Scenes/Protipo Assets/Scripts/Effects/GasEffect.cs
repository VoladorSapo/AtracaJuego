using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasEffect : MonoBehaviour
{
    //Este script es un script hijo en realidad pero para testeos esto servirá de momento
    [SerializeField] private Vector3 posBL;
    [SerializeField] private float w;
    [SerializeField] private float h;
    public GridController GC;
    public MapManager _MM;
    public CustomTileClass[,] tilesCopy;
    void Awake(){
        w=transform.localScale.x;
        h=transform.localScale.y;
        GC=GameObject.Find("Grid").GetComponent<GridController>();
        _MM=GameObject.Find("MapManager").GetComponent<MapManager>();
    }

    void Start(){
        /*posBL=new Vector3(transform.position.x-(w/2),transform.position.y-(h/2),0);
        int filas=Mathf.RoundToInt(w/10); // w/tamaño tiles
        int columnas=Mathf.RoundToInt(h/10); // h/tamaño tiles
        Vector3Int tileO = _GC.grid.WorldToCell(posBL);
        print((tileO.x-_GC.ogx)+" y "+(tileO.y-_GC.ogy));
        print(filas);*/


        /*for(int i=0; i<filas; i++){
            for(int j=0; j<columnas; j++){
                int i1=tileO.x+i-_GC.ogx;
                int j1=tileO.y+j-_GC.ogy;
                _GC.tiles[i1,j1].trySetEffect(1);
            }
        }*/
        /*for(int i=0; i<filas; i++){
            for(int j=0; j<columnas; j++){
                int i1=tileO.x+i-_GC.ogx;
                int j1=tileO.y+j-_GC.ogy;
                _GC.tiles[i1,j1].addEffect(1,false,0,-1);
            }
        }*/
        int rot=0;
        int rotCont=0;
        int rotSteps=1;
        Vector3Int posGrid=GC.grid.WorldToCell(transform.position);
        int x=posGrid.x-GC.ogx; int y=posGrid.y-GC.ogy;

        GC.tiles[posGrid.x-GC.ogx,posGrid.y-GC.ogy].addEffect(1,false,0,-1);
        List<Vector2Int> listaG=new List<Vector2Int>();
        for(int i=1; i<=(25); i++){

            if(GC.tiles[x,y].GetTileEffect()!=16){
                     listaG.Add(new Vector2Int(x,y)); //listaG.Add(new Vector2Int(prevx,prevy)); //GC.tiles[prevx,prevy].addEffect(1,false,0,-1); GC.tiles[x,y].addEffect(1,false,0,-1);
            }
            
            

            switch(rot){
                case 0: x++; break;
                case 1: y--; break;
                case 2: x--; break;
                case 3: y++; break;
            }
            if(i%rotSteps==0){
                if((rot)%4==0){
                }
                rot=(rot+1)%4;
                rotCont++;
                if(rotCont%2==0){
                    rotSteps++;
                }
            }
            //listaG.Contains(new Vector2Int(v.x-1,v.y)) || listaG.Contains(new Vector2Int(v.x,v.y+1))  || listaG.Contains(new Vector2Int(v.x,v.y-1))
        }

        foreach(Vector2Int v in listaG){
            if(GC.tiles[v.x+1,v.y].GetTileEffect()==1 ||  GC.tiles[v.x-1,v.y].GetTileEffect()==1 || GC.tiles[v.x,v.y+1].GetTileEffect()==1 || GC.tiles[v.x,v.y-1].GetTileEffect()==1
            || GC.tiles[v.x+1,v.y].GetTileEffect()==7 ||  GC.tiles[v.x-1,v.y].GetTileEffect()==7 || GC.tiles[v.x,v.y+1].GetTileEffect()==7 || GC.tiles[v.x,v.y-1].GetTileEffect()==7){
                GC.tiles[v.x,v.y].addEffect(1,false,0,-1);
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
