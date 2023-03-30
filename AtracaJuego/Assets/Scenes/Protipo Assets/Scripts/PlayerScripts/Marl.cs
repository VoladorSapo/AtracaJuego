using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marl : MonoBehaviour
{
    public GameObject GasPrefab;
    public GridController _GC;
    public int GasCooldown;
    public ScriptPlayerManager _SPM;
    [SerializeField] private bool AttackMode;

    void Awake(){
        AttackMode=false;
        GasCooldown=0;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && _SPM.currentPlayer==0){
            if(AttackMode){AttackMode=false; _GC.setAttackPos(transform.position, 1, true, true, false, 2, true);}
            else{AttackMode=true;  _GC.setAttackPos(transform.position, 1, true, true, false, 2, false);}
        }

        if(Input.GetMouseButtonDown(0) && GasCooldown==0 && _SPM.currentPlayer==0 && AttackMode){
            Vector3Int posMouse=_GC.GetMousePosition();
            if(!_GC.isEmpty(posMouse, false, 2)){
                Vector3Int posNew=new Vector3Int(Mathf.FloorToInt(transform.position.x),Mathf.FloorToInt(transform.position.y),0); //*10 por el tamaño de las tiles + offset de (10/2,10/2,0)=(5,5,0)
                Instantiate(GasPrefab, posNew, Quaternion.identity);
                //FireCooldown++;
                //_SPM.CanAttack[0]=false;
            }
        }
    }
}

