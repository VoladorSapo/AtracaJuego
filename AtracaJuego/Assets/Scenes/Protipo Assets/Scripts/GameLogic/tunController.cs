using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tunController : MonoBehaviour
{
    public List<PlayerBase> jugadores;
    public List<PlayerBase> enemigos;
    
    public PlayerBase[] alljugadores;
    public PlayerBase[] allenemigos;
    GridController _grid;
    public void startGame()
    {
        jugadores = new List<PlayerBase>();
        enemigos = new List<PlayerBase>();
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
        jugadores.AddRange(alljugadores);
        jugadores.AddRange(allenemigos);
        startTurn();
    }

    public void startTurn()
    {
        if (jugadores.Count > 0)
        {
            jugadores[0].Turn() ;
        }
        else if (jugadores.Count > 0)
        {
            enemigos[0].Turn();
        }
        else
        {
            startRound();
        }
    }

    public void nextTurn(PlayerBase personaje)
    {
        if (jugadores.Contains(personaje))
        {
            jugadores.Remove(personaje);
        }
        else
        {
            enemigos.Remove(personaje);
        }
        startTurn();
    }
}
