using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class DialogEvent : MonoBehaviour
{
  [SerializeField]  private TMP_Text _textbox;
    [SerializeField] GameDialogController _GDC;


    private void Awake()
    {
        _textbox = GetComponentInChildren<TMP_Text>();
        _GDC = GetComponentInChildren<GameDialogController>();
    }

    public  void CheckForLinkEvent()
    {
        print("ou");
        var numeroeventos = _textbox.textInfo.linkCount;
        print(_textbox.text);
        print(numeroeventos);
        if (numeroeventos == 0)
            return;

        for (int i = 0; i < numeroeventos; i++)
        {
           TMP_LinkInfo eventoinfo = _textbox.textInfo.linkInfo[i];
            EventHandler(eventoinfo.GetLinkID());
        }
    }
    void EventHandler(string evento)
    {
        string[] eventoarray = evento.Split('-');
        switch (eventoarray[0])
        {
            case "SetAnim":
                _GDC.setAnim(int.Parse(eventoarray[1]));
                break;
        }
    }
}

