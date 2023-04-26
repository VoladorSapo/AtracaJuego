using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : MonoBehaviour
{
    public GridController _GC;
    public MapManager _MM;
    public ObjectStuff _OS;
    [SerializeField] GlosarioController _glosario;

    // Start is called before the first frame update

    void Awake()
    {
        _OS = GameObject.Find("Controller").GetComponent<ObjectStuff>();
        _GC = GameObject.Find("Grid").GetComponent<GridController>();
        _MM = GameObject.Find("MapManager").GetComponent<MapManager>();
        _glosario = GameObject.Find("GlosarioController").GetComponent<GlosarioController>();

    }
    void Start()
    {

        Vector3Int posInted = _GC.grid.WorldToCell(transform.position);
        int x = posInted.x - _GC.ogx;
        int y = posInted.y - _GC.ogy;
        print(x + "," + y);
        
        if (_GC.tiles[x, y].player != null)
        {
            PlayerBase p = _GC.tiles[x, y].player;

            switch (p.tag)
            {
                case "IceCube": IcePrefab o = p as IcePrefab; o.Melt(); if(_GC.tiles[x,y].GetTileEffect()==1 || _GC.tiles[x,y].GetTileEffect()==7){_GC.tiles[x, y].addEffect(2, true, 0, -1); _glosario.ChangeGlosario(0, 2, true, new Vector3(x, y)); } break;
                case "WoodBox": CajasQuemables c = p as CajasQuemables; if(!c.Burning){c.Burn();} if(_GC.tiles[x,y].GetTileEffect()==1 || _GC.tiles[x,y].GetTileEffect()==7){_GC.tiles[x, y].addEffect(2, true, 0, -1);} break;
                default: _GC.tiles[x, y].addEffect(2, true, 0, -1); break;
            }
        }else{_GC.tiles[x, y].addEffect(2, true, 0, -1);} //Sprite 2, estado 1, efecto 2, int 1 fade 1 //Todos valores temporales que hay que ajustar en la tabla

        
        StartCoroutine(DestroyEffect(2)); //Destruye el prefab en 2 (de momento) segs tras la animacion
    }
    
    IEnumerator DestroyEffect(float sec)
    {
        WaitForSeconds wfs = new WaitForSeconds(sec);
        yield return wfs;
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
