using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : MonoBehaviour
{
    public GridController _GC;
    public MapManager _MM;

    public ObjectStuff _OS;
    // Start is called before the first frame update

    void Awake()
    {
        _OS = GameObject.Find("Controller").GetComponent<ObjectStuff>();
        _GC = GameObject.Find("Grid").GetComponent<GridController>();
        _MM = GameObject.Find("MapManager").GetComponent<MapManager>();
    }
    void Start()
    {

        Vector3Int posInted = _GC.grid.WorldToCell(transform.position);
        int x = posInted.x - _GC.ogx;
        int y = posInted.y - _GC.ogy;
        print(x + "," + y);
        _GC.tiles[x, y].addEffect(2, true, 0, -1); //Sprite 2, estado 1, efecto 2, int 1 fade 1 //Todos valores temporales que hay que ajustar en la tabla
        if (_GC.tiles[x, y].player != null)
        {
            PlayerBase p = _GC.tiles[x, y].player;

            switch (p.tag)
            {
                case "IceCube": ObjectStuff o = p as ObjectStuff; o.Melt(); break;
                case "WoodBox": CajasQuemables c = p as CajasQuemables; c.Burn(); break;
            }
        }

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
