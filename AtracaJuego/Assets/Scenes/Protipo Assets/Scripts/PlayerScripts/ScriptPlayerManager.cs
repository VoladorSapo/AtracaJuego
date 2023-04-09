using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlayerManager : MonoBehaviour
{
    //Contiene el control sobre los scripts de los demás personajes
    public tunController _turn;
    public gameController _gameController;
   /*[HideInInspector]*/ public List<PlayerBase> players;
    [SerializeField] PlayerBase[] startPlayer;
    public bool Activated;
    public int currentPlayer;
    public int deadPlayer;
    public bool isEnemy;
    public int[] MaxDistancePlayers={5,6,4,3,8}; //Ignacio,Iowa,Marl,Nev,Paul
    void Update(){

    }
    public void setGame()
    {
        players = new List<PlayerBase>();
        players.AddRange(startPlayer);
        for(int i = 0; i < players.Count; i++)
            {
            players[i].setGame();
            players[i].teamNumb = i;
            players[i].team = isEnemy;

        }
    }
    public void StartTurns()
    {
        print("olemibeti");
        if (players.Count <= 0)
        {
            print("abundalacaca");
            _turn.startRound();
        }
        else
        {
            for (int i = 0; i < players.Count; i++)
            {
                players[i].setTurn(false);
                players[i].teamNumb = i;
                //players[i].startTurn();
            }
            currentPlayer = 0;
            if (isEnemy)
            {
                players[0].startTurn();
            }
            else
            {
                players[0].ChangeMapShown(0);
            }
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
            for (int i = 0; i < players.Count; i++)
            {
                players[i].teamNumb = i;
            }
            if (Activated && players.Count > 0)
            {
                players[0].ChangeMapShown(0);
            }
        }
        if(players.Count == 0)
        {
            _gameController.teamDie(this);
        }
    }
    public void nextTurn(int player,bool die)
    {
         if (!die)
         {
             players[player].setTurn(true);
         }
         currentPlayer = -1;
         print(players.Count);
         for (int i = 0; i < players.Count; i++)
         {
             print("ai");
             if(!players[i].getTurn()){
                 print("Noa");
                 currentPlayer = i;
                 players[i].startTurn();
                 break;
             }
         }

        if (currentPlayer == -1)
        {
            print("nextteam");
            endTurn();
        }
    }
    public void endTurn()
    {
        _turn.startTurns();

    }
}
