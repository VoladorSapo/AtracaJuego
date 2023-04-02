using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tunController : MonoBehaviour
{
    public ScriptPlayerManager[] Managers;
    public int currentManager;
    GridController _grid;
    public void startGame()
    {
        startRound();
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            startGame();
        }
    }
    // Start is called before the first frame update
    public void startRound()
    {
        currentManager = -1;
        for (int i = 0; i < Managers.Length; i++)
        {
            Managers[i].setGame();
        }
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

    public void nextTurn(PlayerBase personaje)
    {
     
    }
}
