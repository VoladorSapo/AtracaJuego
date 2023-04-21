using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushEffect : MonoBehaviour
{
    [SerializeField] private Vector3 posBL;
    [SerializeField] private float w;
    [SerializeField] private float h;
    public Iowa _iowa;
    public GridController _GC;
    public MapManager _MM;
    private PlaceTiles _PT;
    private bool HayPlayer=false;
    public GameObject IcePrefab;
    [SerializeField] private int distance = 5; //Toma n-1 de tiles (Es decir, si quieres coger 5 tiles, pon distance=6)
    [SerializeField] private int distanceMoved = 5; //Mueve n tiles
    [SerializeField] private int distancePush = 10;
    private int auxDist;
    public int direction; //1:Derecha 2:Izquierda 3:Arriba 4:Abajo

    // Start is called before the first frame update
    void Awake()
    {
        _GC = GameObject.Find("Grid").GetComponent<GridController>();
        _MM = GameObject.Find("MapManager").GetComponent<MapManager>();
        _PT = GameObject.Find("TileController").GetComponent<PlaceTiles>();
        w = transform.localScale.x;
        h = transform.localScale.y;
        auxDist = distance;
    }

    // Update is called once per frame
    void Start()
    {
        int speed=60;
        Vector3Int tileO = _GC.grid.WorldToCell(transform.position);
        bool hayGas = false;
        int x = tileO.x - _GC.ogx;
        int y = tileO.y - _GC.ogy;
        print(x+","+y);
        int dist1 = 0, dist0 = 0, dist_ = 0;
        LinkedList<Vector2Int> list1= new LinkedList<Vector2Int>();
        LinkedList<Vector2Int> list0= new LinkedList<Vector2Int>();
        LinkedList<Vector2Int> list_= new LinkedList<Vector2Int>();
        HayPlayer=false;
        if (_GC.tiles[x, y].GetPlayer() != null)
                {
                    switch (_GC.tiles[x, y].GetPlayer().tag)
                    {
                        case "Player": auxDist = 5; break;
                        case "Enemy": auxDist = 5; break;
                        case "StoneBox": auxDist = 5; speed=48; break;
                        case "IceCube": auxDist = 1000; speed=75; break;
                        case "WoodBox": auxDist = 5; break;
                    }
                HayPlayer=true;
                }
        print(HayPlayer+", dir: "+direction);
            
        switch (direction)
        {
            case 1:

                for (int k = 1; k >= -1; k--)
                {
                    for (int i = 0; i < distance; i++)
                    {
                        if (_GC.tiles[x + i, y + k].GetTileState() < 5)
                        {
                            if (_GC.tiles[x + i, y + k].GetTileEffect() == 1 || _GC.tiles[x + i, y + k].GetTileEffect() == 7)
                            {
                                switch (k)
                                {
                                    case 1: dist1++; list1.AddLast(new Vector2Int(x+i,y+k)); break;
                                    case 0: dist0++; list0.AddLast(new Vector2Int(x+i,y+k)); break;
                                    case -1: dist_++; list_.AddLast(new Vector2Int(x+i,y+k)); break;
                                }
                                hayGas = true;
                            }else{break;}
                        }
                        else { break; }
                    }
                }

                print(dist1 + ";" + dist0 + ";" + dist_);

                if (hayGas)
                {
                    StartCoroutine(PushGas(0.25f, dist1, dist0, dist_, x, y, 1,list1,list0,list_));
                }

                if(HayPlayer){
                    _GC.tiles[x, y].player.Push(1, 0, auxDist, speed);
                }else { if(_GC.tiles[x,y].GetTileState()==9){_PT.PlaceAfterBreak(x,y,1,0);}else{_GC.tiles[x, y].addEffect(3, true, 1, -1);} }

                if (!_iowa.getMove())
                {
                    _iowa.ChangeMapShown(1);
                }
                break;

            case 2:


                for (int k = 1; k >= -1; k--)
                {
                    for (int i = 0; i < distance; i++)
                    {
                        if (_GC.tiles[x - i, y + k].GetTileState() < 8)
                        {
                            if (_GC.tiles[x - i, y + k].GetTileEffect() == 1 || _GC.tiles[x - i, y + k].GetTileEffect() == 7)
                            {
                                switch (k)
                                {
                                    case 1: dist1++; list1.AddLast(new Vector2Int(x-i,y+k)); break;
                                    case 0: dist0++; list0.AddLast(new Vector2Int(x-i,y+k));break;
                                    case -1: dist_++; list_.AddLast(new Vector2Int(x-i,y+k));break;
                                }
                                hayGas = true;
                            }else{break;}
                        }
                        else { break; }
                    }
                }

                print(dist1 + ";" + dist0 + ";" + dist_);
                if (hayGas)
                {
                    StartCoroutine(PushGas(0.25f, dist1, dist0, dist_, x, y, 2,list1,list0,list_));
                }

                if (HayPlayer)
                {
                    _GC.tiles[x, y].player.Push(-1, 0, auxDist, speed);
                }
                else { if(_GC.tiles[x,y].GetTileState()==9){_PT.PlaceAfterBreak(x,y,-1,0);}else{_GC.tiles[x, y].addEffect(3, true, 2, -1);} }

                if (!_iowa.getMove())
                {
                    _iowa.ChangeMapShown(1);
                }

                break;

            case 3:

                for (int k = 1; k >= -1; k--)
                {
                    for (int i = 0; i < distance; i++)
                    {
                        if (_GC.tiles[x + k, y + i].GetTileState() < 8)
                        {
                            if (_GC.tiles[x + k, y + i].GetTileEffect() == 1 || _GC.tiles[x + k, y + i].GetTileEffect() == 7)
                            {
                                switch (k)
                                {
                                    case 1: dist1++; list1.AddLast(new Vector2Int(x+k,y+i)); break;
                                    case 0: dist0++; list0.AddLast(new Vector2Int(x+k,y+i)); break;
                                    case -1: dist_++; list_.AddLast(new Vector2Int(x+k,y+i)); break;
                                }
                                hayGas = true;
                            }else{break;}
                        }
                        else { break; }
                    }
                }

                print(dist1 + ";" + dist0 + ";" + dist_);
                if (hayGas)
                {
                    StartCoroutine(PushGas(0.25f, dist1, dist0, dist_, x, y, 3,list1,list0,list_));
                }

                if (HayPlayer)
                {
                    _GC.tiles[x, y].player.Push(0, 1, auxDist, speed);
                }
                else { if(_GC.tiles[x,y].GetTileState()==9){_PT.PlaceAfterBreak(x,y,0,1);}else{_GC.tiles[x, y].addEffect(3, true, 3, -1);} }

                if (!_iowa.getMove())
                {
                    _iowa.ChangeMapShown(1);
                }

                distance = auxDist;
                break;
            case 4:
                for (int k = 1; k >= -1; k--)
                {
                    for (int i = 0; i < distance; i++)
                    {
                        if (_GC.tiles[x + k, y - i].GetTileState() < 8)
                        {
                            if (_GC.tiles[x + k, y - i].GetTileEffect() == 1 || _GC.tiles[x + k, y - i].GetTileEffect() == 7)
                            {
                                switch (k)
                                {
                                    case 1: dist1++; list1.AddLast(new Vector2Int(x+k,y-i)); break;
                                    case 0: dist0++; list0.AddLast(new Vector2Int(x+k,y-i)); break;
                                    case -1: dist_++; list_.AddLast(new Vector2Int(x+k,y-i)); break;
                                }
                                hayGas = true;
                            }else{break;}
                        }
                        else { break; }
                    }
                }

                print(dist1 + ";" + dist0 + ";" + dist_);
                if (hayGas)
                {
                    StartCoroutine(PushGas(0.25f, dist1, dist0, dist_, x, y, 4, list1, list0, list_));
                }

                if (HayPlayer)
                {
                    _GC.tiles[x, y].player.Push(0, -1, auxDist, speed);
                }
                else { if(_GC.tiles[x,y].GetTileState()==9){_PT.PlaceAfterBreak(x,y,0,-1);}else{_GC.tiles[x, y].addEffect(3, true, 4, -1);} }

                if (!_iowa.getMove())
                {
                    _iowa.ChangeMapShown(1);
                }
                break;


        }

        StartCoroutine(DestroyEffect(2)); //Destruye el prefab en 2 (de momento) segs tras la animacion
    }

    IEnumerator PushPlayerWait(int x, int y, float sec, int distancePush, int dir)
    {
        WaitForSeconds wfs = new WaitForSeconds(sec);

        Transform oldPosPlayer = _GC.tiles[x, y].GetPlayer().GetComponent<Transform>();

        switch (dir)
        {
            case 1:
                for (int i = 0; i < distancePush; i++)
                {
                    if (_GC.tiles[x + i + 1, y].GetTileState() < 5)
                    {
                        oldPosPlayer.position += (new Vector3(10, 0, 0));
                    }
                    else
                    {
                        break;
                    }
                    yield return wfs;
                }
                break;

            case 2:
                for (int i = 0; i < distancePush; i++)
                {
                    if (_GC.tiles[x - i - 1, y].GetTileState() < 5)
                    {
                        oldPosPlayer.position -= (new Vector3(10, 0, 0));
                    }
                    else
                    {
                        break;
                    }
                    yield return wfs;

                }
                break;

            case 3:
                for (int i = 0; i < distancePush; i++)
                {
                    if (_GC.tiles[x, y + i + 1].GetTileState() < 5)
                    {
                        oldPosPlayer.position += (new Vector3(0, 10, 0));
                    }
                    else
                    {
                        break;
                    }
                    yield return wfs;
                }
                break;
            case 4:
                for (int i = 0; i < distancePush; i++)
                {
                    if (_GC.tiles[x, y - i - 1].GetTileState() < 5)
                    {
                        oldPosPlayer.position -= (new Vector3(0, 10, 0));
                    }
                    else
                    {
                        break;
                    }
                    yield return wfs;
                }
                break;
        }
    }

    IEnumerator PushGas(float sec, int dist1, int dist0, int dist_, int x, int y, int dir, LinkedList<Vector2Int> l1, LinkedList<Vector2Int> l0, LinkedList<Vector2Int> l_)
    {
        WaitForSeconds wfs = new WaitForSeconds(sec);
        int effectAdd;
        int dx=0; int dy=0;
        switch(dir){
            case 1: dx=1; break;
            case 2: dx=-1; break;
            case 3: dy=1; break;
            case 4: dy=-1; break;
        }
        for (int j = 0; j < distanceMoved; j++){
                    if(l1.Count!=0){
                    if (_GC.tiles[l1.Last.Value.x + dx, l1.Last.Value.y + dy].GetTileEffect()!=16){
                    if(_GC.tiles[l1.Last.Value.x,l1.Last.Value.y].GetTileEffect()==1 || _GC.tiles[l1.Last.Value.x,l1.Last.Value.y].GetTileEffect()==7){effectAdd=_GC.tiles[l1.Last.Value.x,l1.Last.Value.y].GetTileEffect();
                    _GC.tiles[l1.Last.Value.x + dx, l1.Last.Value.y + dy].addEffect(effectAdd,false,0,-1);}
                    l1.AddLast(new Vector2Int(l1.Last.Value.x + dx, l1.Last.Value.y + dy));
                    _GC.tiles[l1.First.Value.x,l1.First.Value.y].trySetNule();
                    l1.RemoveFirst();
                    
                    }else{
                    l1.RemoveLast();
                    }
                    }

                    if(l0.Count!=0){
                    if (_GC.tiles[l0.Last.Value.x + dx, l0.Last.Value.y + dy].GetTileEffect()!=16){
                    if(_GC.tiles[l0.Last.Value.x,l0.Last.Value.y].GetTileEffect()==1 || _GC.tiles[l0.Last.Value.x,l0.Last.Value.y].GetTileEffect()==7){effectAdd=_GC.tiles[l0.Last.Value.x,l0.Last.Value.y].GetTileEffect();
                    _GC.tiles[l0.Last.Value.x + dx, l0.Last.Value.y + dy].addEffect(effectAdd,false,0,-1);}
                    l0.AddLast(new Vector2Int(l0.Last.Value.x + dx, l0.Last.Value.y + dy));
                    _GC.tiles[l0.First.Value.x,l0.First.Value.y].trySetNule();
                    l0.RemoveFirst();
                    
                    }else{
                    l0.RemoveLast();
                    }
                    }

                    if(l_.Count!=0){
                    if (_GC.tiles[l_.Last.Value.x + dx, l_.Last.Value.y + dy].GetTileEffect()!=16){
                    if(_GC.tiles[l_.Last.Value.x,l_.Last.Value.y].GetTileEffect()==1 || _GC.tiles[l_.Last.Value.x,l_.Last.Value.y].GetTileEffect()==7){effectAdd=_GC.tiles[l_.Last.Value.x,l_.Last.Value.y].GetTileEffect();
                    _GC.tiles[l_.Last.Value.x + dx, l_.Last.Value.y + dy].addEffect(effectAdd,false,0,-1);}
                    l_.AddLast(new Vector2Int(l_.Last.Value.x + dx, l_.Last.Value.y + dy));
                    _GC.tiles[l_.First.Value.x,l_.First.Value.y].trySetNule();
                    l_.RemoveFirst();
                    
                    }else{
                    l_.RemoveLast();
                    }

                    
                    }

                    yield return wfs;
        }
        
    }
    IEnumerator DestroyEffect(float sec)
    {
        WaitForSeconds wfs = new WaitForSeconds(sec);
        yield return wfs;
        Destroy(this.gameObject);
    }

}