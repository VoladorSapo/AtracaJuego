using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlosarioInfo : MonoBehaviour
{
   public bool[] combinacionespermanentes;
    GlosarioController glosario;
    // Start is called before the first frame update
    void Awake()
    {
        combinacionespermanentes = new bool[25];
        combinacionespermanentes[0] = true;
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += ChangedActiveScene;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ChangedActiveScene(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex != 0)
        {
            glosario = GameObject.Find("GlosarioController").GetComponent<GlosarioController>();
            glosario.combinaciones = combinacionespermanentes;
        }
    }
}
