using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class CombatDialogTile : EventTile
{
    [SerializeField] string table;
    [SerializeField] string code;
    [SerializeField] int random;
    [SerializeField] LocalizedString _localizedstring;
    [SerializeField] GameDialogController gdc;

    public override void PressEvent(PlayerBase _player)
    {
        int rnd = Random.Range(0, random);
        string newcode = code + "_" + rnd;
        if (!GetComponentInParent<EventTileList>().eventlist.Contains(code))
        {
            GetComponentInParent<EventTileList>().eventlist.Add(code);
            List<string> list = GetLocalizedString.getLocalizedString(table, newcode);
            //bool finish = false;
            //int i = 0;
            //while (!false)
            //{
            //    _localizedstring.TableReference = table;
            //    string reference = code + "_" + rnd + "_" + i;
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

            gdc.loadDialogs(list);
        }
    }



}
