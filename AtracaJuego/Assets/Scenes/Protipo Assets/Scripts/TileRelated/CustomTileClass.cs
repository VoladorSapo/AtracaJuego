using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTileClass
{
    public int tileSpriteId;
    public int tileState;
    
    public CustomTileClass(int SpriId, int state){
        tileSpriteId=SpriId;
        tileState=state;
    }

    public void DisplayStats(){
        Debug.Log("La Tile tiene el sprite "+tileSpriteId+" y el estado "+tileState);
    }

    public int GetSpriteId(){
        return tileSpriteId;
    }

    public int GetTileState(){
        return tileState;
    }

    public void SetTileStats(int sprite, int state){
        tileSpriteId=sprite;
        tileState=state;
    }


}
