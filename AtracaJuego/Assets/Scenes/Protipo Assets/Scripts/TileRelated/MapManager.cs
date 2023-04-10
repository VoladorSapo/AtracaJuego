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
    public void SpreadEffectNoLimit(int x, int y, int effect, int direction, int lock_){
        int up1= y+1;
        int down1= y-1;
        int left1= x-1;
        int right1= x+1;

        _GC.tiles[x,up1].addEffect(effect,false,direction,lock_);
        _GC.tiles[x,down1].addEffect(effect,false,direction,lock_);
        _GC.tiles[x,y].addEffect(effect,false,direction,lock_);
        _GC.tiles[left1,y].addEffect(effect,false,direction,lock_);
        _GC.tiles[right1,y].addEffect(effect,false,direction,lock_);
    }

    public void SpreadEffectLimit(int x,int y,int effect, int Range,int MaxRange, int direction, int lock_){
        int up1= y+1;
        int down1= y-1;
        int left1= x-1;
        int right1= x+1;
        
        _GC.tiles[x,y].addEffect(effect,false,direction,lock_);
        print("@"+Range);
        if(Range<=MaxRange){
        Range++;

        if(direction!=4 && _GC.tiles[x,up1].canAddEffect(effect) ){SpreadEffectLimit(x,up1,effect,Range,MaxRange,direction,lock_);}

        if(direction!=3 && _GC.tiles[x,down1].canAddEffect(effect) ){SpreadEffectLimit(x,down1,effect,Range,MaxRange,direction,lock_);}
        
        if(direction!=1 && _GC.tiles[left1,y].canAddEffect(effect) ){SpreadEffectLimit(left1,y,effect,Range,MaxRange,direction,lock_);}
        
        print("@"+_GC.tiles[right1,y].canAddEffect(effect));
        if(direction!=2 && _GC.tiles[right1,y].canAddEffect(effect) ){SpreadEffectLimit(right1,y,effect,Range,MaxRange,direction,lock_);}
        }

    }

    public void Damage(int codeDamage, int x, int y){
        PlayerBase p=_GC.tiles[x,y].player;
        switch(codeDamage){
            case 0: if(p!=null){if(p.tag=="Player"){p.loseHealth(1);}else{p.loseHealth(3);}} break;
            case 1: if(p!=null){if(p.tag=="Player"){p.loseHealth(1);}else{p.loseHealth(4);}} break;
            case 2: if(p!=null){if(p.tag=="Player"){p.loseHealth(2);}else{p.loseHealth(7);}} break;
            case 3: if(p!=null){if(p.tag=="Player"){p.loseHealth(1);}else{p.loseHealth(2);}} break;
            case 4: if(p!=null){if(p.tag=="Player"){p.loseHealth(1);}else{p.loseHealth(5);}} break;
            case 5: if(p!=null){if(p.tag=="Player"){p.loseHealth(1);}else{p.loseHealth(2);}} break;
        }
    }

    public void InstantiatePrefab(GameObject GO, Vector3Int pos){
        Vector3Int newPos=pos+new Vector3Int(5,5,0);
        Instantiate(GO,newPos,Quaternion.identity);
    }



    
}
