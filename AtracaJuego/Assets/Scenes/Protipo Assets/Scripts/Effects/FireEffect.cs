using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : MonoBehaviour
{
    public GridController _GC;
    public MapManager _MM;
    // Start is called before the first frame update
    void Start()
    {
        _MM=GameObject.Find("MapManager").GetComponent<MapManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Este código va en start pero por razones de testeo de momento lo pongo aquí
        if(Input.GetKeyDown("f")){
            print("f0");
            Vector3 posBL=new Vector3(transform.position.x - 0.5f, transform.position.y-0.5f,0f);
            Vector3Int posInted= Vector3Int.RoundToInt(posBL);
            int x=posInted.x-_GC.ogx;
            int y=posInted.y-_GC.ogy;
            
            print(x+","+y);
            if(_GC.tiles[x,y].GetTileEffect()==1){
                print("f");
                _GC.tiles[x,y].SetTileStats(2,1,2);
                _MM.SpreadFireEffect(x,y);
            }
        }
    }
}