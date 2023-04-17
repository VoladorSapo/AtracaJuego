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
    [SerializeField] public GlosarioInfo _info;
    [SerializeField] GameObject infoprefab;
    // Start is called before the first frame update
    void Awake()
    {
        closeGlosario();
        Buttons(false);
        combinaciones[0] = true;

    }
    public void Buttons(bool set)
    {
        openbutton.gameObject.SetActive(set);
        closebutton.gameObject.SetActive(false);
        SceneManager.sceneUnloaded += LeaveScene;

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
        closebutton.gameObject.SetActive(true);
        openbutton.gameObject.SetActive(false);

        Glosario.SetActive(true);
        GlosarioEntry[] entrys = Glosario.GetComponentsInChildren<GlosarioEntry>();
        foreach(GlosarioEntry entry in entrys)
        {
            entry.OpenGlosario();
        }
    }
    public void closeGlosario()
    {
        closebutton.gameObject.SetActive(false);
        openbutton.gameObject.SetActive(true);
        Glosario.SetActive(false);

    }
    public void newEntry(int num)
    {
        if (!combinaciones[num])
        {
            
        }
    }
    void LeaveScene(Scene scene)
    {
        if(_info == null)
        {
            _info = Instantiate(infoprefab).GetComponent<GlosarioInfo>();
            _info.combinacionespermanentes = combinaciones;
        }
    }
    public void ChangeGlosario(int baseeffect, int neweffect,bool iceCube, Vector3 pos)
    {
        print(baseeffect + " " + neweffect +" glosario");
        switch (baseeffect)
        {
            case 1: //Gas
                switch (neweffect)
                {
                    case 4:
                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                }
                break;
            case 2: //Fire
                if (iceCube)
                {
                    switch (neweffect)
                    {
                        case 1:
                            newEntry(1);
                            break;
                        case 5:

                            break;
                        case 7:

                            break;
                        case 8:

                            break;
                        case 9:

                            break;
                        case 10:

                            break;
                    }
                }
                break;
            case 3: //Push
                if (iceCube)
                {
                    switch (neweffect)
                    {
                        case 5:

                            break;
                        case 9:

                            break;
                      
                    }
                }
                break;
            case 4: //Ice
                switch (neweffect)
                {
                    case 1:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                }
                break;
            case 5: //Elec
                switch (neweffect)
                {
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                }
                break;
        }
    }
}
