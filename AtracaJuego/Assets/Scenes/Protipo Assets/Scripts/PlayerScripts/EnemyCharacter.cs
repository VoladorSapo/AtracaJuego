using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : PlayerBase
{
    [SerializeField] protected MapManager _MM;
    [SerializeField] protected PlayerBase Objetivo; //El personaje al que quiere pegar
        [SerializeField] protected ScriptPlayerManager protas; //El SPM de los protas para poder acceder a sus posiciones
    protected Vector3Int objective; //La casilla en la que quieres llegar
    protected override void Awake()
    {
        base.Awake();
        SPM = GameObject.Find("EnemyController").GetComponent<ScriptPlayerManager>();
        _MM = GameObject.Find("MapManager").GetComponent<MapManager>();
        protas = GameObject.Find("Controller").GetComponent<ScriptPlayerManager>();


    }
    public override void startTurn()
    {
        GC.setReachablePos(transform.position, MaxDistance, true, false,team,false);
        print("hei");
        int i = 0;
        bool poswalkable;
        Vector3 pos;
        do
        {
            pos = new Vector3( Random.Range(GC.ogx, GC.tiles.GetLength(0)+GC.ogx), Random.Range(GC.ogy, GC.tiles.GetLength(1)+GC.ogy));
            
            poswalkable = GC.isEmpty(pos,true,1);
            

            i++;
        } while (!poswalkable && i < 200000);
       Move(pos);
    }

}
