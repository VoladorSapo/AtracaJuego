using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
public class GameDialogController : MonoBehaviour
{
    [SerializeField] TextController _text;
    [SerializeField] Animator anim;
    [SerializeField] DialogEvent evento;
    public LocalizedString _localizedstring;
    List<string> dialogs;
    bool writingtext;
    // Start is called before the first frame update
    void Start()
    {
        writingtext = false;
        _text = GetComponent<TextController>();
        List<string> loaddialos = new List<string>();
        evento = GetComponentInChildren<DialogEvent>();
        dialogs = new List<string>();
        loaddialos.Add("<link="+"\""+ "SetAnim-1" + "\""+ "> Que culo nena </link>");
        loaddialos.Add("<link=" + "\"" + "SetAnim-3" + "\"" + ">Te voy a romper el orto pelotudo</link>");
        loaddialos.Add("<link=" + "\"" + "SetAnim-2" + "\"" + ">No pilien</link>");
        loaddialos.Add("<link=" + "\"" + "SetAnim-4" + "\"" + ">GAAAAAAAAAAAAAARROTE</link>");
        loadDialogs(loaddialos);
    }
    public void loadDialogs(List<string> newdialog)
    {
        dialogs.AddRange(newdialog);
    }
    public void setAnim(int animint)
    {
        anim.SetInteger("Character", animint);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("n") && !writingtext){
            writingtext = true;
            writeText();
        }
    }
    void writeText()
    {
        if (dialogs.Count > 0)
        {
            _localizedstring.TableReference = "Game_Dialog_Ignacio";
            _localizedstring.TableEntryReference = "Game_Ignacio_Walk";
            _localizedstring.GetLocalizedString();
            _text.StartText(_localizedstring.GetLocalizedString());
            dialogs.RemoveAt(0);
            evento.CheckForLinkEvent();
        }
    }
    IEnumerator Text()
    {
        yield return new WaitForSeconds(1);
        writeText();
    }
}
