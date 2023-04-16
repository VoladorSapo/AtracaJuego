using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PalancaTest : MonoBehaviour
{
    [SerializeField] private Vector2Int[] Posiciones;
    [SerializeField] private ObjectStuff[] Objetos;
    [SerializeField] private int[] active;
    [SerializeField] private bool Activate;
    [SerializeField] private bool Activated;
    public Tile notActivatedTile;

    private int n=0;
    [SerializeField] private int indice;
    private GridController GC;
    void Awake(){
        Activate=false;
        Activated=false;
        GC=FindObjectOfType<GridController>();
        active= new int[Posiciones.Length];
        for(int i=0; i<active.Length; i++){active[i]=-1;}
    }

    // Update is called once per frame
    void Update()
    {
        if(GC.tiles[0,0]!=null){
        n=0;
        for(int i=0; i<Posiciones.Length; i++){
            if(GC.tiles[Posiciones[i].x, Posiciones[i].y].GetTileState()==7){n++; if(active[i]<0){active[i]=3;}}
        }
        if(n==Posiciones.Length){Activate=true;}
        }
        
        

        if(Activate && !Activated){
            Debug.LogWarning("Palanca Activada "+indice);
            switch(indice){
                case 0: (Objetos[0] as PuertaTest).Open(); break;
                case 1: Debug.LogWarning("te"); break;
                //... Hasta el maximo que sea
            }
            Activated=true;
        }

        if(!Activate && Activated){
            switch(indice){
                case 0:  (Objetos[0] as PuertaTest).Close(); break;
                case 1: Debug.LogWarning("Deshace te"); break;
                //... Hasta el maximo que sea
            }
            Activated=false;
        }
    }

    public void LowerActives(){
        for(int i=0; i<Posiciones.Length; i++){
            if(GC.tiles[Posiciones[i].x, Posiciones[i].y].GetTileState()==7){if(active[i]>0){active[i]--;}
            if(active[i]==0){active[i]=-1; GC.tiles[Posiciones[i].x, Posiciones[i].y].SetTileState(6); GC.ground.SetTile(new Vector3Int(Posiciones[i].x+GC.ogx,Posiciones[i].y+GC.ogy,0),notActivatedTile);
            Activate=false;}}
        }
    }

    public void ResetActive(int x, int y){
        for(int i=0; i<Posiciones.Length; i++){
            if(Posiciones[i]==new Vector2Int(x,y)){active[i]=3;}
        }
    }
}
