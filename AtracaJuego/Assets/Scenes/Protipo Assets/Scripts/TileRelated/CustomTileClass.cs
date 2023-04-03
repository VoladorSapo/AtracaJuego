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
    public GridController _GC;
    public int tileFadeEffect; //i: 0=gas, 1=mojado, 2=gasolina, 3=deadlygas, 4=fuego, 5=hielo, 6=electricwet, 7=electricgas, 8=iceSpiked


    public CustomTileClass(int SpriId, int state, int effect, Vector3Int pos, int fade){
        tilePos=pos;
        tileSpriteId=SpriId;
        tileState=state;
        tileEffect=effect;
        _MM=GameObject.Find("MapManager").GetComponent<MapManager>();
        _GC=GameObject.Find("Grid").GetComponent<GridController>();
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
        if(tileFadeEffect>0){
            tileFadeEffect--;
            if(tileFadeEffect==0){addEffect(0,false,0);}
        }
        
    }

    //public void SetPlayerOnTop(string player){
    //    Debug.Log("ass");
    //    playerOnTop=player;
    //}

    public void setPlayer(PlayerBase newplayer)
    {
        player = newplayer;
        if(tileState == 13)
        {
            Debug.Log("uo");
            player.pressWinTile();
        }
    }

    public void addEffect(int effect, bool bypass, int direction){
        //Faltan implementar cambios de sprites y FadeEffects

        //Implmentar combinaciones del excel aqui
        switch(effect){ //0=None 1=Gas 2=Fire 3=Push 4=Ice 5=Elec //Especiales 6=Wet
            case 0:
                    if(tileEffect!=16){tileEffect=0; tileFadeEffect=0;} break;
            case 1:
                    if(tileEffect!=16){
                    switch(tileEffect){
                        case 0: tileEffect=1;    tileFadeEffect=3; break;
                        case 2: tileEffect=1;    tileFadeEffect=3; break;
                        case 4: tileEffect=4;    tileFadeEffect=1;   _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2,direction); _MM.Damage(0,tilePos.x,tilePos.y); break;
                        case 5: tileEffect=3;    tileFadeEffect=3; break;
                        case 6: tileFadeEffect=FadeAround(6);   _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,5,direction); break;
                        case 7: tileFadeEffect=FadeAround(7);    _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,5,direction); break;
                        case 12: tileEffect=4;   tileFadeEffect=1;    _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2,direction); _MM.Damage(1,tilePos.x,tilePos.y); break;
                        case 13: tileEffect=4;   tileFadeEffect=1;    _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2,direction);  _MM.Damage(2,tilePos.x,tilePos.y); break;
                    }} break;
            case 2:
                    if(tileEffect!=16){
                    switch(tileEffect){
                        case 1: tileEffect=4; tileFadeEffect=1;  _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2,direction); _MM.Damage(0,tilePos.x,tilePos.y); break;
                        case 2: tileEffect=0; break;
                        case 3: tileEffect=12; tileFadeEffect=1;     _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2,direction); _MM.Damage(1,tilePos.x,tilePos.y); break; 
                        case 5: tileEffect=2; tileFadeEffect=3;  if(bypass){_MM.SpreadEffectLimit(tilePos.x,tilePos.y,2,0,5,0);} break;
                        case 6: tileEffect=0; break;
                        case 7: tileEffect=0; _MM.Damage(4,tilePos.x,tilePos.y); break; 
                        case 8: tileEffect=2; tileFadeEffect=3; break;
                        case 9: tileEffect=3; tileFadeEffect=3; break;
                        case 10: tileEffect=3; tileFadeEffect=3; break;
                        case 11: tileEffect=4; tileFadeEffect=1;     _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2,direction); _MM.Damage(2,tilePos.x,tilePos.y); break;
                        case 14: tileEffect=11; tileFadeEffect=3;    if(bypass){_MM.SpreadEffectLimit(tilePos.x,tilePos.y,2,0,5,0);} break;
                        case 15: tileEffect=11; tileFadeEffect=3;    if(bypass){_MM.SpreadEffectLimit(tilePos.x,tilePos.y,2,0,5,0);} break;
                    }} break;
            case 3:
                    if(tileEffect!=16){
                    switch(tileEffect){
                        case 5: tileEffect=8; tileFadeEffect++; if(bypass){_MM.SpreadEffectLimit(tilePos.x,tilePos.y,3,0,3,direction); _MM.Damage(3,tilePos.x,tilePos.y);} break;
                        case 9: tileEffect=10; tileFadeEffect++; if(bypass){_MM.SpreadEffectLimit(tilePos.x,tilePos.y,3,0,3,direction); _MM.Damage(3,tilePos.x,tilePos.y);} break;
                        case 14: tileEffect=15; tileFadeEffect++; if(bypass){_MM.SpreadEffectLimit(tilePos.x,tilePos.y,3,0,3,direction); _MM.Damage(3,tilePos.x,tilePos.y);} break;
                    }} break;
            case 4:
                    if(tileEffect!=16){
                    switch(tileEffect){
                        case 0: tileEffect=5; tileFadeEffect=5; break;
                        case 1: tileEffect=3; tileFadeEffect=3;break;
                        case 2: tileEffect=5; tileFadeEffect++; break;
                        case 3: tileEffect=9; tileFadeEffect=10000; break;
                        case 4: tileEffect=2; tileFadeEffect=3; break;
                        case 6: tileEffect=5; tileFadeEffect=5; break;
                        case 7: tileEffect=6; tileFadeEffect=3; break;
                        case 11: tileEffect=14; tileFadeEffect=10000; break;
                    }} break;
            case 5:
                    if(tileEffect!=16){
                    switch(tileEffect){
                        case 1: tileEffect=7; tileFadeEffect++; _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,5,direction); break;
                        case 2: tileEffect=6; tileFadeEffect=3; _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,5,direction);  _MM.Damage(4,tilePos.x,tilePos.y); break;
                        case 3: tileEffect=11; tileFadeEffect++; _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,5,direction); break;
                        //case 6: resetea el fade?
                        //case 7: resetea el fade?
                    }}break;
            case 6:
                    if(tileEffect!=16){
                    switch(tileEffect){
                        case 0: tileEffect=2; tileFadeEffect=3; break;
                        case 4: tileEffect=0; break;
                        case 6: tileEffect=6; tileFadeEffect=FadeAround(6);
                        _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,5,direction); break;
                        case 7: tileFadeEffect=3; tileFadeEffect=FadeAround(6);
                        _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,5,direction); break;
                        case 12: tileEffect=0; break;
                        case 13: tileEffect=0; break;
                    }}break;
            case 7:
                    if(tileEffect!=16){
                        switch(tileEffect){
                        case 0: tileEffect=7; tileFadeEffect=FadeAround(7); break;
                        case 1: tileEffect=7; tileFadeEffect=FadeAround(7); _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,5,direction); break;
                        case 2: _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,5,direction); break;
                        case 4: tileEffect=0; _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2,direction); _MM.Damage(1,tilePos.x,tilePos.y); break;
                        case 5: tileEffect=11; break;
                        case 12: tileEffect=0; _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2,direction); _MM.Damage(1,tilePos.x,tilePos.y); break; //Damage
                        case 13: tileEffect=0; _MM.SpreadEffectNoLimit(tilePos.x,tilePos.y,2,direction);  _MM.Damage(2,tilePos.x,tilePos.y); break; //Damage
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


