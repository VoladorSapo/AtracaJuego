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
    public MapManager _MM;
    public int tileFadeEffect; //i: 0=gas, 1=mojado, 2=gasolina, 3=deadlygas, 4=fuego, 5=hielo, 6=electricwet, 7=electricgas, 8=iceSpiked


    public CustomTileClass(int SpriId, int state, int effect, Vector3Int pos, int fade){
        tilePos=pos;
        tileSpriteId=SpriId;
        tileState=state;
        tileEffect=effect;
        _MM=GameObject.Find("MapManager").GetComponent<MapManager>();
        tileFadeEffect=fade;
    }

    public void DisplayStats(){
        Debug.Log("La Tile tiene el sprite "+tileSpriteId+" y el estado "+tileState+" con el efecto "+tileEffect+" y "+tileFadeEffect);
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

    public void SetTileFade(int fade){
        tileFadeEffect=fade;
    }

    public void LowerFade(){
        tileFadeEffect--;
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

    public void addEffect(int effect, bool bypass){
        //Faltan implementar cambios de sprites y FadeEffects

        //Implmentar combinaciones del excel aqui
        switch(effect){ //0=None 1=Gas 2=Fire 3=Push 4=Ice 5=Elec //Especiales 6=Wet
            case 0:
                    Debug.Log("0"); tileEffect=0; tileFadeEffect=0; break;
            case 1:
                    if(tileEffect!=16){
                    switch(tileEffect){
                        case 0: tileEffect=1; break;
                        //case 2: cambio de sprite a nube mojada pero con propiedades nulas?
                        //case 3: cambio de sprite pero propiedades iguales que un gas normal?
                        case 4: tileEffect=4; _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2); break;
                        case 5: tileEffect=3; break;
                        case 6: tileEffect=7; break;
                        case 12: tileEffect=4; _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2); break;
                        case 13: tileEffect=4; _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2); break;
                    }} break;
            case 2:
                    if(tileEffect!=16){
                    switch(tileEffect){
                        case 1: tileEffect=4; _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2); _MM.Damage(0,tilePos.x,tilePos.y); break;
                        case 2: tileEffect=0; break;
                        case 3: tileEffect=12; _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2); _MM.Damage(1,tilePos.x,tilePos.y); break; 
                        case 5: tileEffect=2; _MM.SpreadEffectLimit(tilePos.x,tilePos.y,2,0,5); break;
                        case 6: tileEffect=0; break;
                        case 7: tileEffect=0; break; 
                        case 8: tileEffect=1; break;
                        case 9: tileEffect=3; break;
                        case 10: tileEffect=3; break;
                        case 11: tileEffect=4; _MM.SpreadEffectLimit(tilePos.x,tilePos.y,2,0,5); _MM.Damage(2,tilePos.x,tilePos.y); break;
                        case 14: tileEffect=11; break;
                        case 15: tileEffect=11; break;
                    }} break;
            case 3:
                    if(tileEffect!=16){
                    switch(tileEffect){
                        case 5: tileEffect=8; break;
                        case 9: tileEffect=10; break;
                        case 14: tileEffect=15; break;
                    }} break;
            case 4:
                    if(tileEffect!=16){
                    switch(tileEffect){
                        case 0: tileEffect=5; break;
                        case 1: tileEffect=3; break;
                        case 2: tileEffect=5; break;
                        case 3: tileEffect=9; break;
                        case 4: tileEffect=2; break;
                        case 6: tileEffect=5; break;
                        case 7: tileEffect=6; break;
                        case 11: tileEffect=14; break;
                    }} break;
            case 5:
                    if(tileEffect!=16){
                    switch(tileEffect){
                        case 1: tileEffect=7; break;
                        case 2: tileEffect=6; break;
                        case 3: tileEffect=11; break;
                        //case 6: resetea el fade?
                        //case 7: resetea el fade?
                    }}break;
            case 6:
                    if(tileEffect!=16){
                    switch(tileEffect){
                        case 0: tileEffect=2; break;
                        case 4: tileEffect=0; break;
                        case 6: tileEffect=6; _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,5); break;
                        case 7: tileEffect=7; _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,5); break;
                        case 12: tileEffect=0; break;
                        case 13: tileEffect=0; break;
                    }}break;
                    }
        }

        public void loseHealth(int hp){
            player.loseHealth(hp);
        }
    }


