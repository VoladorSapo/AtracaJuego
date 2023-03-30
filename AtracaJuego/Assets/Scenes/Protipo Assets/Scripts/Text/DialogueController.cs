using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    TextController _text;
    [SerializeField] Animator anim;
    List<Dialog> dialogs;

    public void nextDialog()
    {
        if (dialogs.Count > 0)
        {
            Dialog diag = dialogs[0];
            print(diag.txt);
            dialogs.RemoveAt(0);
            _text.StartText(diag.txt);
            anim.SetInteger("Character", diag.character);
        }
        else
        {
            _text.terminado = true;
        }
    }
    public void loadDialogs(List<Dialog> newdialog)
    {
        dialogs = new List<Dialog>();
        dialogs.AddRange(newdialog);
    }
    private void Start()
    {
        _text = GetComponent<TextController>();
        List<Dialog> loaddialos = new List<Dialog>();
        loaddialos.Add(new Dialog("Que culo nena", 1, 20));
        loaddialos.Add(new Dialog("Te voy a romper el orto pelotudo", 3, 20));
        loaddialos.Add(new Dialog("No pilien", 5, 20));
        loaddialos.Add(new Dialog("GAAAAAAAAAAAAAARROTE", 6, 20));
        loadDialogs(loaddialos);
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
