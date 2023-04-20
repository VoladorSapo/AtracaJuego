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
    [SerializeField] gameController _GC;
    // Start is called before the first frame update
    void Awake()
    {
        _GC = GameObject.Find("Controller").GetComponent<gameController>();
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
            combinaciones[num] = true;
            //Añadir algo epicardo
        }
    }
    void LeaveScene(Scene scene)
    {
        if(_info == null)
        {
            _info = Instantiate(infoprefab).GetComponent<GlosarioInfo>();
            SaveController.Save(_GC.nextScene,combinaciones);
            _info.combinacionespermanentes = combinaciones;
        }
    }
    /* Lista combinaciones
     * 1 = Explosion;    2 = Derretir Hielo;    3 = Congelar Agua;    4 = Empujar Hielo;    5 = Derretir Cubo;    
     * 6 = Empujar Gas;    7 = Crear Gasolina;   8 = Cargar Gas;    9 = Cargar Gasolina;    10 = Electrocutar Agua;
     * 11 = Quemar Gasolina;    12 = Congelar Gasolina;    13 = Pinchos;    14 = Pinchos Gasolina;    15 = Evaporar Agua;
     * 16 = Derretir Gasolina;  17 = Cargar Iowa;   18 = Gas Sobre Fuego; 19 = Hielo Sobre Fuego
     *  
     * 
     */
    public void ChangeGlosario(int baseeffect, int neweffect,bool iceCube, Vector3 pos)
    {
        print(baseeffect + " " + neweffect + "" + iceCube + " glosario");
        switch (neweffect)
        {
            case 1: //Gas
                switch (baseeffect)
                {
                    case 4:
                        newEntry(18);
                        break;
                    case 5:
                        newEntry(7);

                        break;
                    case 6:
                        newEntry(8);

                        break;
                }
                break;
            case 2: //Fire
                if (!iceCube)
                {
                    switch (baseeffect)
                    {
                        case 1:
                            newEntry(1);
                            break;
                        case 5:
                            newEntry(2);
                            break;
                        case 3:
                            newEntry(11);
                            break;
                        case 2:
                            newEntry(15);
                            break;
                        case 9:
                            newEntry(16);
                            break;
                    }
                }
                else
                {
                    newEntry(5);

                }
                break;
            case 3: //Push
                if (!iceCube)
                {
                    switch (baseeffect)
                    {
                        case 5:
                            newEntry(13);
                            break;
                        case 9:
                            newEntry(14);
                            break;
                      
                    }
                }
                else
                {
                    newEntry(4);

                }
                break;
            case 4: //Ice
                switch (baseeffect)
                {
                    case 1:
                        newEntry(7);
                        break;
                    case 3:
                        newEntry(12);
                        break;
                    case 4:
                        newEntry(19);
                        break;
                    case 7:
                        newEntry(7);
                        break;
                }
                break;
            case 5: //Elec
                switch (baseeffect)
                {
                    case 1:
                        newEntry(8);
                        break;
                    case 2:
                        newEntry(10);
                        break;
                    case 3:
                        newEntry(9);
                        break;
                }
                break;
        }
    }

}
