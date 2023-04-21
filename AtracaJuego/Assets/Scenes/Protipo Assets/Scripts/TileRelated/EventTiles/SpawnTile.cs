using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : EventTile
{
    [SerializeField] EnemyCharacter[] SpawnList;
    [SerializeField] int code;
    [SerializeField] ScriptPlayerManager _SPM;
    [SerializeField] EventTileList eventlist;
    public override void SetGame()
    {
        eventlist = GetComponentInParent<EventTileList>();
        _SPM = GameObject.Find("EnemyControler").GetComponent<ScriptPlayerManager>();
        base.SetGame();
        for (int i = 0; i < SpawnList.Length; i++)
        {
            SpawnList[i].setGame();
        }
    }
    public override void PressEvent(PlayerBase _player)
    {
        if (!_player.team && !eventlist.spawnList.Contains(code))
        {
            _SPM.addPlayers(SpawnList);
            eventlist.spawnList.Add(code);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
