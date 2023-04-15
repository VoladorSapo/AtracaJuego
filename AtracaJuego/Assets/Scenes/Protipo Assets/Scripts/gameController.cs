using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
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
    [SerializeField] string tutorialcode;
    [SerializeField] string type;
    [SerializeField] bool hasReturn;
    [SerializeField] GameObject retryConfirm;
    [SerializeField] int nextScene;
    [SerializeField] TutorialController _tutorial;
    [SerializeField] cameraMove camara;
    public bool Pause;
    // Start is called before the first frame update
    void Start()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[3];
        _GC = GameObject.Find("Grid").GetComponent<GridController>();
        _TC = GameObject.Find("Controller").GetComponent<tunController>();
        _cutsceneController = GameObject.Find("Controller").GetComponent<cutsceneController>();
        _tutorial = GameObject.Find("Tutorial").GetComponent<TutorialController>();
        camara = GameObject.Find("Main Camera").GetComponent<cameraMove>();
        retryConfirm = GameObject.Find("RetryConfirm");
        retryConfirm.SetActive(false);

        StartCoroutine(StartLate());
    }
    IEnumerator StartLate()
    {

        yield return new WaitForEndOfFrame();
        string fullcode = "start_" + code;
        Pause = true;
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
            //_cutsceneController.loadScene(table, fullcode,false);

        }
    }
    public void returnFromCutscene(bool end)
    {
        print("caspita");
        if (end)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            string newtype = hasReturn ? "hasReturn" : type;
            print(newtype);
            switch (newtype)
            {
                case "tutorial":
                    _tutorial.loadDialogs(tutorialcode, this, null);
                    Pause = true;
                    hasReturn = true;
                    break;
                default:
                    Pause = false;
                    startGame();
                    print("jojojo");
                    break;
            }


        }
    }
    public void startGame()
    {
        retryConfirm.SetActive(false);
        hasReturn = false;
        _GC.setGame();
        _TC.startGame();
        Pause = false;
    }
    public void winTilePressed()
    {
        if (winCondition == 1)
        {
            winRound();
        }
    }
    public void teamDie(ScriptPlayerManager manager)
    {
        if (System.Array.IndexOf(_turn.Managers, manager) == 0)
        {
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
        _cutsceneController.loadScene(table, fullcode, true);
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
    public void hideRetry()
    {
        retryConfirm.SetActive(false);
    }
}
