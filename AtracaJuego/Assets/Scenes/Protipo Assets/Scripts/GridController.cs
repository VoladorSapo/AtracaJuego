using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GridController : MonoBehaviour
{
    private Grid grid;
    RaycastHit2D objectHit;

    [SerializeField] private Tilemap interactiveMap = null;
    [SerializeField] private Tilemap pathMap = null;
    [SerializeField] private Tile hoverTile = null;
    [SerializeField] private Tile hoverTileNope = null; //Sería usada para indicar que ciertas casillas son inaccesibles, por colisión o por estar fuera de rango
    [SerializeField] private Tile hoverTilePlayer = null; //Para indicar un posible cambio de Player
    [SerializeField] private RuleTile pathTile = null;
    public bool canMoveHere;

    private Vector3Int previousMousePos = new Vector3Int();

    // Start is called before the first frame update
    void Start() {
        grid = gameObject.GetComponent<Grid>();
        canMoveHere=true;
        Tile TileToPlace=hoverTile;
    }

    // Update is called once per frame
    void Update() {
        // Mouse over -> highlight tile
        
        Vector3Int mousePos = GetMousePosition();
        if (!mousePos.Equals(previousMousePos)) {
            interactiveMap.SetTile(previousMousePos, null); //Quita la anterior tile de indicación

            Vector2 mousePos2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            objectHit = Physics2D.Raycast(mousePos2, Vector2.zero);
            
            canMoveHere=true;
                if(objectHit.collider != null){
                    switch(objectHit.collider.name){
                        case "Top1": TileToPlace=hoverTileNope; canMoveHere=false; break;
                        case "Player1": TileToPlace=hoverTilePlayer; break;
                        case "Player2": TileToPlace=hoverTilePlayer; break;
                        //Faltan los otros player o usar mejor tags pero bueno
                    }
                }
                
            
            interactiveMap.SetTile(mousePos, TileToPlace);
            previousMousePos = mousePos;
        }
    }

    //Transforma la posición del ratón a coordenadas dentro de la Grid
    Vector3Int GetMousePosition(){
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }
}