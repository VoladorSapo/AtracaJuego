using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField] private Tilemap map;
    [SerializeField] private List<TileData> tileDatas;
    public bool walkable;

    private void Awake(){

    }
    
    private void Update(){
        
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = map.WorldToCell(mousePos);

            TileBase clickedTile = map.GetTile(gridPosition);
            
            walkable = true;

            if(Input.GetKeyDown("a")){
                //dataFromTiles[clickedTile].walkable=false;
            }
    }

}
