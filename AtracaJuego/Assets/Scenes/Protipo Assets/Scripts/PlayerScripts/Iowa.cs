using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iowa : MonoBehaviour
{
    
    public GameObject PushPrefab;
    public GridController _GC;
    private Vector3 posBase;
    public int PushCooldown;
    public ScriptPlayerManager _SPM;
    private int x,y;
    [SerializeField] private bool AttackMode;
    void Awake(){
        AttackMode=false;
        PushCooldown=0;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3Int tileO = _GC.grid.WorldToCell(transform.position);

        x=tileO.x-_GC.ogx;
        y=tileO.y-_GC.ogy;

        if(Input.GetMouseButtonDown(1) && _SPM.currentPlayer==0){
            if(AttackMode){AttackMode=false; _GC.setAttackPos(transform.position, 1, true, true, false, 1, true);}
            else{AttackMode=true;  _GC.setAttackPos(transform.position, 1, true, true, false, 1, false);}
        }

        if(Input.GetMouseButtonDown(0) && PushCooldown==0 && _SPM.currentPlayer==0 && AttackMode){
            Vector3Int posMouse=_GC.GetMousePosition();
            if(!_GC.isEmpty(posMouse, false, 2)){
                Vector3Int posNew=posMouse*10+new Vector3Int(5,5,0); //*10 por el tamaño de las tiles + offset de (10/2,10/2,0)=(5,5,0)

                Vector3 directionVec=posMouse-_GC.grid.WorldToCell(transform.position);
                int x=(int) directionVec.x;
                int y=(int) directionVec.y;
                Vector2 dir=new Vector2(x,y);
                if(Mathf.Abs(x)!=Mathf.Abs(y)){ //A los lados
                    switch(Mathf.Abs(x)){
                        case 0: if(y==1){   PushPrefab.GetComponent<PushEffect>().direction = 3;
                                            Instantiate(PushPrefab, posNew, Quaternion.identity);}
                                else{       PushPrefab.GetComponent<PushEffect>().direction = 4;
                                            Instantiate(PushPrefab, posNew, Quaternion.identity);
                                } break;
                        case 1: if(x==1){   PushPrefab.GetComponent<PushEffect>().direction = 1;
                                            Instantiate(PushPrefab, posNew, Quaternion.identity);}
                                else{       PushPrefab.GetComponent<PushEffect>().direction = 2;
                                            Instantiate(PushPrefab, posNew, Quaternion.identity);
                                }break;
                    }
                }
                //else{} Las diagonales

                //Instantiate(PushPrefab, posNew, Quaternion.identity);
                //PushCooldown++;
                //_SPM.CanAttack[0]=false;
            }
        }
        }
        
    }


