using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iowa : PlayablePlayer
{
    
    public GameObject PushPrefab;
    private int x,y;

    // Update is called once per frame
    public override void Update()
    {   

        base.Update();
        Vector3Int tileO = GC.grid.WorldToCell(transform.position);
        x=tileO.x-GC.ogx;
        y=tileO.y-GC.ogy;
        if(Input.GetMouseButtonDown(0) && Cooldown==0 && SPM.currentPlayer==teamNumb && Mode == 2)
        {
            Vector3Int posMouse=GC.GetMousePosition();
            if(!GC.isEmpty(posMouse, false, 2)){
                Vector3Int posNew=posMouse*10+new Vector3Int(5,5,0); //*10 por el tamaño de las tiles + offset de (10/2,10/2,0)=(5,5,0)

                Vector3 directionVec=posMouse-GC.grid.WorldToCell(transform.position);
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
                hasAttack = true;
                if (hasMove)
                {
                   // SPM.endTurn(teamNumb, false);
                }
                else
                {
                    ChangeMapShown(1);
                }
                //else{} Las diagonales

                //Instantiate(PushPrefab, posNew, Quaternion.identity);
                //PushCooldown++;
                //_SPM.CanAttack[0]=false;
            }
        }
        }

        protected override void ChangeMapShown(int setMode){
        Mode = setMode;
        if (Mode == 1)
        {
            print("move");
            GC.setAttackPos(transform.position, 1, true, true, false, 1, true);
            GC.setReachablePos(transform.position, SPM.MaxDistancePlayers[teamNumb], true, true, false, false);
        }
        else if (Mode == 2) { GC.setAttackPos(transform.position, 1, true, true, false, 1, false); GC.setReachablePos(transform.position, SPM.MaxDistancePlayers[teamNumb], true, true, true, true); }
        else
        {
            GC.setAttackPos(transform.position, 1, true, true, false, 1, true); GC.setReachablePos(transform.position, SPM.MaxDistancePlayers[teamNumb], true, true, true, true);
        }
    }
        
    }


