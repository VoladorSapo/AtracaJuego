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
    public GameObject[] GameObjs;


    //public bool walkable;

    private void Awake()
    {
        _GC = GameObject.Find("Grid").GetComponent<GridController>();
        map = GameObject.Find("Ground").GetComponent<Tilemap>();
    }

    private void Update()
    {

    }


    Vector3Int gridMouseCalculate()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return map.WorldToCell(mousePos);
    }


    public void SpreadEffectNoLimit(int x, int y, int effect, int direction, int lock_)
    {
        int up1 = y + 1;
        int down1 = y - 1;
        int left1 = x - 1;
        int right1 = x + 1;
        _GC.tiles[x, up1].addEffect(effect, false, direction, lock_);
        _GC.tiles[x, down1].addEffect(effect, false, direction, lock_);
        _GC.tiles[x, y].addEffect(effect, false, direction, lock_);
        _GC.tiles[left1, y].addEffect(effect, false, direction, lock_);
        _GC.tiles[right1, y].addEffect(effect, false, direction, lock_);
    }

    public void SpreadEffectLimit(int x, int y, int effect, int Range, int MaxRange, int direction, int lock_)
    {
        int up1 = y + 1;
        int down1 = y - 1;
        int left1 = x - 1;
        int right1 = x + 1;

        _GC.tiles[x, y].addEffect(effect, false, direction, lock_);
        Range++;
        if (Range <= MaxRange)
        {

            if (direction != 4 && _GC.tiles[x, up1].canAddEffect(effect)) { SpreadEffectLimit(x, up1, effect, Range, MaxRange, direction, lock_); }

            if (direction != 3 && _GC.tiles[x, down1].canAddEffect(effect)) { SpreadEffectLimit(x, down1, effect, Range, MaxRange, direction, lock_); }

            if (direction != 1 && _GC.tiles[left1, y].canAddEffect(effect)) { SpreadEffectLimit(left1, y, effect, Range, MaxRange, direction, lock_); }

            if (direction != 2 && _GC.tiles[right1, y].canAddEffect(effect)) { SpreadEffectLimit(right1, y, effect, Range, MaxRange, direction, lock_); }
        }



    }

    public void CleanLimit(int x, int y, Vector3 og, int MaxRange, int lock_)
    {
        int up1 = y + 1;
        int down1 = y - 1;
        int left1 = x - 1;
        int right1 = x + 1;

        _GC.tiles[x, y].addEffect(0, false, 0, 0);
        
        
        Debug.LogWarning("Arriba: "+x+",,"+up1+",,"+lock_);
        
            if (_GC.tiles[x, up1].GetTileEffect()==lock_ && Vector3.Distance(new Vector3(x,up1,0),og)<MaxRange) { Debug.LogWarning(x+",,"+y+",,"+lock_); CleanLimit(x, up1, og, MaxRange, lock_); }

            if (_GC.tiles[x, down1].GetTileEffect()==lock_ && Vector3.Distance(new Vector3(x,down1,0),og)<MaxRange) { CleanLimit(x, down1, og, MaxRange, lock_); }

            if (_GC.tiles[left1, y].GetTileEffect()==lock_ && Vector3.Distance(new Vector3(left1,y,0),og)<MaxRange) { CleanLimit(left1, y, og, MaxRange,lock_); }

            if (_GC.tiles[right1, y].GetTileEffect()==lock_ && Vector3.Distance(new Vector3(right1,y,0),og)<MaxRange) { CleanLimit(right1, y, og, MaxRange, lock_); }



    }

    public IEnumerator SNL(int x, int y, int effect, int dir, int lock_, float sec)
    {
        WaitForSeconds wfs = new WaitForSeconds(sec);
        print("xd");
        yield return wfs;
        print("xdd");
        SpreadEffectNoLimit(x, y, effect, dir, lock_);
    }


    public void Damage(int codeDamage, int x, int y)
    {
        print("jajas");
        PlayerBase p = _GC.tiles[x, y].player;
        switch (codeDamage)
        {
            case 0: if (p != null) { if (p.tag == "Player") { p.loseHealth(1); } else { p.loseHealth(3); } } break;
            case 1: if (p != null) { if (p.tag == "Player") { p.loseHealth(2); } else { p.loseHealth(5); } } break;
            case 2: if (p != null) { if (p.tag == "Player") { p.loseHealth(3); } else { p.loseHealth(7); } } break;
            case 3: if (p != null) { if (p.tag == "Player") { p.loseHealth(1); } else { p.loseHealth(2); } } break;
            case 4: if (p != null) { if (p.tag == "Player") { p.loseHealth(1); } else { p.loseHealth(5); } } break;
            case 5: if (p != null) { if (p.tag == "Player") { p.loseHealth(1); } else { p.loseHealth(2); } } break;
            case 7: if (p != null) { if (p.tag == "Player") { p.loseHealth(1); } else { p.loseHealth(1); } } break; //Garrote
            case 8: if (p != null) { if (p.tag == "Player") { p.loseHealth(2); } else { p.loseHealth(2); } } break; //SuperGarrote
            case 9: if (p != null) { if (p.tag == "Player") { p.loseHealth(2); p.getStunned();} else { p.loseHealth(2); } } break; //NanomaquinasHijo
            case 10: if (p != null) { if (p.tag == "Player") { p.loseHealth(2); } else { p.loseHealth(2); } } break; //Garrote Morado
            case 11: if (p != null) { if (p.tag == "Player") { p.loseHealth(1); } else { p.loseHealth(1); } } break; //Garrote Azul


            case 6: if (p != null) { if (p.tag == "Player") { p.loseHealth(1); } else if (p.tag != "IceCube") { p.loseHealth(4); } } break;
        }
    }

    public void InstantiatePrefab(int GO, Vector3Int pos)
    {
        Vector3 newPos = _GC.grid.CellToWorld(pos) + new Vector3(_GC.ogx * 10, _GC.ogy * 10, 0);
        newPos += new Vector3(5, 5, 0);
        if (GO >= 0) { Instantiate(GameObjs[GO], newPos, Quaternion.identity); }
    }




}
