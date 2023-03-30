using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePrefab : MonoBehaviour
{    
    public GridController _GC;
    private Vector3Int posGrid;

    void Awake(){
        
    }
    void Start()
    {
       _GC=GameObject.Find("Grid").GetComponent<GridController>();
    }

    // Update is called once per frame
    void Update()
    {
        posGrid=_GC.grid.WorldToCell(transform.position);
        FreezeTile();
        if(Input.GetKeyDown("e")){
            print("e");
            StartCoroutine(Melting(0.25f,posGrid));
            StartCoroutine(DestroyEffect(2.0f));
        }
    }

    public void FreezeTile(){
        if(_GC.tiles[posGrid.x-_GC.ogx, posGrid.y-_GC.ogy].GetTileState()==0){
            _GC.tiles[posGrid.x-_GC.ogx, posGrid.y-_GC.ogy].SetTileEffect(6); _GC.tiles[posGrid.x-_GC.ogx, posGrid.y-_GC.ogy].SetTileFade(5,2); //2 de momento
        }else if(_GC.tiles[posGrid.x-_GC.ogx, posGrid.y-_GC.ogy].GetTileState()==5){
            _GC.tiles[posGrid.x-_GC.ogx, posGrid.y-_GC.ogy].SetTileStats(10,4,5,5,2);
        }
    }
    public void MeltCube(){

    }
    public void PushCube(){

    }

    private void onCollisionEnter2D(Collider2D other){
        Debug.Log("aj");
    }
    private void onTriggerEnter2D(Collider2D other){
        Debug.Log("ch");
        /*switch(other.name){
            case "FirePrefab":  StartCoroutine(Melting(0.25f,posGrid));
                                StartCoroutine(DestroyEffect(2.0f)); break;
        }*/
    }

    IEnumerator Melting(float sec, Vector3Int posGrid){
        WaitForSeconds wfs= new WaitForSeconds(sec);
        //Patron de 5x5
        int rot=0;
        int rotCont=0;
        int rotSteps=1;
        int x=posGrid.x-_GC.ogx; int y=posGrid.y-_GC.ogy;

        for(int i=1; i<=(25); i++){
            switch(_GC.tiles[x,y].GetTileEffect()){
                case 0: _GC.tiles[x,y].SetTileEffect(2); break; //Falta poner cambio en la capa de effectos mojado
                case 6: _GC.tiles[x,y].SetTileEffect(2); break;
                case 1: _GC.tiles[x,y].SetTileEffect(14); break;
                case 5: _GC.tiles[x,y].SetTileEffect(0); break; //Quita el efecto de fuego
                case 8: _GC.tiles[x,y].SetTileEffect(16); break;
            }

            switch(rot){
                case 0: x++; break;
                case 1: y--; break;
                case 2: x--; break;
                case 3: y++; break;
            }
            if(i%rotSteps==0){
                if((rot)%4==0){
                    yield return wfs;
                }
                rot=(rot+1)%4;
                rotCont++;
                if(rotCont%2==0){
                    rotSteps++;
                }
            }
            
        }
        
    }

    IEnumerator DestroyEffect(float sec){
        WaitForSeconds wfs=new WaitForSeconds(sec);
        yield return wfs;
        Destroy(this.gameObject);
    }
}
