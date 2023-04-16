using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GlosarioController : MonoBehaviour
{
    public bool[] combinaciones;
    public GameObject Glosario;
    [SerializeField] Button openbutton;
    [SerializeField] Button closebutton;
    // Start is called before the first frame update
    void Awake()
    {
        closeGlosario();
        Buttons(false);
    }
   public void Buttons(bool set)
    {
        openbutton.enabled = set;
        closebutton.enabled = set;

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void printar()
    {
        print("glosario cargao");
    }
    public void openGlosario()
    {
        closebutton.enabled = true;
        openbutton.enabled = false;

        Glosario.SetActive(true);
        GlosarioEntry[] entrys = Glosario.GetComponentsInChildren<GlosarioEntry>();
        foreach(GlosarioEntry entry in entrys)
        {
            entry.OpenGlosario();
        }
    }
    public void closeGlosario()
    {
        closebutton.enabled = false;
        openbutton.enabled = true;
        Glosario.SetActive(false);

    }
    public void newEntry()
    {

    }
    public void ChangeGlosario(int baseeffect, int neweffect,bool iceCube, Vector3 pos)
    {
        print(baseeffect + " " + neweffect +" glosario");
        switch (baseeffect)
        {
            case 1:
                switch (neweffect)
                {

                }
                break;
        }
    }
}
