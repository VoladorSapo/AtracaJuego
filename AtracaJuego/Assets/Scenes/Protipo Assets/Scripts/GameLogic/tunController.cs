using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tunController : MonoBehaviour
{
    public ScriptPlayerManager[] Managers;
    public int currentManager;
    public PalancaTest _palancaTest;
    public GridController _GC;
    private turnButtonsController tBC;
    GridController _grid;
    private ObjectStuff[] objects;

    void Awake(){
        _GC=GameObject.Find("Grid").GetComponent<GridController>();
        _palancaTest=FindObjectOfType<PalancaTest>();
        objects=FindObjectsOfType<ObjectStuff>();
        tBC=GameObject.Find("TurnButtons").GetComponent<turnButtonsController>();
    }
    public void startGame()
    {
        for (int i = 0; i < Managers.Length; i++)
        {
            Managers[i].setGame();
        }
        startRound();
    }
    private void Update()
    {
        //if (Input.GetKeyDown("space"))
        //{
        //    _GC.setGame();
        //    startGame();
        //}

        if(Input.GetKeyDown("space")){
            tBC.Skip(true);
            //nextTurn();
        }
    }
    // Start is called before the first frame update
    public void startRound()
    {
        currentManager = -1;
       
        startTurns();

        objects=FindObjectsOfType<ObjectStuff>();
        foreach(ObjectStuff o in objects){
            o.startTurn();
        }
        
        if(_GC.tilesConEffects.Count!=0){
        
        foreach(CustomTileClass t in _GC.tilesConEffects.ToArray()){
            t.LowerFade();
        }
        }
        

        /*
        for(int i=0; i<_GC.tiles.GetLength(0); i++){
            for(int j=0; j<_GC.tiles.GetLength(1); j++){
                _GC.tiles[i,j].LowerFade();
            }
        }*/
    }

    public void startTurns()
    {
        print("waka");
        currentManager++;
        if(currentManager < Managers.Length)
        {
            for (int i = 0; i < Managers.Length; i++)
            {
                Managers[i].Activated = false;
            }
            Debug.LogWarning(currentManager);
            Managers[currentManager].Activated = true;
            Managers[currentManager].StartTurns();
        }
        else
        {
            startRound();
        }
    }

    public void nextTurn()
    {
      for(int i=0; i<_GC.tiles.GetLength(0); i++){
            for(int j=0; j<_GC.tiles.GetLength(1); j++){
                _GC.tiles[i,j].LowerFade();
            }
        }
        startTurns();
        if(_palancaTest!=null){_palancaTest.LowerActives();}
    }
}
