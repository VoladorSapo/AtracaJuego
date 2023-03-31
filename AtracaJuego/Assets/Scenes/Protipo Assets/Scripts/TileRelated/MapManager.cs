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
    public void SpreadEffectNoLimit(int x, int y, int potencia, int effect){
        int up1= y+1;
        int down1= y-1;
        int left1= x-1;
        int right1= x+1;

        switch(effect){
        case 2:
        /*switch(potencia){
            case 1:
            case 2:
            case 3:
        }*/
        _GC.tiles[x,up1].addEffect(2,false);
        _GC.tiles[x,down1].addEffect(2,false);
        _GC.tiles[x,y].addEffect(2,false);
        _GC.tiles[left1,y].addEffect(2,false);
        _GC.tiles[right1,y].addEffect(2,false); break;
        case 5:
        _GC.tiles[x,up1].addEffect(5,false);
        _GC.tiles[x,down1].addEffect(5,false);
        _GC.tiles[x,y].addEffect(5,false);
        _GC.tiles[left1,y].addEffect(5,false);
        _GC.tiles[right1,y].addEffect(5,false); break;
        }

        

    }

    public void SpreadEffectLimit(int x,int y, int range){

        _GC.tiles[x,y].addEffect(3,false);

        int up1= y+1;
        int down1= y-1;
        int left1= x-1;
        int right1= x+1;

        if(range<=6){
        range++;
        if(_GC.tiles[x,up1].GetTileEffect()==5 || _GC.tiles[x,up1].GetTileEffect()==9){
            SpreadEffectLimit(x,up1,range);
        }

        if(_GC.tiles[x,down1].GetTileEffect()==5 || _GC.tiles[x,down1].GetTileEffect()==9){
            SpreadEffectLimit(x,down1,range);
        }


        if(_GC.tiles[left1,y].GetTileEffect()==5 || _GC.tiles[left1,y].GetTileEffect()==9){
            SpreadEffectLimit(left1,y,range);
        }


        if(_GC.tiles[right1,y].GetTileEffect()==5 || _GC.tiles[right1,y].GetTileEffect()==9){
            SpreadEffectLimit(right1,y,range);
        }
        
        }

    }



    
}
