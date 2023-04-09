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
    [SerializeField] GridController _GC;
    [SerializeField] tunController _TC;
    [SerializeField] string table;
    [SerializeField] string code;
    [SerializeField] GameObject retryConfirm;
    [SerializeField] int nextScene;
    // Start is called before the first frame update
    void Start()
    {
        _GC = GameObject.Find("Grid").GetComponent<GridController>();
        _TC = GameObject.Find("Controller").GetComponent<tunController>();
        _cutsceneController = GameObject.Find("Controller").GetComponent<cutsceneController>();
        retryConfirm.SetActive(false);

        StartCoroutine(StartLate());
    }
    IEnumerator StartLate()
    {

        yield return new WaitForSeconds(2);
        string fullcode = "start_" + code;
        _cutsceneController.loadScene(table, fullcode, false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown("space"))
        {
            //returnFromCutscene(false);
            //GC.setGame();
           // _TC.startGame();
            string fullcode = "start_" + code;
            _cutsceneController.loadScene(table, fullcode,false);
           
        }
    }
    public void returnFromCutscene(bool end)
    {
        if (end)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            startGame();
            print("jojojo");
            
        }
    }
    public void startGame()
    {
        retryConfirm.SetActive(false);

        _GC.setGame();
        _TC.startGame();
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
                print("ganastelight");
                winRound();
                print("ganastelight");
            }
        }
    }
    public void winRound()
    {
        print("ganamos light");
        string fullcode = "end_" + code;
        _cutsceneController.loadScene(table, fullcode,true);
    }
    public void loseRound()
    {
        retryConfirm.SetActive(true);
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
