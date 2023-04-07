using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class cutsceneController : MonoBehaviour
{
    [SerializeField] PlayerBase player;
    string table;
     string code;
    [SerializeField] bool endCutscene; //False if is the cutscene at the start of the level. True if it is the cutscene at the end
    [SerializeField] DialogueController dc;
    [SerializeField] LocalizedString _localizedstring;
    [SerializeField] gameController _gc;
    // Start is called before the first frame update
    void Start()
    {
        _gc = GameObject.Find("Controller").GetComponent<gameController>();

    }
    public void loadScene(string table,string code,bool endScene)
    {
        List<string> list = GetLocalizedString.getLocalizedString(table, code);
        endCutscene = endScene;
      //  GetLocalizedString.getLocalizedString(table, code);
      /*  bool finish = false;
        int i = 0;
        while (!false && i<20)
        {
            _localizedstring.TableReference = table;
            string reference = code + "_" + i;
            i++;
            _localizedstring.TableEntryReference = reference;
            if (!_localizedstring.GetLocalizedString().Contains("No translation found for"))
            {
                list.Add(_localizedstring.GetLocalizedString());
                print("hei");
            }
            else
            {
                finish = true;
                break;
            }
        }*/
        dc.loadDialogs(list, null, this);
    }
    public void returnTurn()
    {
        _gc.returnFromCutscene(endCutscene);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
