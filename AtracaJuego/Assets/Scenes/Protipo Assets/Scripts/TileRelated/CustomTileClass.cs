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
    public int[] tileFadeEffect; //i: 0=gas, 1=mojado, 2=gasolina, 3=deadlygas, 4=fuego, 5=hielo, 6=electricwet, 7=electricgas, 8=iceSpiked


    public CustomTileClass(int SpriId, int state, int effect, Vector3Int pos, int fade){
        tilePos=pos;
        tileSpriteId=SpriId;
        tileState=state;
        tileEffect=effect;
        tileFadeEffect=new int[10];
    }

    public void DisplayStats(){
        Debug.Log("La Tile tiene el sprite "+tileSpriteId+" y el estado "+tileState+" con el efecto "+tileEffect);
        Debug.Log("Su pos es: "+tilePos);
        Debug.Log(GetPlayer());
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

    public int GetTileFade(int i){
        return tileFadeEffect[i];
    }

    public PlayerBase GetPlayer(){
        return player;
    }

    //public string GetPlayerOnTop(){
    //    return playerOnTop;
    //}

    public void SetTileStats(int sprite, int state, int effect, int i, int fade){
        tileSpriteId=sprite;
        tileState=state;
        tileEffect=effect;
        tileFadeEffect[i]=fade;
    }

    public void SetTileStatsWith(CustomTileClass n){
        tileSpriteId=n.tileSpriteId;
        tileState=n.tileState;
        tileEffect=n.tileEffect;
        tileFadeEffect=n.tileFadeEffect;
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

    public void SetTileFade(int i, int fade){
        tileFadeEffect[i]=fade;
    }

    public void LowerFade(){
        for(int i=0; i<tileFadeEffect.Length; i++){
        if(tileFadeEffect[i]>0){
        tileFadeEffect[i]--; //Cuando llegue a 0 el effecto se pone a 0
        if(tileFadeEffect[i]==0){
            //switch con todos los casos del fade
        }
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

    public void addEffect(int effect){

        //Implmentar combinaciones del excel aqui
        switch(effect){
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8: break;
        }
    }

}
