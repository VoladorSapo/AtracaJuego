using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tunController : MonoBehaviour
{
    public ScriptPlayerManager[] Managers;
    public int currentManager;

    public GridController _GC;
    
    GridController _grid;

    void Awake(){
        _GC=GameObject.Find("Grid").GetComponent<GridController>();
        
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

        if(Input.GetKeyDown("p")){
            nextTurn();
        }
    }
    // Start is called before the first frame update
    public void startRound()
    {
        currentManager = -1;
       
        startTurns();
    }

    public void startTurns()
    {
        
        currentManager++;
        if(currentManager < Managers.Length)
        {
            for (int i = 0; i < Managers.Length; i++)
            {
                Managers[i].Activated = false;
            }
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
    }
}
