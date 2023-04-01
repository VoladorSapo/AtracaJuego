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

    public GameObject IcePrefab;
    [SerializeField] private int distance=5; //Toma n-1 de tiles (Es decir, si quieres coger 5 tiles, pon distance=6)
    [SerializeField] private int distanceMoved=5; //Mueve n tiles
    [SerializeField] private int distancePush=10;
    private int auxDist;
    public int direction; //1:Derecha 2:Izquierda 3:Arriba 4:Abajo

    // Start is called before the first frame update
    void Awake()
    {
        _GC=GameObject.Find("Grid").GetComponent<GridController>();
        _MM=GameObject.Find("MapManager").GetComponent<MapManager>();
        w=transform.localScale.x;
        h=transform.localScale.y;
        auxDist=distance;
    }

    // Update is called once per frame
    void Start()
    {
        
            Vector3Int tileO = _GC.grid.WorldToCell(transform.position);
            bool hayGas=false;
            int x=tileO.x-_GC.ogx;
            int y=tileO.y-_GC.ogy;

            int dist1=0, dist0=0, dist_=0;
            switch(direction){
                case 1:     
                            
                            for(int k=1; k>=-1; k--){
                            for(int i=0; i<distance; i++){
                                if(_GC.tiles[x+i,y+k].GetTileState()<8){
                                if(_GC.tiles[x+i,y+k].GetTileEffect()==1 || _GC.tiles[x+i,y+k].GetTileEffect()==10){
                                    switch(k){
                                        case 1: dist1++; break;
                                        case 0: dist0++; break;
                                        case -1: dist_++; break;
                                    } 
                                hayGas=true;}
                                }else{break;}
                            }}

                            print(dist1+";"+dist0+";"+dist_);

                            if(hayGas){
                                StartCoroutine(PushGas(0.25f,dist1,dist0,dist_,x,y,1));
                            }

                            if(_GC.tiles[x,y].GetPlayer()!=null){
                                StartCoroutine(PushPlayerWait(x,y,0.25f,distancePush,1));
                            }

                            
                            _GC.tiles[x,y].addEffect(3,true,1);
                            
                            /*if hay objeto...*/
                            distance=auxDist;
                            break;

                case 2:     

                            /*if hay personaje... más simple de hacer*/
                            /*if hay objeto...*/
                            
                            for(int k=1; k>=-1; k--){
                            for(int i=0; i<distance; i++){
                                if(_GC.tiles[x-i,y+k].GetTileState()<8){
                                if(_GC.tiles[x-i,y+k].GetTileEffect()==1 || _GC.tiles[x-i,y+k].GetTileEffect()==10){
                                    switch(k){
                                        case 1: dist1++; break;
                                        case 0: dist0++; break;
                                        case -1: dist_++; break;
                                    } 
                                hayGas=true;}
                                }else{break;}
                            }}

                            print(dist1+";"+dist0+";"+dist_);
                            if(hayGas){
                                StartCoroutine(PushGas(0.25f,dist1,dist0,dist_,x,y,2));
                            }

                            if(_GC.tiles[x,y].GetPlayer()!=null){
                                StartCoroutine(PushPlayerWait(x,y,0.25f,distancePush,2));
                            }
                            distance=auxDist;
                            break;

                case 3:     

                            for(int k=1; k>=-1; k--){
                            for(int i=0; i<distance; i++){
                                if(_GC.tiles[x+k,y+i].GetTileState()<8){
                                if(_GC.tiles[x+k,y+i].GetTileEffect()==1 || _GC.tiles[x+k,y+i].GetTileEffect()==10){
                                    switch(k){
                                        case 1: dist1++; break;
                                        case 0: dist0++; break;
                                        case -1: dist_++; break;
                                    } 
                                hayGas=true;}
                                }else{break;}
                            }}

                            print(dist1+";"+dist0+";"+dist_);
                            if(hayGas){
                                StartCoroutine(PushGas(0.25f,dist1,dist0,dist_,x,y,3));
                            }
                            
                            if(_GC.tiles[x,y].GetPlayer()!=null){
                                StartCoroutine(PushPlayerWait(x,y,0.25f,distancePush,3));
                            }
                            distance=auxDist;
                            break;
                case 4:
                            for(int k=1; k>=-1; k--){
                            for(int i=0; i<distance; i++){
                                if(_GC.tiles[x+k,y-i].GetTileState()<8){
                                if(_GC.tiles[x+k,y-i].GetTileEffect()==1 || _GC.tiles[x+k,y-i].GetTileEffect()==10){
                                    switch(k){
                                        case 1: dist1++; break;
                                        case 0: dist0++; break;
                                        case -1: dist_++; break;
                                    } 
                                hayGas=true;}
                                }else{break;}
                            }}

                            print(dist1+";"+dist0+";"+dist_);
                            if(hayGas){
                                StartCoroutine(PushGas(0.25f,dist1,dist0,dist_,x,y,4));
                            }
                            
                            if(_GC.tiles[x,y].GetPlayer()!=null){
                                        StartCoroutine(PushPlayerWait(x,y,0.25f,distancePush,4));
                            }
                            break;


            }

            StartCoroutine(DestroyEffect(2)); //Destruye el prefab en 2 (de momento) segs tras la animacion
    }

    IEnumerator PushPlayerWait(int x,int y,float sec, int distancePush, int dir){
        WaitForSeconds wfs=new WaitForSeconds(sec);
        
        Transform oldPosPlayer=_GC.tiles[x,y].GetPlayer().GetComponent<Transform>();

        switch(dir){
        case 1:
        for(int i=0; i<distancePush; i++){
            if(_GC.tiles[x+i+1,y].GetTileState()<5){
                oldPosPlayer.position += (new Vector3(10,0,0));
            }else{
                break;
            }
        yield return wfs;
        } break;

        case 2:
        for(int i=0; i<distancePush; i++){
            if(_GC.tiles[x-i-1,y].GetTileState()<5){
                oldPosPlayer.position -= (new Vector3(10,0,0));
            }else{
                break;
            }
        yield return wfs;
        
        } break;

        case 3:
        for(int i=0; i<distancePush; i++){
            if(_GC.tiles[x,y+i+1].GetTileState()<5){
                oldPosPlayer.position += (new Vector3(0,10,0));
            }else{
                break;
            }
        yield return wfs;
        } break;
        case 4:
        for(int i=0; i<distancePush; i++){
            if(_GC.tiles[x,y-i-1].GetTileState()<5){
                oldPosPlayer.position -= (new Vector3(0,10,0));
            }else{
                break;
            }
        yield return wfs;
        } break;
        }
    }

    IEnumerator PushGas(float sec,int dist1,int dist0,int dist_,int x,int y, int dir){
        WaitForSeconds wfs=new WaitForSeconds(sec);
        switch(dir){
        case 1:
                            for(int j=0; j<distanceMoved; j++){
                            
                            
                            if(j<=dist1 && _GC.tiles[x+(dist1-1)+j+1,y+1].GetTileState()<8){
                                switch(_GC.tiles[x+(dist1-1)+j,y+1].GetTileEffect()){
                                    case 1:
                                    _GC.tiles[x+(dist1-1)+j+1,y+1].addEffect(1,false,0); break;
                                    case 7:
                                    _GC.tiles[x+(dist1-1)+j+1,y+1].addEffect(7,false,0); break;
                                }
                            }
                            if(j<=dist1 && _GC.tiles[x+1+j,y+1].GetTileState()<8){
                                switch(_GC.tiles[x+1+j,y+1].GetTileEffect()){
                                case 1:
                                _GC.tiles[x+1+j,y+1].addEffect(1,false,0);
                                _GC.tiles[x+j,y+1].addEffect(0,false,0); break;
                                case 7:
                                _GC.tiles[x+1+j,y+1].addEffect(7,false,0);
                                _GC.tiles[x+j,y+1].addEffect(0,false,0); break;
                                }
                            }
                            
                            
                            if(j<=dist0 && _GC.tiles[x+(dist0-1)+j+1,y].GetTileState()<8){
                                switch(_GC.tiles[x+(dist0-1)+j,y].GetTileEffect()){
                                    case 1:
                                    _GC.tiles[x+(dist0-1)+j+1,y].addEffect(1,false,0); break;
                                    case 7:
                                    _GC.tiles[x+(dist0-1)+j+1,y].addEffect(7,false,0); break;
                                }
                            }
                            if(j<=dist0 && _GC.tiles[x+1+j,y].GetTileState()<8){
                                switch(_GC.tiles[x+1+j,y].GetTileEffect()){
                                case 1:
                                _GC.tiles[x+1+j,y].addEffect(1,false,0);
                                _GC.tiles[x+j,y].addEffect(0,false,0); break;
                                case 7:
                                _GC.tiles[x+1+j,y].addEffect(7,false,0);
                                _GC.tiles[x+j,y].addEffect(0,false,0); break;
                                }
                            }

                            if(j<=dist_ && _GC.tiles[x+(dist_-1)+j+1,y-1].GetTileState()<8){
                                switch(_GC.tiles[x+(dist_-1)+j,y-1].GetTileEffect()){
                                    case 1:
                                    _GC.tiles[x+(dist_-1)+j+1,y-1].addEffect(1,false,0); break;
                                    case 7:
                                    _GC.tiles[x+(dist_-1)+j+1,y-1].addEffect(7,false,0); break;
                                }
                            }
                            if(j<=dist_ && _GC.tiles[x+1+j,y-1].GetTileState()<8){
                                switch(_GC.tiles[x+1+j,y-1].GetTileEffect()){
                                case 1:
                                _GC.tiles[x+1+j,y-1].addEffect(1,false,0);
                                _GC.tiles[x+j,y-1].addEffect(0,false,0); break;
                                case 7:
                                _GC.tiles[x+1+j,y-1].addEffect(7,false,0);
                                _GC.tiles[x+j,y-1].addEffect(0,false,0); break;
                                }
                            }
                            

                            yield return wfs;   
                            }
                            break;
        case 2:
                            for(int j=0; j<distanceMoved; j++){
                            if(j<=dist1 && _GC.tiles[x-(dist1-1)-1-j,y+1].GetTileState()<8){
                                switch(_GC.tiles[x-(dist1-1)-j,y+1].GetTileEffect()){
                                    case 1:
                                    _GC.tiles[x-(dist1-1)-1-j,y+1].addEffect(1,false,0); break;
                                    case 7:
                                    _GC.tiles[x-(dist1-1)-1-j,y+1].addEffect(7,false,0); break;
                                }
                            }
                            if(j<=dist1 && _GC.tiles[x-1-j,y+1].GetTileState()<8){
                                switch(_GC.tiles[x-1-j,y+1].GetTileEffect()){
                                case 1:
                                _GC.tiles[x-1-j,y+1].addEffect(1,false,0);
                                _GC.tiles[x-j,y+1].addEffect(0,false,0); break;
                                case 7:
                                _GC.tiles[x-1-j,y+1].addEffect(7,false,0);
                                _GC.tiles[x-j,y+1].addEffect(0,false,0); break;
                                }
                            }
                            
                            
                            if(j<=dist0 && _GC.tiles[x-(dist0-1)-j-1,y].GetTileState()<8){
                                switch(_GC.tiles[x-(dist0-1)-j,y].GetTileEffect()){
                                    case 1:
                                    _GC.tiles[x-(dist0-1)-j-1,y].addEffect(1,false,0); break;
                                    case 7:
                                    _GC.tiles[x-(dist0-1)-j-1,y].addEffect(7,false,0); break;
                                }
                            }
                            if(j<=dist0 && _GC.tiles[x-1-j,y].GetTileState()<8){
                                switch(_GC.tiles[x-1-j,y].GetTileEffect()){
                                case 1:
                                _GC.tiles[x-1-j,y].addEffect(1,false,0);
                                _GC.tiles[x-j,y].addEffect(0,false,0); break;
                                case 7:
                                _GC.tiles[x-1-j,y].addEffect(7,false,0);
                                _GC.tiles[x-j,y].addEffect(0,false,0); break;
                                }
                            }

                            if(j<=dist_ && _GC.tiles[x-(dist_-1)-j-1,y-1].GetTileState()<8){
                                switch(_GC.tiles[x-(dist_-1)-j,y-1].GetTileEffect()){
                                    case 1:
                                    _GC.tiles[x-(dist_-1)-j-1,y-1].addEffect(1,false,0); break;
                                    case 7:
                                    _GC.tiles[x-(dist_-1)-j-1,y-1].addEffect(7,false,0); break;
                                }
                            }
                            if(j<=dist_ && _GC.tiles[x-1-j,y-1].GetTileState()<8){
                                switch(_GC.tiles[x-1-j,y-1].GetTileEffect()){
                                case 1:
                                _GC.tiles[x-1-j,y-1].addEffect(1,false,0);
                                _GC.tiles[x-j,y-1].addEffect(0,false,0); break;
                                case 7:
                                _GC.tiles[x-1-j,y-1].addEffect(7,false,0);
                                _GC.tiles[x-j,y-1].addEffect(0,false,0); break;
                                }
                            }
                            
                            yield return wfs; 
                            }
        
                            break;
        case 3:             
                            for(int j=0; j<distanceMoved; j++){
                            
                            if(j<=dist1 && _GC.tiles[x+1,y+(dist1-1)+j+1].GetTileState()<8){
                                switch(_GC.tiles[x+1,y+(dist1-1)+j].GetTileEffect()){
                                    case 1:
                                    _GC.tiles[x+1,y+(dist1-1)+j+1].addEffect(1,false,0); break;
                                    case 7:
                                    _GC.tiles[x+1,y+(dist1-1)+j+1].addEffect(7,false,0); break;
                                }
                            }
                            if(j<=dist1 && _GC.tiles[x+1,y+1+j].GetTileState()<8){
                                switch(_GC.tiles[x+1,y+1+j].GetTileEffect()){
                                case 1:
                                _GC.tiles[x+1,y+1+j].addEffect(1,false,0);
                                _GC.tiles[x+1,y+j].addEffect(0,false,0); break;
                                case 7:
                                _GC.tiles[x+1,y+1+j].addEffect(7,false,0);
                                _GC.tiles[x+1,y+j].addEffect(0,false,0); break;
                                }
                            }
                            
                            
                            if(j<=dist0 && _GC.tiles[x,y+(dist0-1)+j+1].GetTileState()<8){
                                switch(_GC.tiles[x,y+(dist0-1)+j].GetTileEffect()){
                                    case 1:
                                    _GC.tiles[x,y+(dist0-1)+j+1].addEffect(1,false,0); break;
                                    case 7:
                                    _GC.tiles[x,y+(dist0-1)+j+1].addEffect(7,false,0); break;
                                }
                            }
                            if(j<=dist0 && _GC.tiles[x,y+1+j].GetTileState()<8){
                                switch(_GC.tiles[x,y+1+j].GetTileEffect()){
                                case 1:
                                _GC.tiles[x,y+1+j].addEffect(1,false,0);
                                _GC.tiles[x,y+j].addEffect(0,false,0); break;
                                case 7:
                                _GC.tiles[x,y+1+j].addEffect(7,false,0);
                                _GC.tiles[x,y+j].addEffect(0,false,0); break;
                                }
                            }

                            if(j<=dist_ && _GC.tiles[x-1,y+(dist_-1)+j+1].GetTileState()<8){
                                switch(_GC.tiles[x-1,y+(dist_-1)+j].GetTileEffect()){
                                    case 1:
                                    _GC.tiles[x-1,y+(dist_-1)+j+1].addEffect(1,false,0); break;
                                    case 7:
                                    _GC.tiles[x-1,y+(dist_-1)+j+1].addEffect(7,false,0); break;
                                }
                            }
                            if(j<=dist_ && _GC.tiles[x-1,y+1+j].GetTileState()<8){
                                switch(_GC.tiles[x-1,y+1+j].GetTileEffect()){
                                case 1:
                                _GC.tiles[x-1,y+1+j].addEffect(1,false,0);
                                _GC.tiles[x-1,y+j].addEffect(0,false,0); break;
                                case 7:
                                _GC.tiles[x-1,y+1+j].addEffect(7,false,0);
                                _GC.tiles[x-1,y+j].addEffect(0,false,0); break;
                                }
                            }

                            yield return wfs;
                            }
                            break;
        case 4:             
                            for(int j=0; j<distanceMoved; j++){
                            
                            if(j<=dist1 && _GC.tiles[x+1,y-(dist1-1)-1-j].GetTileState()<8){
                                switch(_GC.tiles[x+1,y-(dist1-1)-j].GetTileEffect()){
                                    case 1:
                                    _GC.tiles[x+1,y-(dist1-1)-1-j].addEffect(1,false,0); break;
                                    case 7:
                                    _GC.tiles[x+1,y-(dist1-1)-1-j].addEffect(7,false,0); break;
                                }
                            }
                            if(j<=dist1 && _GC.tiles[x+1,y-1-j].GetTileState()<8){
                                switch(_GC.tiles[x+1,y-1-j].GetTileEffect()){
                                case 1:
                                _GC.tiles[x+1,y-1-j].addEffect(1,false,0);
                                _GC.tiles[x+1,y-j].addEffect(0,false,0); break;
                                case 7:
                                _GC.tiles[x+1,y-1-j].addEffect(7,false,0);
                                _GC.tiles[x+1,y-j].addEffect(0,false,0); break;
                                }
                            }
                            
                            
                            if(j<=dist0 && _GC.tiles[x,y-(dist0-1)-j-1].GetTileState()<8){
                                switch(_GC.tiles[x,y-(dist0-1)-j].GetTileEffect()){
                                    case 1:
                                    _GC.tiles[x,y-(dist0-1)-j-1].addEffect(1,false,0); break;
                                    case 7:
                                    _GC.tiles[x,y-(dist0-1)-j-1].addEffect(7,false,0); break;
                                }
                            }
                            if(j<=dist0 && _GC.tiles[x,y-1-j].GetTileState()<8){
                                switch(_GC.tiles[x,y-1-j].GetTileEffect()){
                                case 1:
                                _GC.tiles[x,y-1-j].addEffect(1,false,0);
                                _GC.tiles[x,y-j].addEffect(0,false,0); break;
                                case 7:
                                _GC.tiles[x,y-1-j].addEffect(7,false,0);
                                _GC.tiles[x,y-j].addEffect(0,false,0); break;
                                }
                            }

                            if(j<=dist_ && _GC.tiles[x-1,y-(dist_-1)-j-1].GetTileState()<8){
                                switch(_GC.tiles[x-1,y-(dist_-1)-j].GetTileEffect()){
                                    case 1:
                                    _GC.tiles[x-1,y-(dist_-1)-j-1].addEffect(1,false,0); break;
                                    case 7:
                                    _GC.tiles[x-1,y-(dist_-1)-j-1].addEffect(7,false,0); break;
                                }
                            }
                            if(j<=dist_ && _GC.tiles[x-1,y-1-j].GetTileState()<8){
                                switch(_GC.tiles[x-1,y-1-j].GetTileEffect()){
                                case 1:
                                _GC.tiles[x-1,y-1-j].addEffect(1,false,0);
                                _GC.tiles[x-1,y-j].addEffect(0,false,0); break;
                                case 7:
                                _GC.tiles[x-1,y-1-j].addEffect(7,false,0);
                                _GC.tiles[x-1,y-j].addEffect(0,false,0); break;
                                }
                            }

                                yield return wfs;
                            }
                            break;
        }
    }
    private void PushGas(){

    }
    IEnumerator DestroyEffect(float sec){
        WaitForSeconds wfs=new WaitForSeconds(sec);
        yield return wfs;
        Destroy(this.gameObject);
    }

    private CustomTileClass Clone(int sprite, int state, int effect, Vector3Int pos, int fade){
        CustomTileClass n = new CustomTileClass(sprite, state, effect, pos, fade);
        return n;
    }
}