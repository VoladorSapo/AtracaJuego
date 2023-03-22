using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlayerManager : MonoBehaviour
{
    //Contiene el control sobre los scripts de los demás personajes
    public tunController _turn;
    public bool[] PlayersMoved;
    public PlayerBase[] players;
    public bool Activated;
    public int currentPlayer;
    void Update(){

    }
    public void StartTurns()
    {
        
        for (int i = 0; i < PlayersMoved.Length; i++)
        {
            PlayersMoved[i] = false;
        }
        currentPlayer = 0;
        players[0].startTurn();
        if (PlayersMoved.Length <= 0)
        {
            _turn.startRound();
        }
    }
    public void ChangePlayer(int player)
    {
        if (!PlayersMoved[player])
        {
            currentPlayer = player;
            players[player].startTurn();
        }
    }
    public void endTurn(int player)
    {
        PlayersMoved[player] = true;
        currentPlayer = -1;
        for (int i = 0; i < PlayersMoved.Length; i++)
        {
            if(PlayersMoved[i] == false){
                currentPlayer = i;
                players[i].startTurn();
                break;
            }
        }
        if(currentPlayer == -1)
        {
            _turn.startTurns();
        }
    }
}
