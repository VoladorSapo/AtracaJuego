using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTileClass
{
    public Vector3Int tilePos;
    public int tileSpriteId;
    public int tileState;
    public int tileEffect;
    public PlayerBase player;
    public CustomTileClass(int SpriId, int state, int effect, Vector3Int pos){
        tilePos=pos;
        tileSpriteId=SpriId;
        tileState=state;
        tileEffect=effect;
    }

    public void DisplayStats(){
        Debug.Log("La Tile tiene el sprite "+tileSpriteId+" y el estado "+tileState+" con el efecto "+tileEffect);
    }

    public int GetSpriteId(){
        return tileSpriteId;
    }

    public int GetTileState(){
        return tileState;
    }

    public int GetTileEffect(){
        return tileEffect;
    }

    public Vector3Int GetTilePos(){
        return tilePos;
    }

    public void SetTileStats(int sprite, int state, int effect){
        tileSpriteId=sprite;
        tileState=state;
        tileEffect=effect;
    }

    public void SetTileSprite(int sprite){
        tileSpriteId=sprite;
    }

    public void SetTileState(int state){
        tileState=state;
    }

    public void SetTileEffect(int effect){
        tileEffect=effect;
    }
    public void setPlayer(PlayerBase newplayer)
    {
        player = newplayer;
        Debug.Log("ou");
        if(tileState == 8)
        {
            Debug.Log("uo");
            player.pressWinTile();
        }
    }

}
