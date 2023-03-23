using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushEffect : MonoBehaviour
{
    [SerializeField] private Vector3 posBL;
    [SerializeField] private float w;
    [SerializeField] private float h;
    public GridController _GC;
    public MapManager _MM;
    [SerializeField] private int distance=2; //Toma n-1 de tiles (Es decir, si quieres coger 5 tiles, pon distance=6)
    [SerializeField] private int distanceMoved=5; //Mueve n tiles

    public int direction; //1:Derecha 2:Izquierda 3:Arriba 4:Abajo

    // Start is called before the first frame update
    void Awake()
    {
        _GC=GameObject.Find("Grid").GetComponent<GridController>();
        _MM=GameObject.Find("MapManager").GetComponent<MapManager>();
        w=transform.localScale.x;
        h=transform.localScale.y;
        //el valor de direction lo ajusta al llamar al prefab
        //temporalmente lo implementare usando
        direction=1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("p")){
            posBL=new Vector3(transform.position.x-(w/2),transform.position.y-(h/2),0);
            Vector3Int tileO = Vector3Int.RoundToInt(posBL);
            bool hayGas=false;
            Vector3Int nextPos;
            int x=tileO.x-_GC.ogx;
            int y=tileO.y-_GC.ogy;
            int nextX, nextY;
            int actX, actY;
            CustomTileClass[] copy= new CustomTileClass[distance];
            switch(direction){
                case 1:     
                            /*if hay personaje... más simple de hacer*/
                            /*if hay objeto...*/
                            
                            for(int i=0; i<distance; i++){if(_GC.tiles[x+i,y].GetTileEffect()==1 || _GC.tiles[x+i,y].GetTileEffect()==10){hayGas=true;}}

                            if(hayGas){

                            for(int j=0; j<distanceMoved; j++){
                                
                            for(int i=0; i<distance; i++){

                                if( _GC.tiles[x+(distance-1-i)+1+j,y].GetTileState()<1){ //En realidad seria 8 pero falta adaptar el pathfinding a cada update
                                nextX=x+(distance-1-i)+1+j;
                                actX=x+(distance-1-i)+j;
                                nextPos= new Vector3Int (_GC.tiles[actX,y].tilePos.x+1, _GC.tiles[actX,y].tilePos.y, 0);
                                _GC.tiles[nextX,y]=Clone(_GC.tiles[actX,y].tileSpriteId,_GC.tiles[actX,y].tileState,_GC.tiles[actX,y].tileEffect, nextPos);
                                //SetTiles en el mapa superior de efectos

                                if(_GC.tiles[actX,y].GetTileEffect()==1){_GC.tiles[actX,y].SetTileEffect(0);} //Revisar estos
                                else if(_GC.tiles[actX,y].GetTileEffect()==10){_GC.tiles[actX,y].SetTileEffect(6);}
                                }else{
                                    //break; //paron en seco
                                    distanceMoved-=(distanceMoved-j); //colapso
                                }
                                
                            }
                                
                            /*IEnumerator que nos servirá para animar (tengo que mirarlo)*/
                            }

                            }
                            /*if hay personaje... más simple de hacer*/
                            /*if hay objeto...*/
                            distanceMoved=5;
                            break;

                case 2:     

                            /*if hay personaje... más simple de hacer*/
                            /*if hay objeto...*/

                            for(int i=0; i<distance; i++){if(_GC.tiles[x-i,y].GetTileEffect()==1 || _GC.tiles[x-i,y].GetTileEffect()==10){hayGas=true;}}

                            if(hayGas){

                            for(int j=0; j<distanceMoved; j++){
                                
                            for(int i=0; i>-distance; i--){

                                if( _GC.tiles[x-(distance+1+i)-1-j,y].GetTileState()<1){ //En realidad seria 8 pero falta adaptar el pathfinding a cada update
                                nextX=x-(distance+1+i)-1-j;
                                actX=x-(distance+1+i)-j;
                                nextPos= new Vector3Int (_GC.tiles[actX,y].tilePos.x-1, _GC.tiles[actX,y].tilePos.y, 0);
                                _GC.tiles[nextX,y]=Clone(_GC.tiles[actX,y].tileSpriteId,_GC.tiles[actX,y].tileState,_GC.tiles[actX,y].tileEffect, nextPos);
                                //SetTiles en el mapa superior de efectos

                                if(_GC.tiles[actX,y].GetTileEffect()==1){_GC.tiles[actX,y].SetTileEffect(0);} //Revisar estos
                                else if(_GC.tiles[actX,y].GetTileEffect()==10){_GC.tiles[actX,y].SetTileEffect(6);}
                                }else{
                                    //break; //paron en seco
                                    distanceMoved-=(distanceMoved-j); //colapso
                                }
                                
                            }

                            /*IEnumerator que nos servirá para animar (tengo que mirarlo)*/
                            }

                            }
                            
                            distanceMoved=5;
                            break;

                case 3:     

                            /*if hay personaje... más simple de hacer*/
                            /*if hay objeto...*/

                            for(int i=0; i<distance; i++){if(_GC.tiles[x,y+i].GetTileEffect()==1 || _GC.tiles[x,y+i].GetTileEffect()==10){hayGas=true;}}

                            if(hayGas){

                            for(int j=0; j<distanceMoved; j++){
                                
                            for(int i=0; i<distance; i++){

                                if( _GC.tiles[x,y+(distance-1-i)+1+j].GetTileState()<1){ //En realidad seria 8 pero falta adaptar el pathfinding a cada update
                                nextY=y+(distance-1-i)+1+j;
                                actY=y+(distance-1-i)+j;
                                nextPos= new Vector3Int (_GC.tiles[x,actY].tilePos.x, _GC.tiles[x,actY].tilePos.y+1, 0);
                                _GC.tiles[x,nextY]=Clone(_GC.tiles[x,actY].tileSpriteId,_GC.tiles[x,actY].tileState,_GC.tiles[x,actY].tileEffect, nextPos);
                                //SetTiles en el mapa superior de efectos

                                if(_GC.tiles[x,actY].GetTileEffect()==1){_GC.tiles[x,actY].SetTileEffect(0);} //Revisar estos
                                else if(_GC.tiles[x,actY].GetTileEffect()==10){_GC.tiles[x,actY].SetTileEffect(6);}
                                }else{
                                    //break; //paron en seco
                                    distanceMoved-=(distanceMoved-j); //colapso
                                }
                                
                            }
                                
                            /*IEnumerator que nos servirá para animar (tengo que mirarlo)*/
                            }

                            }
                            
                            distanceMoved=5;
                            break;
                case 4:     

                            /*if hay personaje... más simple de hacer*/
                            /*if hay objeto...*/

                            for(int i=0; i<distance; i++){if(_GC.tiles[x,y-i].GetTileEffect()==1 || _GC.tiles[x,y-i].GetTileEffect()==10){hayGas=true;}}

                            if(hayGas){

                            for(int j=0; j<distanceMoved; j++){
                                
                            for(int i=0; i>-distance; i--){

                                if( _GC.tiles[x,y-(distance+1+i)-1-j].GetTileState()<1){ //En realidad seria 8 pero falta adaptar el pathfinding a cada update
                                nextY=y-(distance+1+i)-1-j;
                                actY=y-(distance+1+i)-j;
                                nextPos= new Vector3Int (_GC.tiles[x,actY].tilePos.x, _GC.tiles[x,actY].tilePos.y-1, 0);
                                _GC.tiles[x,nextY]=Clone(_GC.tiles[x,actY].tileSpriteId,_GC.tiles[x,actY].tileState,_GC.tiles[x,actY].tileEffect, nextPos);
                                //SetTiles en el mapa superior de efectos

                                if(_GC.tiles[x,actY].GetTileEffect()==1){_GC.tiles[x,actY].SetTileEffect(0);} //Revisar estos
                                else if(_GC.tiles[x,actY].GetTileEffect()==10){_GC.tiles[x,actY].SetTileEffect(6);}
                                }else{
                                    //break; //paron en seco
                                    distanceMoved-=(distanceMoved-j); //colapso
                                }
                                
                            }
                                
                            /*IEnumerator que nos servirá para animar (tengo que mirarlo)*/
                            }

                            }
                            
                            distanceMoved=5;
                            break;
            }
        }
    }
    

    private CustomTileClass Clone(int sprite, int state, int effect, Vector3Int pos){
        CustomTileClass n = new CustomTileClass(sprite, state, effect, pos);
        return n;
    }
}