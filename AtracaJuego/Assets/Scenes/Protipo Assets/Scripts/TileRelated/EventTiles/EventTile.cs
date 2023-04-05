using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTile : MonoBehaviour
{
    [SerializeField] protected GridController GC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public virtual void SetGame()
    {
        Vector3Int pos = GC.grid.WorldToCell(transform.position);
       // GC.tiles[pos.x - GC.ogx, pos.y - GC.ogy].setEvent(this);
    }
    public virtual void PressEvent()
    {

    }
}
