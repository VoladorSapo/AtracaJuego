using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CustomTileClass
{
    public Vector3Int tilePos;
    public int tileSpriteId;
    public int tileState;
    public int tileEffect;
    public PlayerBase player;
    public MapManager _MM;
    public GridController _GC;
    public PlaceTiles _PT;
    public int tileFadeEffect;
    public EventTile _eventile;
    //Lista de TileMaps afectados



    public CustomTileClass(int SpriId, int state, int effect, Vector3Int pos, int fade){
        tilePos=pos;
        tileSpriteId=SpriId;
        tileState=state;
        tileEffect=effect;
        _MM=GameObject.Find("MapManager").GetComponent<MapManager>();
        _GC=GameObject.Find("Grid").GetComponent<GridController>();
        tileFadeEffect=fade;
        _PT=GameObject.Find("TileController").GetComponent<PlaceTiles>();
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
        if(tileFadeEffect>0){
            tileFadeEffect--;
            if(tileFadeEffect==0){addEffect(0,false,0,-1);}
        }
        
    }

    //public void SetPlayerOnTop(string player){
    //    Debug.Log("ass");
    //    playerOnTop=player;
    //}
    public void setEvent(EventTile _event)
    {
        _eventile = _event;
        //SetTileState(13);
    }
    public void setPlayer(PlayerBase newplayer)
    {
        player = newplayer;
        if(_eventile != null && newplayer != null)
        {
            Debug.Log("uo");
            _eventile.PressEvent();
        }

        if(tileState==1 || tileState==2){
            if(newplayer==null){tileState=1; Debug.LogWarning("no placa");}else{tileState=2; Debug.LogWarning("placa");}
        }
    }

    public void addEffect(int effect, bool bypass, int direction, int lock_){
        //Faltan implementar cambios de sprites y FadeEffects
        Vector3Int og=new Vector3Int(_GC.ogx,_GC.ogy,0);
        if(lock_==-1){lock_=GetTileEffect();}
        //Implmentar combinaciones del excel aqui
        switch(effect){ //0=None 1=Gas 2=Fire 3=Push 4=Ice 5=Elec //Especiales 6=Wet
            case 0:
                    if(tileEffect!=16){tileEffect=0; tileFadeEffect=0; _PT.Charco.SetTile(tilePos+og,null); _PT.Gas.SetTile(tilePos+og,null); } break;
            case 1:
                    if(tileEffect!=16){
                    switch(tileEffect){
                        case 0: AddEffectAct(1,og,bypass,lock_,1,3,_PT.gasT,null,effect,0,direction,0); break;//tileEffect=1;    tileFadeEffect=3; _PT.Gas.SetTile(tilePos+og,_PT.gasT); _PT.Charco.SetTile(tilePos+og,null); break;
                        case 2: AddEffectAct(1,og,bypass,lock_,1,3,_PT.gasT,null,effect,0,direction,0); break;//tileEffect=1;    tileFadeEffect=3; _PT.Gas.SetTile(tilePos+og,_PT.gasT); _PT.Charco.SetTile(tilePos+og,null); break;
                        case 4: AddEffectAct(7,og,bypass,lock_,4,1,null,null,2,0,direction,0); break;//tileEffect=4;    tileFadeEffect=1; _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2,direction,lock_); _MM.Damage(0,tilePos.x,tilePos.y); break;
                        case 5: AddEffectAct(1,og,bypass,lock_,3,3,null,null,effect,0,direction,0); break; //tileEffect=3;    tileFadeEffect=3; _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); break;
                        case 6: AddEffectAct(8,og,bypass,lock_,6,0,null,null,5,0,direction,0); break; //tileFadeEffect=FadeAround(6);      _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,5,direction,lock_); break;
                        case 7: AddEffectAct(8,og,bypass,lock_,7,0,null,null,5,0,direction,0); break; //tileFadeEffect=FadeAround(7);      _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,5,direction,lock_); break;
                        case 12: AddEffectAct(7,og,bypass,lock_,4,1,null,null,2,0,direction,0); break; //tileEffect=4;   tileFadeEffect=1; _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2,direction,lock_); _MM.Damage(1,tilePos.x,tilePos.y); break;
                        case 13: AddEffectAct(7,og,bypass,lock_,4,1,null,null,2,0,direction,0); break; //tileEffect=4;   tileFadeEffect=1; _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2,direction,lock_);  _MM.Damage(2,tilePos.x,tilePos.y); break;
                    }} break;
            case 2:
                    if(tileEffect!=16){
                    switch(tileEffect){
                        case 1: AddEffectAct(7,og,bypass,lock_,4,1,null,null,2,0,direction,0); break;//tileEffect=4; tileFadeEffect=1;  _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2,direction,lock_); _MM.Damage(0,tilePos.x,tilePos.y); break;
                        case 2: AddEffectAct(1,og,bypass,lock_,0,0,null,null,0,0,direction,0); break;//tileEffect=0; tileFadeEffect=0;  _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); break;
                        case 3: AddEffectAct(7,og,bypass,lock_,12,1,null,null,2,0,direction,1); break;//tileEffect=12; tileFadeEffect=1; _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2,direction,lock_); _MM.Damage(1,tilePos.x,tilePos.y); break; 
                        case 5: AddEffectAct(3,og,bypass,lock_,2,3,null,_PT.wetT,2,2,direction,0); break;//tileEffect=2; tileFadeEffect=3;  _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,_PT.wetT); if(bypass){_MM.SpreadEffectLimit(tilePos.x,tilePos.y,2,0,1,0,lock_);} break;
                        case 6: AddEffectAct(1,og,bypass,lock_,0,0,null,null,0,0,direction,0); break;//tileEffect=0; tileFadeEffect=0;  _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); break;
                        case 7: AddEffectAct(7,og,bypass,lock_,0,0,null,null,2,0,direction,4); break;//tileEffect=0; tileFadeEffect=0;  _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2,direction,lock_); _MM.Damage(4,tilePos.x,tilePos.y); break; 
                        case 8: AddEffectAct(1,og,bypass,lock_,2,3,null,_PT.wetT,0,0,direction,0); break;//tileEffect=2; tileFadeEffect=3;  _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,_PT.wetT); break;
                        case 9: AddEffectAct(3,og,bypass,lock_,3,3,null,null,0,0,direction,0); break;//tileEffect=3; tileFadeEffect=3;  _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); break;
                        case 10: AddEffectAct(3,og,bypass,lock_,3,3,null,null,0,0,direction,0); break;//tileEffect=3; tileFadeEffect=3; _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); break;
                        case 11: AddEffectAct(7,og,bypass,lock_,13,1,null,null,2,0,direction,2); break;//tileEffect=13; tileFadeEffect=1; _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2,direction,lock_); _MM.Damage(2,tilePos.x,tilePos.y); break;
                        case 14: AddEffectAct(3,og,bypass,lock_,11,3,null,null,2,2,direction,0); break;//tileEffect=11; tileFadeEffect=3;_PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); if(bypass){_MM.SpreadEffectLimit(tilePos.x,tilePos.y,2,0,5,0,lock_);} break;
                        case 15: AddEffectAct(3,og,bypass,lock_,11,3,null,null,2,2,direction,0); break;//tileEffect=11; tileFadeEffect=3;_PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); if(bypass){_MM.SpreadEffectLimit(tilePos.x,tilePos.y,2,0,5,0,lock_);} break;
                    }} break;
            case 3:
                    if(tileEffect!=16){
                    switch(tileEffect){
                        case 5: if(player!=null && player.tag=="IceCube"){}else{AddEffectAct(4,og,bypass,lock_,8,tileFadeEffect+1,null,null,3,3,direction,3);} break;//tileEffect=8; tileFadeEffect++;     _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); if(bypass){_MM.SpreadEffectLimit(tilePos.x,tilePos.y,3,0,3,direction,lock_); _MM.Damage(3,tilePos.x,tilePos.y);} break;
                        case 9: AddEffectAct(4,og,bypass,lock_,10,tileFadeEffect+1,null,null,3,3,direction,3); break;//tileEffect=10; tileFadeEffect++;    _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); if(bypass){_MM.SpreadEffectLimit(tilePos.x,tilePos.y,3,0,3,direction,lock_); _MM.Damage(3,tilePos.x,tilePos.y);} break;
                        case 14: AddEffectAct(4,og,bypass,lock_,15,tileFadeEffect+1,null,null,3,3,direction,3); break;//tileEffect=15; tileFadeEffect++;   _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); if(bypass){_MM.SpreadEffectLimit(tilePos.x,tilePos.y,3,0,3,direction,lock_); _MM.Damage(3,tilePos.x,tilePos.y);} break;
                    }} break;
            case 4:
                    if(tileEffect!=16){
                    switch(tileEffect){
                        case 0: AddEffectAct(1,og,bypass,lock_,5,5,null,_PT.iceT,0,0,direction,0); break;//tileEffect=5; tileFadeEffect=5;     _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,_PT.iceT); break;
                        case 1: AddEffectAct(1,og,bypass,lock_,3,3,null,null,0,0,direction,0); break;//tileEffect=3; tileFadeEffect=3;     _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); break;
                        case 2: AddEffectAct(1,og,bypass,lock_,5,tileFadeEffect+1,null,_PT.iceT,0,0,direction,0); break;//tileEffect=5; tileFadeEffect++;     _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,_PT.iceT); break;
                        case 3: AddEffectAct(1,og,bypass,lock_,9,1000,null,null,0,0,direction,0); break;//tileEffect=9; tileFadeEffect=1000;  _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); break;
                        case 4: AddEffectAct(1,og,bypass,lock_,2,3,null,_PT.wetT,0,0,direction,0); break;//tileEffect=2; tileFadeEffect=3;     _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,_PT.wetT); break;
                        case 6: AddEffectAct(1,og,bypass,lock_,5,5,null,_PT.iceT,0,0,direction,0); break;//tileEffect=5; tileFadeEffect=5;     _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,_PT.iceT); break;
                        case 7: AddEffectAct(1,og,bypass,lock_,6,3,null,null,0,0,direction,0); break;//tileEffect=6; tileFadeEffect=3;     _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); break;
                        case 11: AddEffectAct(1,og,bypass,lock_,14,1000,null,null,0,0,direction,0); break;//tileEffect=14; tileFadeEffect=1000;_PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); break;
                    }} break;
            case 5:
                    if(tileEffect!=16){
                    switch(tileEffect){
                        case 1: AddEffectAct(5,og,bypass,lock_,7,tileFadeEffect+1,null,null,5,0,direction,0); break;//tileEffect=7; tileFadeEffect++;     _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,5,direction,lock_); break;
                        case 2: AddEffectAct(7,og,bypass,lock_,6,3,null,null,5,0,direction,4); break;//tileEffect=6; tileFadeEffect=3;     _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,5,direction,lock_);  _MM.Damage(4,tilePos.x,tilePos.y); break;
                        case 3: AddEffectAct(5,og,bypass,lock_,11,tileFadeEffect+1,null,null,5,0,direction,0); break;//tileEffect=11; tileFadeEffect++;    _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,5,direction,lock_); break;
                        //case 6: resetea el fade?
                        //case 7: resetea el fade?
                    }}break;
            case 6:
                    if(tileEffect!=16){
                    switch(tileEffect){
                        case 0: AddEffectAct(1,og,bypass,lock_,2,3,null,_PT.wetT,0,0,direction,0); break;//tileEffect=2; tileFadeEffect=3;             _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,_PT.wetT); break;
                        case 4: AddEffectAct(1,og,bypass,lock_,0,0,null,null,0,0,direction,0); break;//tileEffect=0;                               _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); break;
                        case 6: AddEffectAct(6,og,bypass,lock_,6,0,null,null,5,0,direction,0); break;//tileEffect=6; tileFadeEffect=FadeAround(6); _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,5,direction,lock_); break;
                        case 7: AddEffectAct(6,og,bypass,lock_,6,0,null,null,5,0,direction,0); break;//tileEffect=6; tileFadeEffect=FadeAround(6); _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,5,direction,lock_); break;
                        case 12: AddEffectAct(1,og,bypass,lock_,0,0,null,null,0,0,direction,0); break;//tileEffect=0;                              _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); break;
                        case 13: AddEffectAct(1,og,bypass,lock_,0,0,null,null,0,0,direction,0); break;//tileEffect=0;                              _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); break;
                    }}break;
            case 7:
                    if(tileEffect!=16){
                        switch(tileEffect){
                        case 0: AddEffectAct(2,og,bypass,lock_,7,0,null,null,0,0,direction,0); break;//tileEffect=7; tileFadeEffect=FadeAround(7); _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); break;
                        case 1: AddEffectAct(6,og,bypass,lock_,7,0,null,null,5,0,direction,0); break;//tileEffect=7; tileFadeEffect=FadeAround(7); _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,5,direction,lock_); break;
                        case 2: AddEffectAct(6,og,bypass,lock_,7,0,null,null,5,0,direction,0); break;//tileEffect=7; tileFadeEffect=FadeAround(7); _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,5,direction,lock_); break;
                        case 4: AddEffectAct(7,og,bypass,lock_,0,0,null,null,2,0,direction,1); break;//tileEffect=0; tileFadeEffect=0;             _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2,direction,lock_); _MM.Damage(1,tilePos.x,tilePos.y); break;
                        case 5: AddEffectAct(1,og,bypass,lock_,11,tileFadeEffect,null,_PT.wetT,0,0,direction,0); break;//tileEffect=11;                              _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); break;
                        case 12: AddEffectAct(7,og,bypass,lock_,0,0,null,null,2,0,direction,1); break;//tileEffect=0; tileFadeEffect=0;            _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2,direction,lock_); _MM.Damage(1,tilePos.x,tilePos.y); break; //Damage
                        case 13: AddEffectAct(7,og,bypass,lock_,0,0,null,null,2,0,direction,2); break;//tileEffect=0; tileFadeEffect=0;            _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2,direction,lock_);  _MM.Damage(2,tilePos.x,tilePos.y); break; //Damage
                    }} break;
            case 8: //Similar al fuego pero con solo la caja [Funciona algo diferente]
                    if(tileEffect!=16){
                    switch(tileEffect){
                        case 1: AddEffectAct(7,og,bypass,lock_,4,1,null,null,2,0,direction,0); break;//tileEffect=4; tileFadeEffect=1;  _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2,direction,lock_); _MM.Damage(0,tilePos.x,tilePos.y); break;
                        case 2: AddEffectAct(1,og,bypass,lock_,0,0,null,null,0,0,direction,0); break;//tileEffect=0; tileFadeEffect=0;  _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); break;
                        case 3: AddEffectAct(7,og,bypass,lock_,12,1,null,null,2,0,direction,1); break;//tileEffect=12; tileFadeEffect=1; _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2,direction,lock_); _MM.Damage(1,tilePos.x,tilePos.y); break; 
                        case 5: AddEffectAct(1,og,bypass,lock_,2,3,null,_PT.wetT,2,2,direction,1); break;//tileEffect=2; tileFadeEffect=3;  _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,_PT.wetT); if(bypass){_MM.SpreadEffectLimit(tilePos.x,tilePos.y,2,0,1,0,lock_);} break;
                        case 6: AddEffectAct(1,og,bypass,lock_,0,0,null,null,0,0,direction,0); break;//tileEffect=0; tileFadeEffect=0;  _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); break;
                        case 7: AddEffectAct(7,og,bypass,lock_,0,0,null,null,2,0,direction,4); break;//tileEffect=0; tileFadeEffect=0;  _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2,direction,lock_); _MM.Damage(4,tilePos.x,tilePos.y); break; 
                        case 8: AddEffectAct(1,og,bypass,lock_,2,3,null,_PT.wetT,0,0,direction,0); break;//tileEffect=2; tileFadeEffect=3;  _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,_PT.wetT); break;
                        case 9: AddEffectAct(1,og,bypass,lock_,3,3,null,null,0,0,direction,0); break;//tileEffect=3; tileFadeEffect=3;  _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); break;
                        case 10: AddEffectAct(1,og,bypass,lock_,3,3,null,null,0,0,direction,0); break;//tileEffect=3; tileFadeEffect=3; _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); break;
                        case 11: AddEffectAct(7,og,bypass,lock_,13,1,null,null,2,0,direction,2); break;//tileEffect=13; tileFadeEffect=1; _PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2,direction,lock_); _MM.Damage(2,tilePos.x,tilePos.y); break;
                        case 14: AddEffectAct(1,og,bypass,lock_,11,3,null,null,2,2,direction,1); break;//tileEffect=11; tileFadeEffect=3;_PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); if(bypass){_MM.SpreadEffectLimit(tilePos.x,tilePos.y,2,0,5,0,lock_);} break;
                        case 15: AddEffectAct(1,og,bypass,lock_,11,3,null,null,2,2,direction,1); break;//tileEffect=11; tileFadeEffect=3;_PT.Gas.SetTile(tilePos+og,null); _PT.Charco.SetTile(tilePos+og,null); if(bypass){_MM.SpreadEffectLimit(tilePos.x,tilePos.y,2,0,5,0,lock_);} break;
                    }} break;
                    }
        }

        public int FadeAround(int effect){
            int e1=100,e2=100,e3=100,e4=100;
            bool changed=false;
            if(_GC.tiles[tilePos.x+1,tilePos.y].GetTileEffect()==effect){e1=_GC.tiles[tilePos.x+1,tilePos.y].GetTileFade(); changed=true;}
            if(_GC.tiles[tilePos.x+1,tilePos.y].GetTileEffect()==effect){e2=_GC.tiles[tilePos.x-1,tilePos.y].GetTileFade(); changed=true;}
            if(_GC.tiles[tilePos.x+1,tilePos.y].GetTileEffect()==effect){e3=_GC.tiles[tilePos.x,tilePos.y+1].GetTileFade(); changed=true;}
            if(_GC.tiles[tilePos.x+1,tilePos.y].GetTileEffect()==effect){e4=_GC.tiles[tilePos.x,tilePos.y-1].GetTileFade(); changed=true;}
            
            if(changed){return Mathf.Min(e1,e2,e3,e4);}else{return 3;}
        }
                                 //Set                                  //Do                                                                            //Damage
        private void AddEffectAct(int id, Vector3Int og, bool bypass, int lock_, int newEf, int newF, Tile newTG, Tile newTC, int effect, int MaxRange, int direction, int codeDamage){
            if(tileEffect==lock_){
            switch(id){
                case 1: tileEffect=newEf; tileFadeEffect=newF; _PT.Gas.SetTile(tilePos+og,newTG); _PT.Charco.SetTile(tilePos+og,newTC); break;

                case 2: tileEffect=newEf; tileFadeEffect=FadeAround(newEf); _PT.Gas.SetTile(tilePos+og,newTG); _PT.Charco.SetTile(tilePos+og,newTC); break;

                case 3: tileEffect=newEf; tileFadeEffect=newF; if(bypass){_MM.SpreadEffectLimit(tilePos.x,tilePos.y,effect,0,MaxRange,direction,lock_);} _PT.Gas.SetTile(tilePos+og,newTG); _PT.Charco.SetTile(tilePos+og,newTC); break;
                
                case 4: tileEffect=newEf; tileFadeEffect=newF; if(bypass){_MM.SpreadEffectLimit(tilePos.x,tilePos.y,effect,0,MaxRange,direction,lock_);} _MM.Damage(codeDamage,tilePos.x,tilePos.y); _PT.Gas.SetTile(tilePos+og,newTG); _PT.Charco.SetTile(tilePos+og,newTC); break;

                case 5: tileEffect=newEf; tileFadeEffect=newF; _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,effect,direction,lock_); _PT.Gas.SetTile(tilePos+og,newTG); _PT.Charco.SetTile(tilePos+og,newTC); break;

                case 6: tileEffect=newEf; tileFadeEffect=FadeAround(newEf); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,effect,direction,lock_); _PT.Gas.SetTile(tilePos+og,newTG); _PT.Charco.SetTile(tilePos+og,newTC); break;

                case 7: tileEffect=newEf; tileFadeEffect=newF; _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,effect,direction,lock_); _MM.Damage(codeDamage,tilePos.x,tilePos.y); _PT.Gas.SetTile(tilePos+og,newTG); _PT.Charco.SetTile(tilePos+og,newTC); break;

                case 8: tileFadeEffect=FadeAround(newEf); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,effect,direction,lock_); _PT.Gas.SetTile(tilePos+og,newTG); _PT.Charco.SetTile(tilePos+og,newTC); break;
            }
            }
        }
        
        public bool canAddEffect(int effect){
        //Faltan implementar cambios de sprites y FadeEffects

        //Implmentar combinaciones del excel aqui
        switch(effect){ //0=None 1=Gas 2=Fire 3=Push 4=Ice 5=Elec //Especiales 6=Wet
            case 0:
                    if(tileEffect!=16){return true;}else{return false;}
            case 1:
                    if(tileEffect!=16 && tileEffect==0 || tileEffect==4 || tileEffect==5 || tileEffect==6 || tileEffect==7 ||
                    tileEffect==12 || tileEffect==13){
                    return true;}else{return false;}
            case 2:
                    if(tileEffect!=16 && tileEffect==1 || tileEffect==2 || tileEffect==3 || tileEffect==5 || tileEffect==6 || tileEffect==7 ||
                    tileEffect==8 || tileEffect==9 || tileEffect==10 || tileEffect==11|| tileEffect==14 || tileEffect==15){
                    return true;}else{return false;}
            case 3:
                    if(tileEffect!=16 && tileEffect==5 || tileEffect==9 || tileEffect==14){
                    return true;}else{return false;}
            case 4:
                    if(tileEffect!=16 && tileEffect==0 || tileEffect==1 || tileEffect==2 || tileEffect==3 || tileEffect==4 || tileEffect==6 || tileEffect==7 || tileEffect==11){
                    return true;}else{return false;}
            case 5:
                    if(tileEffect!=16 && tileEffect==1 || tileEffect==2 || tileEffect==3){
                    return true;}else{return false;}
            case 6: 
                    if(tileEffect!=16 && tileEffect==4 || tileEffect==6 || tileEffect==7 || tileEffect==12 || tileEffect==13){
                    return true;}else{return false;}
            }
        return false;
        }
        
        public bool TileIsSafe(){
            if(tileEffect==4 || tileEffect==6 || tileEffect==8 || tileEffect==10 || tileEffect==12|| tileEffect==13 || tileEffect==15){return false;}
            else{return true;}
        }
    }


