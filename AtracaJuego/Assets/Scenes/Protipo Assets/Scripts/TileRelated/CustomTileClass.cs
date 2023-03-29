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
    //public string playerOnTop;
    public int tileFadeEffect;

    public CustomTileClass(int SpriId, int state, int effect, Vector3Int pos, int fade){
        tilePos=pos;
        tileSpriteId=SpriId;
        tileState=state;
        tileEffect=effect;
        tileFadeEffect=fade;
    }

    public void DisplayStats(){
        Debug.Log("La Tile tiene el sprite "+tileSpriteId+" y el estado "+tileState+" con el efecto "+tileEffect);
        Debug.Log("Tiene un FadeEffect de "+tileFadeEffect);
        if(player!=null){
            Debug.Log(" y el jugador "+player.name+" encima");
        }
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

    public int GetTileFade(){
        return tileFadeEffect;
    }

    public PlayerBase GetPlayer(){
        return player;
    }

    //public string GetPlayerOnTop(){
    //    return playerOnTop;
    //}

    public void SetTileStats(int sprite, int state, int effect, int fade){
        tileSpriteId=sprite;
        tileState=state;
        tileEffect=effect;
        tileFadeEffect=fade;
    }

    public void SetTileStatsWith(CustomTileClass n){
        tileSpriteId=n.tileSpriteId;
        tileState=n.tileState;
        tileEffect=n.tileEffect;
        if(n.tileFadeEffect>tileFadeEffect){tileFadeEffect=n.tileFadeEffect;}
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

    public void SetTileFade(int fade){
        tileFadeEffect=fade;
    }

    public void LowerFade(){
        if(tileFadeEffect>0){
        tileFadeEffect--; //Cuando llegue a 0 el effecto se pone a 0
        if(tileFadeEffect==0){
            SetTileEffect(0);
        }
        }
    }

    //public void SetPlayerOnTop(string player){
    //    Debug.Log("ass");
    //    playerOnTop=player;
    //}

    public void setPlayer(PlayerBase newplayer)
    {
        player = newplayer;
        Debug.Log("ou");
        if(tileState == 13)
        {
            Debug.Log("uo");
            player.pressWinTile();
        }
    }

}
