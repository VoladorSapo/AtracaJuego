using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization;

public class TextController : MonoBehaviour
{
    public TMP_Text TextDisplay;
    TMP_TextInfo textinfo;
    DialogueController _dialogcontroller;
    GameDialogController _gamedialogcontroller;
    public bool escribiendo;
    public bool terminado;
    public string texto;
    public WaitForSeconds delay;
    public int currentChar;
    float charpersec;
    // Start is called before the first frame update
    void Awake()
    {
        escribiendo = false;
        terminado = false;
        _dialogcontroller = GetComponent<DialogueController>();
        _gamedialogcontroller = GetComponent<GameDialogController>();

        texto = "";
        charpersec = 20f;

    }
    public void StartText( string txt)
    {
        //TextDisplay.ForceMeshUpdate();
        currentChar = 0;
        TextDisplay.enabled = true;
        TextDisplay.text = txt;
        TextDisplay.maxVisibleCharacters = 0;
        textinfo = TextDisplay.textInfo;
        print(TextDisplay.textInfo.lineCount + "Aiaiaiaiia");
        print(TextDisplay.text);
        TextDisplay.ForceMeshUpdate();
        print(textinfo.characterCount);
        //TextDisplay.color = Color.white;
        escribiendo = true;
        terminado = false;
        delay = new WaitForSeconds(1/charpersec);
        StartCoroutine("Escribir");
    }
    public IEnumerator Escribir()
    {
        //yield return new WaitForSeconds(0.05f);
        print(textinfo.characterCount);
        while (currentChar < textinfo.characterCount)
        {
            TextDisplay.maxVisibleCharacters++;
            yield return delay;
            //yield return new WaitForSecondsRealtime(0.2f) ;
            currentChar++;
        }
        terminado = true;
        if (_gamedialogcontroller != null)
        {
            _gamedialogcontroller.StartCoroutine("Text");
        }
    }
    public void SkipTalk()
    {
        StopCoroutine("Escribir");
        print(terminado);
        terminado = true;
        if(_gamedialogcontroller != null)
        {
            _gamedialogcontroller.StartCoroutine("Text");
        }
        TextDisplay.maxVisibleCharacters = TextDisplay.textInfo.characterCount;
    }
    // Update is called once per frame
    void Update()
    { 

    }
}
