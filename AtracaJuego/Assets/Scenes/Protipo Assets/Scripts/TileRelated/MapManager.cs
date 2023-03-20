using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class MapManager : MonoBehaviour
{
    [SerializeField] private Tilemap map;
    [SerializeField] private List<TileData> tileDatas;

 

    public bool walkable;

    private void Awake(){

    }
    
    private void Update(){
        
            if(Input.GetMouseButtonDown(0)){
            
            Vector3Int gridPosition=gridMouseCalculate();
            Tile clickedTile = map.GetTile<Tile>(gridPosition);
            
            Debug.Log("Hay en "+gridPosition+" una "+clickedTile);
            }

            
    }


    Vector3Int gridMouseCalculate(){
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return map.WorldToCell(mousePos);
    }
}
