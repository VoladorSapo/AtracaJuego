using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaTest : ObjectStuff
{
    [SerializeField] private Sprite[] OpenClosed;
    private SpriteRenderer spriteState;
    private bool isOpen;
    private bool startDone=false;
    [SerializeField] private Transform posSprite;
    protected override void Start(){
        base.Start();
        GC=GameObject.Find("Grid").GetComponent<GridController>();
        isOpen=false;
        spriteState=GetComponentInChildren<SpriteRenderer>();
        posSprite=transform.GetChild(0);
    }

    public override void StartObject(){
        posSprite.position+=new Vector3(0,10,0);
        Close();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if(Input.GetKeyDown("q")){
            if(!isOpen){Open();}else{Close();}
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

