using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    TextController _text;
    [SerializeField] Animator anim;
    [SerializeField] CutsceneEventTile _tile;
    List<string> dialogs;

    public void nextDialog()
    {
        if (dialogs.Count > 0)
        {
            string diag = dialogs[0];
            print(diag);
            dialogs.RemoveAt(0);
            _text.StartText(diag);
        }
        else
        {
            _text.terminado = true;
            _tile.returnTurn();
        }
    }
    public void loadDialogs(List<string> newdialog,CutsceneEventTile tile)
    {
        _tile = tile;
        dialogs = new List<string>();
        dialogs.AddRange(newdialog);
    }
    private void Start()
    {
        _text = GetComponent<TextController>();
        List<string> loaddialos = new List<string>();
       /* loaddialos.Add("Que culo nena");
        loaddialos.Add("Te voy a romper el orto pelotudo");
        loaddialos.Add("No pilien");
        loaddialos.Add("GAAAAAAAAAAAAAARROTE");
        loadDialogs(loaddialos);*/
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(!_text.escribiendo || _text.terminado)
            {
                print("next");
                nextDialog();
            }
            else
            {
                print("skip");
                _text.SkipTalk();
            }
        }
    }
}
