using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
public class gameController : MonoBehaviour
{
    [SerializeField] tunController _turn;
    [SerializeField] TextController _text;
    [SerializeField] private int winCondition;
    [SerializeField] cutsceneController _cutsceneController;
    [SerializeField] public GridController _GC;
    [SerializeField] tunController _TC;
    [SerializeField] string table;
    [SerializeField] string code;
    [SerializeField] string tutorialcode;
    [SerializeField] string type;
    [SerializeField] bool hasReturn;

    [SerializeField] GameObject retryConfirm;
    public int nextScene;
    [SerializeField] TutorialController _tutorial;
    [SerializeField] cameraMove camara;
    [SerializeField] Animator anim;
    [SerializeField] Image Img;
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
        anim=GameObject.Find("FadeInOut").GetComponent<Animator>();
        retryConfirm.SetActive(false);

        StartCoroutine(StartLate());
    }
    IEnumerator StartLate()
    {
       // SoundManager.InstanceSound.SetVolume(0.4f,SoundManager.InstanceSound._music);
       // SoundManager.InstanceSound.PlayMusic(0.25f,SoundGallery.InstanceClip.audioClips[17]);
        yield return new WaitForEndOfFrame();
        string fullcode = "start_" + code;
        Pause = true;
        _cutsceneController.loadScene(table, fullcode, false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            SaveController.Save(SceneManager.GetActiveScene().buildIndex,new bool[8]);
        }
        if (Input.GetKeyDown("w"))
        {
            SaveData data = SaveController.Load();
            SceneManager.LoadScene(data.escena);
        }
        if (Input.GetKeyDown("space"))
        {
            //returnFromCutscene(false);
            //GC.setGame();
            // _TC.startGame();
            string fullcode = "start_" + code;
            //_cutsceneController.loadScene(table, fullcode,false);

        }
        if(Input.GetKeyDown("v")){
            winRound();
        }
        if(Input.GetKeyDown("l")){
            loseRound();
        }
    }

    public void loadNext(){
    SceneManager.LoadScene(nextScene);
    }

    public void returnFromCutscene(bool end)
    {
        print("caspita");
        if (end)
        {
            anim.SetBool("Fade",true);
        }
        else
        {
            string newtype = hasReturn ? "hasReturn" : type;
            print(newtype);
            
            switch (newtype)
            {
                case "tutorial":
                    
                    _tutorial.loadDialogs(tutorialcode, this, null);
                    //SoundManager.InstanceSound.PlayMusic(0.25f,SoundGallery.InstanceClip.audioClips[17]);
                    Pause = true;
                    hasReturn = true;
                    break;
                default:
                    //SoundManager.InstanceSound.StartFadeOut(SoundManager.InstanceSound._music);
                    //SoundManager.InstanceSound.PlayMusic(0.5f,SoundGallery.InstanceClip.audioClips[21]);

                    //SoundManager.InstanceSound.ChangeMusic(0.3f,0.25f,null);

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
        string fullcode = "end_" + code;
        _cutsceneController.loadScene(table, fullcode, true);
        //StartCoroutine(FadingWin());
    }

    /*IEnumerator FadingWin(){
        animatorImg.SetBool("Fade",true);
        yield return new WaitUntil(()=>Img.color.a==1);
    }*/
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
