using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaTest: MonoBehaviour
{
    [SerializeField] private Vector2Int[] Posiciones;
    [SerializeField] private bool Activate;
    [SerializeField] private bool Activated;
    private int n=0;
    [SerializeField] private int indice;
    private GridController GC;
    void Awake(){
        Activate=false;
        Activated=false;
        GC=FindObjectOfType<GridController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GC.tiles[0,0]!=null){
        n=0;
        for(int i=0; i<Posiciones.Length; i++){
            if(GC.tiles[Posiciones[i].x, Posiciones[i].y].GetTileState()==2){n++;}
        }
        if(n==Posiciones.Length){Activate=true;}
        }
        
        

        if(Activate && !Activated){
            Debug.LogWarning("Puerta Abierta "+indice);
            switch(indice){
                case 0: Debug.LogWarning("Que"); break;
                case 1: Debug.LogWarning("so"); break;
                //... Hasta el maximo que sea
            }
            Activated=true;
        }
    }
}
