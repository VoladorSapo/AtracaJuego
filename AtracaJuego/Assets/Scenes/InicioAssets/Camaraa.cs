using UnityEngine.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

public class Camaraa : MonoBehaviour
{
    public float speed;
    [SerializeField] GlosarioInfo info;
    [SerializeField] Button loadbutton;
    [SerializeField] GameObject confirmnew;
    void Start()
    {
        RefreshScene();
    }
    void RefreshScene()
    {
        confirmActive(false);
        if ( !SaveController.saveExists())
        {
            loadbutton.interactable = false;
        }
    }
 
    void Update()
    {
        transform.position += new Vector3(Time.deltaTime*speed,0,0);
    }

    public void confirmActive(bool confirm)
    {
        Scene actualScene=SceneManager.GetActiveScene();
        if(actualScene.buildIndex==0)
            confirmnew.SetActive(confirm);

    }
    public void changeLenguage(int change)
    {
        Scene actualScene = SceneManager.GetActiveScene();
        if (actualScene.buildIndex == 0)
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[change];
        }
    }
    public void LoadNewGame()
    {
        SceneManager.LoadScene(11);

    }
    public void NewGame()
    {
        if(!SaveController.saveExists())
        {
            LoadNewGame();
        }
        else
        {
            confirmActive(true);
        }
    }
    public void LoadGame()
    {
        SaveData data = SaveController.Load();
        info.combinacionespermanentes = data.combos;
        SceneManager.LoadScene(data.escena);
    }
}
