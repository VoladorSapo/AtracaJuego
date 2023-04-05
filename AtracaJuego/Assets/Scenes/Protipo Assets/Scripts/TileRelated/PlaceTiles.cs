using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class PlaceTiles : MonoBehaviour
{
    public Tilemap Charco;
    public Tilemap Gas;
    public Tilemap Ground;
    
    //Podria ser array pero para que tan solo tenga unos 10 elementos mejor que tenga cada uno un nombre especifico
    public Tile iceT;
    public Tile wetT;
    public Tile gasT;
    void Awake(){
        Charco=GameObject.Find("Charcos").GetComponent<Tilemap>();
        Gas=GameObject.Find("Gases").GetComponent<Tilemap>();
        Ground=GameObject.Find("Ground").GetComponent<Tilemap>();
    }
}
