using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class cutsceneController : MonoBehaviour
{
    [SerializeField] PlayerBase player;
    [SerializeField] string table;
    [SerializeField] string code;
    [SerializeField] int length;
    [SerializeField] bool endCutscene; //False if is the cutscene at the start of the level. True if it is the cutscene at the end
    [SerializeField] DialogueController dc;
    [SerializeField] LocalizedString _localizedstring;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void loadScene(string table,string code)
    {
        List<string> list = new List<string>();
        bool finish = false;
        int i = 0;
        while (!false)
        {
            _localizedstring.TableReference = table;
            string reference = code + "_" + i;
            _localizedstring.TableEntryReference = reference;
            if (_localizedstring.GetLocalizedString() != "null")
            {
                list.Add(_localizedstring.GetLocalizedString());
            }
            else
            {
                finish = true;
                break;
            }
            i++;
        }
        dc.loadDialogs(list, null, this);
    }
    public void returnTurn()
    {
        if (endCutscene)
        {

        }
        else
        {

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
