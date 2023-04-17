using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlosarioEntry : MonoBehaviour
{
    [SerializeField] int[] Valor;
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
            //glosario = GetComponentInParent<GlosarioController>();
            print(glosario.name);
            imagenes[i].sprite = glosario.combinaciones[Valor[i]]? sprites[i] : interrogacion;
        }
    }
}