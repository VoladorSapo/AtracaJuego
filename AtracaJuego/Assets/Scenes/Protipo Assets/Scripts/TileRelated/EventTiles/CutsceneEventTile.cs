using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
public class CutsceneEventTile : EventTile
{
    [SerializeField] PlayerBase player;
    [SerializeField] string table;
    [SerializeField] string code;
    [SerializeField] int length;
    [SerializeField] DialogueController dc;
    [SerializeField] LocalizedString _localizedstring;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void PressEvent()
    {
        List<string> list = new List<string>();
        for (int i = 0; i < length + 1; i++)
        {
            _localizedstring.TableReference = table;
            string reference = code + "_" + i;
            _localizedstring.TableEntryReference = reference;
            if (_localizedstring.GetLocalizedString() != "null")
            {
                list.Add(_localizedstring.GetLocalizedString());
            }
        }
        dc.loadDialogs(list);
    }
    public void returnTurn()
    {
        if (player.getAttack())
        {
            player.ChangeMapShown(0);
        }
        else
        {
            player.ChangeMapShown(2);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
