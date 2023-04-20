using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class DialogEvent : MonoBehaviour
{
    [SerializeField] private TMP_Text _textbox;
    [SerializeField] GameDialogController _GDC;
    [SerializeField] DialogueController _DC;
    [SerializeField] Camera _cutscenecamera;
    [SerializeField] Camera _maincamera;
    [SerializeField] Animator _fondoanimator;
    [SerializeField] TutorialController _tutorial;
    private void Awake()
    {
        _textbox = GetComponentInChildren<TMP_Text>();
        _GDC = GetComponentInChildren<GameDialogController>();
        _DC = GetComponentInChildren<DialogueController>();
        _maincamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        _cutscenecamera = GameObject.Find("CutsceneCamera").GetComponent<Camera>();
        _cutscenecamera.enabled = false;
        _maincamera.enabled = true;
        _fondoanimator = GameObject.Find("CutsceneFondo").GetComponent<Animator>();

    }

    public void CheckForLinkEvent()
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
    public void EventHandler(string evento)
    {
        string[] eventoarray = evento.Split('-');
        switch (eventoarray[0])
        {
            case "SetAnim":
                if (_GDC)
                {
                    _GDC.setAnim(int.Parse(eventoarray[1]));

                }
                else
                {
                    if (eventoarray.Length > 2)
                    {
                        _DC.setAnim(int.Parse(eventoarray[1]), int.Parse(eventoarray[2]));
                    }
                    else
                    {
                        _DC.setAnim(int.Parse(eventoarray[1]), 0);
                    }
                }
                break;
            case "SetFondo":
               // print("mr jagger");
                _fondoanimator.SetInteger("Fondo", int.Parse(eventoarray[1]));
                if (int.Parse(eventoarray[1]) == 0)
                {
                    _cutscenecamera.enabled = false;
                    _maincamera.enabled = true;
                    if (_tutorial)
                    {
                        _tutorial.transform.localPosition = new Vector3(0, 0, 0);
                    }
                }
                else
                {
                    _cutscenecamera.enabled = true;
                    _maincamera.enabled = false;
                    if (_tutorial)
                    {
                        _tutorial.transform.localPosition = new Vector3(0, -337, 0);
                    }
                }
                break;
            case "SetSondido":

                break;
        }
    }
}

