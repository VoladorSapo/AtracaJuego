using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDialogController : MonoBehaviour
{
    [SerializeField] TextController _text;
    [SerializeField] Animator anim;
    List<Dialog> dialogs;
    bool writingtext;
    // Start is called before the first frame update
    void Start()
    {
        writingtext = false;
        _text = GetComponent<TextController>();
        List<Dialog> loaddialos = new List<Dialog>();
        loaddialos.Add(new Dialog("Que culo nena", 1, 20));
        loaddialos.Add(new Dialog("Te voy a romper el orto pelotudo", 3, 20));
        loaddialos.Add(new Dialog("Pongan Melendi", 4, 20));
        loaddialos.Add(new Dialog("Paga tus impuestos", 6, 20));
        loadDialogs(loaddialos);
    }
    public void loadDialogs(List<Dialog> newdialog)
    {
        dialogs = new List<Dialog>();
        dialogs.AddRange(newdialog);
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
            _text.StartText(dialogs[0].txt);
            anim.SetInteger("Character", dialogs[0].character);
            dialogs.RemoveAt(0);
        }
    }
    IEnumerator Text()
    {
        yield return new WaitForSeconds(1);
        writeText();
    }
}
