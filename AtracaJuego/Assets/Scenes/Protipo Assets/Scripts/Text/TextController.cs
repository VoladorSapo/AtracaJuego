using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI TextDisplay;
    public TextMeshProUGUI TextDisplayFull;
    public bool escribiendo;
    public bool terminado;
    public string texto;
    // Start is called before the first frame update
    void Awake()
    {
        escribiendo = false;
        terminado = false;
        texto = "";
    }
    public IEnumerator Escribir(string txt)
    {
        print("doki");
        if (!escribiendo)
        {
            texto = txt;
            TextDisplay.enabled = true;
            TextDisplay.text = txt;
            TextDisplay.color = Color.white;
            TextDisplayFull.enabled = false;
            TextDisplayFull.text = txt;
            escribiendo = true;
            terminado = false;
            for (int i = 0; i < txt.ToCharArray().Length; i++)
            {
                if (!terminado)
                {
                    TextDisplay.maxVisibleCharacters = i + 1;
                    if (TextDisplay.maxVisibleCharacters >= txt.ToCharArray().Length)
                    {
                        terminado = true;
                    }
                    yield return new WaitForSecondsRealtime(0.01f);
                }
                else
                {
                    TextDisplay.maxVisibleCharacters = txt.ToCharArray().Length;
                    terminado = true;
                    break;
                }
            }
            terminado = true;
        }
        else
        {
            TextDisplay.text = txt;
            terminado = true;
            escribiendo = true;
        }
    }
    public void StopTalk()
    {
        TextDisplay.text = "";
        terminado = false;
        escribiendo = false;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
