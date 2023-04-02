using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlayerManager : MonoBehaviour
{
    //Contiene el control sobre los scripts de los demás personajes
    public tunController _turn;
    public gameController _gameController;
    public List<PlayerBase> players;
    public bool Activated;
    public int currentPlayer;
    public int deadPlayer;

    public int[] MaxDistancePlayers={5,6,4,3,8}; //Ignacio,Iowa,Marl,Nev,Paul
    void Update(){

    }
    public void setGame()
    {
        for(int i = 0; i < players.Count; i++)
            {
            players[i].setGame();
            players[i].teamNumb = i;

        }
    }
    public void StartTurns()
    {

        if (players.Count <= 0)
        {
            _turn.startRound();
        }
        else
        {
            for (int i = 0; i < players.Count; i++)
            {
                players[i].setTurn(false);
                players[i].teamNumb = i;
                
            }
            currentPlayer = 0;
            players[0].startTurn();
        }
    }
    public void ChangePlayer(int player)
    {
        print("dubi"+player);
        if (!players[player].getTurn())
        {
            print("cubi" + player);
            currentPlayer = player;
            players[player].startTurn();
        }
    }
    public void playerDie(PlayerBase player)
    {
        if (players.Contains(player))
        {
            deadPlayer = players.IndexOf(player);
            players.Remove(player);
            for (int i = 0; i < players.Count-1; i++)
            {
                players[i].teamNumb = i;
            }
            if (Activated)
            {
                endTurn(0, true);
            }
        }
        if(players.Count == 0)
        {
            _gameController.teamDie(this);
        }
    }
    public void endTurn(int player,bool die)
    {
        if (!die)
        {
            players[player].setTurn(true);
        }
        currentPlayer = -1;
        for (int i = 0; i < players.Count; i++)
        {
            if(!players[i].getTurn()){
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
