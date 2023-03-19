using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField] private Tilemap map;
    [SerializeField] private List<TileData> tileDatas;
    public bool walkable;
    private Dictionary<TileBase, TileData> dataFromTiles;

    private void Awake(){
        walkable=false;
        dataFromTiles= new Dictionary<TileBase, TileData>();
        foreach(var tileData in tileDatas){
            foreach(var tile in tileData.tiles){
                dataFromTiles.Add(tile, tileData);
            }
        }
    }
    
    private void Update(){
        
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = map.WorldToCell(mousePos);

            TileBase clickedTile = map.GetTile(gridPosition);
            
            walkable = dataFromTiles[clickedTile].walkable;

            if(Input.GetKeyDown("a")){
                dataFromTiles[clickedTile].walkable=false;
            }
    }

}
