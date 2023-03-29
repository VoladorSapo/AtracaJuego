using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    [SerializeField] tunController _turn;
    [SerializeField] TextController _text;
    [SerializeField] private int winCondition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("l"))
        //{
        //    print("oki");
        //    _text.StartCoroutine("Escribir", "Estoy un poco intranquilo mientras el género urbano vigilo Asomando la mirada como un cocodrilo en el río Nilo Ajustando un par de cuenta' Pendiente' ante' de que llegue Milo Sentado en una silla bajo una sombrilla en camisilla Con el perro mordiéndome la' zapatilla' Eructando tortilla' y las tostadas con mantequilla Apuntando al horizonte con un rifle sin mirilla Mientras hablo solo como Don Quijote");
        //}
    }
    public void winTilePressed()
    {
        if(winCondition == 1)
        {
            winRound();
        }
    }
    public void teamDie(ScriptPlayerManager manager)
    {
        if (System.Array.IndexOf(_turn.Managers, manager) == 0){
            loseRound();
        }
        else
        {
            if (winCondition == 0)
            {
                winRound();
            }
        }
    }
    public void winRound()
    {
        print("Ganaste Light");
    }
    public void loseRound()
    {
        print("Cagaste Light");
    }
    public int getCondition()
    {
        return winCondition;
    }
    public void setCondition(int cond)
    {
        winCondition = cond;
    }
}
