using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using System.Linq;
public class Ignacio : MonoBehaviour
{
    public GameObject FirePrefab;
    public GridController _GC;
    public int FireCooldown;
    public ScriptPlayerManager _SPM;
    [SerializeField] private bool AttackMode;
    void Awake(){
        AttackMode=false;
        FireCooldown=0;
    }

    void Start()
    {
        Vector3Int posGrid = _GC.grid.WorldToCell(transform.position);
       //_GC.tiles[posGrid.x-_GC.ogx, posGrid.y-_GC.ogy].setPlayer(this); //Hacer esto para inicializar
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            ChangeMapShown();
        }

        if(Input.GetMouseButtonDown(0) && FireCooldown==0 && _SPM.currentPlayer==0 && AttackMode){
            Vector3Int posMouse=_GC.GetMousePosition();
            if(!_GC.isEmpty(posMouse, false, 2)){
                Vector3Int posNew=posMouse*10+new Vector3Int(5,5,0); //*10 por el tamaño de las tiles + offset de (10/2,10/2,0)=(5,5,0)
                Instantiate(FirePrefab, posNew, Quaternion.identity);
                //FireCooldown++;
                //_SPM.CanAttack[0]=false;
            }
        }
    }

    private void ChangeMapShown(){
            if(AttackMode){AttackMode=false; _GC.setAttackPos(transform.position, 1, true, true, false, 1, true); _GC.setReachablePos(transform.position, 5, true,true,false,false);}
            else{AttackMode=true; _GC.setAttackPos(transform.position, 1, true, true, false, 1, false); _GC.setReachablePos(transform.position, 5, true,true,true,true);}
    }
    }
