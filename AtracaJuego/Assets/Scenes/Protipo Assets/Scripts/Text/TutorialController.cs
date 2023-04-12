using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    List<string> dialoglist;
    [SerializeField] TMP_Text display;
    [SerializeField] GameObject gameobject;
    [SerializeField] Button nextbutton;
    [SerializeField] Sprite next;
    [SerializeField] Sprite cross;
    [SerializeField] CutsceneEventTile _tile;
    [SerializeField] gameController _cutscene;
    [SerializeField] DialogEvent evento;

    private void Start()
    {
        gameobject.SetActive(false);
        List<string> dialoglist = new List<string>();
        evento = GetComponent<DialogEvent>();
    }
    public void loadDialogs(string code, gameController _cut,CutsceneEventTile _til)
    {
        dialoglist = GetLocalizedString.getLocalizedString("tutorial", code);
        
        gameobject.SetActive(true);
        _tile = _til;
        _cutscene = _cut;
        if (dialoglist.Count == 1)
        {
            nextbutton.image.sprite = cross;
        }
        else
        {
            nextbutton.image.sprite = next;
        }
        nextDialog();

    }
    public void nextDialog()
    {
        if (dialoglist.Count > 0)
        {
            display.text = dialoglist[0];
            if (dialoglist.Count == 1)
            {
                nextbutton.image.sprite = cross;
            }
            dialoglist.RemoveAt(0);
            StartCoroutine(Waitsome());
        }
        else
        {
            evento.EventHandler("SetFondo-0");
            gameobject.SetActive(false);
            if (_tile)
            {
                _tile.returnTurn();
            }
            else
            {
                _cutscene.returnFromCutscene(false);
            }
        }
    }
    IEnumerator Waitsome()
    {
        yield return new WaitForEndOfFrame();
        evento.CheckForLinkEvent();
    }
}
