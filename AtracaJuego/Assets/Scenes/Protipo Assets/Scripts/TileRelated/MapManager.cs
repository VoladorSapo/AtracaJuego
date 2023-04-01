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
    public void SpreadEffectNoLimit(int x, int y, int effect){
        int up1= y+1;
        int down1= y-1;
        int left1= x-1;
        int right1= x+1;

        _GC.tiles[x,up1].addEffect(effect,false);
        _GC.tiles[x,down1].addEffect(effect,false);
        _GC.tiles[x,y].addEffect(effect,false);
        _GC.tiles[left1,y].addEffect(effect,false);
        _GC.tiles[right1,y].addEffect(effect,false);
    }

    public void SpreadEffectLimit(int x,int y,int effect, int Range,int MaxRange){
        int up1= y+1;
        int down1= y-1;
        int left1= x-1;
        int right1= x+1;
        
        _GC.tiles[x,y].addEffect(effect,false);
        if(Range<=MaxRange){
        Range++;
        SpreadEffectLimit(x,up1,effect,Range,MaxRange);
        SpreadEffectLimit(x,down1,effect,Range,MaxRange);
        SpreadEffectLimit(left1,y,effect,Range,MaxRange);
        SpreadEffectLimit(right1,y,effect,Range,MaxRange);
        }

    }

    public void Damage(int codeDamage, int x, int y){
        switch(codeDamage){
            case 0: if(_GC.tiles[x,y].player!=null){_GC.tiles[x,y].player.loseHealth(1);} break;
            case 1: if(_GC.tiles[x,y].player!=null){_GC.tiles[x,y].player.loseHealth(1);} break;
            case 2: if(_GC.tiles[x,y].player!=null){_GC.tiles[x,y].player.loseHealth(2);} break;
        }
    }



    
}
