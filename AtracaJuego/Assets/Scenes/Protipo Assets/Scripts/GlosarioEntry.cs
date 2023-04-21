using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlosarioEntry : MonoBehaviour
{
    [SerializeField] int[] Valor;
    [SerializeField] string[] codes;
    [SerializeField] Sprite[] sprites;
    [SerializeField]Sprite interrogacion;
    [SerializeField]Image[] imagenes;
    [SerializeField]GlosarioController glosario;
    // Start is called before the first frame update
    void Awake()
    {
        glosario = GetComponentInParent<GlosarioController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenGlosario()
    {
        for (int i = 0; i < imagenes.Length; i++)
        {
            print(i);
            print(Valor[i]);
            glosario = GetComponentInParent<GlosarioController>();
            print(glosario.name);
            imagenes[i].sprite = glosario.combinaciones[Valor[i]]? sprites[i] : interrogacion;
        }
    }
    public void showData(int num)
    {
        glosario.showExtraData(Valor[num],codes[num],transform.GetSiblingIndex());
    }
    public void hideData()
    {
        glosario.hideExtraData();
    }
}
