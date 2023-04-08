using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueController : MonoBehaviour
{
    TextController _text;
    [SerializeField] Animator anim;
    [SerializeField] DialogEvent evento;
    [SerializeField] GameObject _dialogbox;
    [SerializeField] CutsceneEventTile _tile;
    [SerializeField] cutsceneController _cutscene;
    [SerializeField] TMP_Text name_text;
    List<string> dialogs;

    public void nextDialog()
    {
        if (dialogs.Count > 0)
        {
            string diag = dialogs[0];
            print(diag);
            dialogs.RemoveAt(0);
            _text.StartText(diag);
            evento.CheckForLinkEvent();

        }
        else
        {
            _text.terminado = true;
            _dialogbox.SetActive(false);
            if (_tile)
            {
                _tile.returnTurn();
            }
            else
            {
                _cutscene.returnTurn();
            }
        }
    }
    public void setAnim(int animint)
    {
        anim.SetInteger("Character", animint);
        switch (animint)
        {
            case 0:
                name_text.text = "";
                break;
            case 1:
                name_text.text = "Ignacio";
                break;
            case 2:
                name_text.text = "Marl";
                break;
            case 3:
                name_text.text = "Iowa";

                break;
            case 4:
                name_text.text = "Pol";

                break;
            case 5:
                name_text.text = "Nev";

                break;
            case 6:
                name_text.text = "Guardia";
                break;
        }
    }
    public void loadDialogs(List<string> newdialog,CutsceneEventTile tile,cutsceneController controller)
    {
        _dialogbox.SetActive(true);
        _tile = tile;
        _cutscene = controller;
        dialogs = new List<string>();
        dialogs.AddRange(newdialog);
        nextDialog();
    }
    private void Start()
    {
        _text = GetComponent<TextController>();
        List<string> loaddialos = new List<string>();
        evento = GetComponentInChildren<DialogEvent>();

        _dialogbox.SetActive(false);
        /* loaddialos.Add("Que culo nena");
         loaddialos.Add("Te voy a romper el orto pelotudo");
         loaddialos.Add("No pilien");
         loaddialos.Add("GAAAAAAAAAAAAAARROTE");
         loadDialogs(loaddialos);*/
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _dialogbox.activeSelf)
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
