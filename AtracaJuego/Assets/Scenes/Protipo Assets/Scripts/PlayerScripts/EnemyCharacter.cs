using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : PlayerBase
{
    [SerializeField] protected MapManager _MM;
    [SerializeField] protected PlayerBase Objetivo; //El personaje al que quiere pegar
    [SerializeField] protected ScriptPlayerManager protas; //El SPM de los protas para poder acceder a sus posiciones
    [SerializeField] protected int detectDistance;
    [SerializeField] protected bool activated;
    [SerializeField] protected bool throughTeam;
    protected Vector3Int hit;
    public int codeDamage;

    protected Vector3Int objective; //La casilla en la que quieres llegar
    protected override void Awake()
    {
        base.Awake();
        SPM = GameObject.Find("EnemyController").GetComponent<ScriptPlayerManager>();
        _MM = GameObject.Find("MapManager").GetComponent<MapManager>();
        protas = GameObject.Find("Controller").GetComponent<ScriptPlayerManager>();


    }
    public override void setGame()
    {
        base.setGame();
        activated = false;
    }
    private void OnMouseOver()
    {
        if (GC.tiles[0, 0] != null)
        {
            GC.setReachablePos(transform.position, MaxDistance, true, 2, team, false,throughTeam);
        }
    }
    private void OnMouseExit()
    {
        GC.setReachablePos(transform.position, MaxDistance, true, 2, team, true, throughTeam);
    }
    public override void startTurn()
    {
        GC.setReachablePos(transform.position, MaxDistance, true, 0, team, false, throughTeam);
        print("hei");
        int i = 0;
        bool poswalkable;
        Vector3 pos;
        do
        {
            pos = new Vector3(Random.Range(GC.ogx, GC.tiles.GetLength(0) + GC.ogx), Random.Range(GC.ogy, GC.tiles.GetLength(1) + GC.ogy));

            poswalkable = GC.isEmpty(pos, true, 1);


            i++;
        } while (!poswalkable && i < 200000);
        Move(pos);
    }

}
