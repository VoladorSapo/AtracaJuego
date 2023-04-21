using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaTest : ObjectStuff
{   
    [SerializeField] private Vector2Int[] Posiciones;
    private bool Activate;
    private bool Activated;
    private int n=0;
    [SerializeField] private int[] activoPor;

    [SerializeField] private Sprite[] OpenClosed;
    private SpriteRenderer spriteState;
    private bool isOpen;
    private bool startDone=false;
    [SerializeField] int ActivateMode;
    [SerializeField] private Transform posSprite;

    protected override void Start(){
        base.Start();
        GC=GameObject.Find("Grid").GetComponent<GridController>();
        isOpen=false;
        spriteState=GetComponentInChildren<SpriteRenderer>();
        posSprite=transform.GetChild(0);
        Activate=false;
        Activated=false;
        activoPor=new int[Posiciones.Length];
    }

    public override void StartObject(){
        posSprite.position+=new Vector3(0,10,0);
        Close();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if(GC.tiles[0,0]!=null){
        switch(ActivateMode){
            case 1: PorPlaca(); break;
            case 2: PorPanel(); break;
        }
        }
    }

    private void PorPlaca(){
        n=0;
        for(int i=0; i<Posiciones.Length; i++){
            if(GC.tiles[Posiciones[i].x, Posiciones[i].y].GetTileState()==2){n++;}
        }
        if(n==Posiciones.Length){Activate=true;}

        if(Activate && !Activated){
            Open();
            Activated=true;
        }
    }
    public void ResetPanel(int x, int y){
        for(int i=0; i<Posiciones.Length; i++){
            if(Posiciones[i].x==x && Posiciones[i].y==y){activoPor[i]=3;}
        }
    }
    private void PorPanel(){
        n=0;
        for(int i=0; i<Posiciones.Length; i++){
            if(GC.tiles[Posiciones[i].x, Posiciones[i].y].GetTileState()==7){n++; if(activoPor[i]<=0){activoPor[i]=3;}}
        }
        if(n==Posiciones.Length){Activate=true;}

        if(Activate && !Activated){
            Open();
            Activated=true;
        }

        if(!Activate && Activated){
            Close();
            Activated=false;
        }
    }
    public override void startTurn()
    {
            for(int i=0; i<Posiciones.Length; i++){
            if(GC.tiles[Posiciones[i].x, Posiciones[i].y].GetTileState()==7){if(activoPor[i]>0){activoPor[i]--;}
            if(activoPor[i]==0){activoPor[i]=-1; GC.tiles[Posiciones[i].x, Posiciones[i].y].SetTileState(6);
            PT.Ground.SetTile(new Vector3Int(Posiciones[i].x+GC.ogx,Posiciones[i].y+GC.ogy,0),PT.tilesPlacasPalancas[4]);
            Activate=false;}}
            }
    }


    public void Open(){
        SoundManager.InstanceSound.PlaySound(SoundManager.InstanceSound._doors,SoundGallery.InstanceClip.audioClips[6]);
        Vector3Int posBL=GC.grid.WorldToCell(transform.position)-new Vector3Int(1,1,0);

        for(int i=0; i<=2; i++){
            for(int j=0; j<=2; j++){
                GC.tiles[posBL.x+i - GC.ogx,posBL.y+j - GC.ogy].addEffect(0,true,0,-1);
                GC.tiles[posBL.x+i - GC.ogx,posBL.y+j - GC.ogy].SetTileStats(0,0,0,0);
            }
        }
        posSprite.position+=new Vector3(0,10,0);
        spriteState.sprite=OpenClosed[1];
        spriteState.sortingLayerName="Top";
        isOpen=true;
    }

    public void Close(){
        if(startDone){SoundManager.InstanceSound.PlaySound(SoundManager.InstanceSound._doors,SoundGallery.InstanceClip.audioClips[7]);}
        Vector3Int posBL=GC.grid.WorldToCell(transform.position)-new Vector3Int(1,1,0);
        
        for(int i=0; i<=2; i++){
            for(int j=0; j<=2; j++){
                GC.tiles[posBL.x+i - GC.ogx,posBL.y+j - GC.ogy].addEffect(0,true,0,-1);
                GC.tiles[posBL.x+i - GC.ogx,posBL.y+j - GC.ogy].SetTileStats(0,8,16,0);
            }
        }
        
        posSprite.position-=new Vector3(0,10,0);
        spriteState.sprite=OpenClosed[0];
        spriteState.sortingLayerName="Ground";
        isOpen=false;
        startDone=true;
    }
}

