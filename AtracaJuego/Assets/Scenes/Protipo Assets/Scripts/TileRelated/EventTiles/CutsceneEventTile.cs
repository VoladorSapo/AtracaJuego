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
    [SerializeField] DialogueController dc;
    [SerializeField] LocalizedString _localizedstring;
    [SerializeField] TutorialController _tutorial;
    [SerializeField] string tutorialcode;
    [SerializeField] string type;
    [SerializeField] bool hasReturn;
    // Start is called before the first frame update

    public override void PressEvent(PlayerBase _player)
    {
        player = _player;
        print("waka waka");
        if (!GetComponentInParent<EventTileList>().eventlist.Contains(code))
        {
            GetComponentInParent<EventTileList>().eventlist.Add(code);
            List<string> list = GetLocalizedString.getLocalizedString(table, code);

            //bool finish = false;
            //int i = 0;
            //while (!false)
            //{
            //    _localizedstring.TableReference = table;
            //    string reference = code + "_" + i;
            //    _localizedstring.TableEntryReference = reference;
            //    if (!_localizedstring.GetLocalizedString().Contains("No translation found for"))
            //    {
            //        list.Add(_localizedstring.GetLocalizedString());
            //    }
            //    else
            //    {
            //        finish = true;
            //        break;
            //    }
            //    i++;
            //}
            dc.loadDialogs(list, this, null);
        }
    }
    public override void SetGame()
    {
        base.SetGame();
        _tutorial = GameObject.Find("Tutorial").GetComponent<TutorialController>();
        dc = GameObject.Find("DialogueController").GetComponent<DialogueController>();
        hasReturn = false;
    }
    public void returnTurn()
    {
        string newtype = hasReturn ? "hasReturn" : type;
        print(newtype);
        switch (newtype)
        {
            case "tutorial":
                _tutorial.loadDialogs(tutorialcode, null, this);
                hasReturn = true;
                break;
            default:
                if (player.getAttack())
                {
                    player.ChangeMapShown(0);
                }
                else
                {
                    player.ChangeMapShown(2);
                }
                break;
        }
    }
    // Update is called once per frame
}
