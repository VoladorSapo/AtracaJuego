using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class MapManager : MonoBehaviour
{
    [SerializeField] private Tilemap map;
    [SerializeField] private List<TileData> tileDatas;
    public GridController _GC;
 

    //public bool walkable;

    private void Awake(){

    }
    
    private void Update(){
            
    }


    Vector3Int gridMouseCalculate(){
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return map.WorldToCell(mousePos);
    }

    //Extiende el fuego si se le llama
    public void SpreadFireEffect(int x, int y){
        print("g");
        _GC.tiles[x,y].SetTileStats(2,1,2,1); //2 por ejemplo es explosion

        int up1= y+1;
        int down1= y-1;
        int left1= x-1;
        int right1= x+1;

        if(_GC.tiles[x,up1].GetTileEffect()==1){ //1 tiene gas
            SpreadFireEffect(x, up1);
        }

        if(_GC.tiles[x,down1].GetTileEffect()==1){
            SpreadFireEffect(x, down1);
        }

        if(_GC.tiles[left1,y].GetTileEffect()==1){
            SpreadFireEffect(left1,y);
        }

        if(_GC.tiles[right1,y].GetTileEffect()==1){
            SpreadFireEffect(right1,y);
        }

    }

    
}
