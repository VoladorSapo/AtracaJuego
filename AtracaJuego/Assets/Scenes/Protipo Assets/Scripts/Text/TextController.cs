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
            if(_dialogcontroller!=null && !terminado){
            switch(_dialogcontroller.name_text.text){
                case "Ignacio": 
                                SoundManager.InstanceSound.SetVolume(1, SoundManager.InstanceSound._dialog);
                                SoundManager.InstanceSound.PlaySound(SoundManager.InstanceSound._dialog,SoundGallery.InstanceClip.audioClips[10]);
                break;
                case "Iowa": 
                             SoundManager.InstanceSound.SetVolume(0.25f, SoundManager.InstanceSound._dialog);
                             SoundManager.InstanceSound.PlaySound(SoundManager.InstanceSound._dialog,SoundGallery.InstanceClip.audioClips[11]);
                break;
                case "Marl": 
                             SoundManager.InstanceSound.SetVolume(0.65f, SoundManager.InstanceSound._dialog);
                             SoundManager.InstanceSound.PlaySound(SoundManager.InstanceSound._dialog,SoundGallery.InstanceClip.audioClips[12]);
                break;
                case "Pol": 
                            SoundManager.InstanceSound.SetVolume(1, SoundManager.InstanceSound._dialog);
                            SoundManager.InstanceSound.PlaySound(SoundManager.InstanceSound._dialog,SoundGallery.InstanceClip.audioClips[14]);
                break;
                case "Nev": 
                            SoundManager.InstanceSound.SetVolume(0.4f, SoundManager.InstanceSound._dialog);
                            SoundManager.InstanceSound.PlaySound(SoundManager.InstanceSound._dialog,SoundGallery.InstanceClip.audioClips[13]);
                break;
                case "Joseva":
                            SoundManager.InstanceSound.SetVolume(1, SoundManager.InstanceSound._dialog);
                            SoundManager.InstanceSound.PlaySound(SoundManager.InstanceSound._dialog,SoundGallery.InstanceClip.audioClips[16]);
                break;
                case "Guardia":
                            SoundManager.InstanceSound.SetVolume(1, SoundManager.InstanceSound._dialog);
                            SoundManager.InstanceSound.PlaySound(SoundManager.InstanceSound._dialog,SoundGallery.InstanceClip.audioClips[9]);
                break;
                case "Jefe de Seguridad":
                            SoundManager.InstanceSound.SetVolume(1, SoundManager.InstanceSound._dialog);
                            SoundManager.InstanceSound.PlaySound(SoundManager.InstanceSound._dialog,SoundGallery.InstanceClip.audioClips[9]);
                break;
            }
            }
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
