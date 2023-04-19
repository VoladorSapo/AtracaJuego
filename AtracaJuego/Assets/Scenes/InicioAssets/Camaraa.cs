using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        confirmnew.SetActive(confirm);

    }
    public void LoadNewGame()
    {
        SceneManager.LoadScene(1);

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
