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
    }

    public void FreezeTile(){
        _GC.tiles[posGrid.x-_GC.ogx, posGrid.y-_GC.ogy].addEffect(4, false);
    }
    public void MeltCube(){

    }
    public void PushCube(){

    }

    void OnTriggerEnter2D(Collider2D other){

        switch(other.name){
            case "FirePrefab(Clone)":  StartCoroutine(Melting(0.25f,posGrid));
                                        StartCoroutine(DestroyEffect(2.0f)); break;
        }
    }

    IEnumerator Melting(float sec, Vector3Int posGrid){
        WaitForSeconds wfs= new WaitForSeconds(sec);
        //Patron de 5x5
        int rot=0;
        int rotCont=0;
        int rotSteps=1;
        int x=posGrid.x-_GC.ogx; int y=posGrid.y-_GC.ogy;

        
        for(int i=1; i<=(25); i++){
            _GC.tiles[x,y].addEffect(6,false);
            

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
        _GC.tiles[posGrid.x-_GC.ogx,posGrid.y-_GC.ogy].SetTileEffect(2);
        Destroy(this.gameObject);
        
    }
}
