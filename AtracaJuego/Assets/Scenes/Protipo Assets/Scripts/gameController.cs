using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameController : MonoBehaviour
{
    [SerializeField] tunController _turn;
    [SerializeField] TextController _text;
    [SerializeField] private int winCondition;
    [SerializeField] cutsceneController _cutsceneController;
    [SerializeField] string table;
    [SerializeField] string code;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            SceneManager.LoadScene(1);
        }
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
        string fullcode = "end_" + code;
        _cutsceneController.loadScene(table, fullcode);
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
