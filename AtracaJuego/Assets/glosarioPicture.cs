using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glosarioPicture : MonoBehaviour
{
    [SerializeField] GlosarioEntry _glosario;
    public int pos;
    // Start is called before the first frame update
    void Start()
    {
        _glosario = GetComponentInParent<GlosarioEntry>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        _glosario.showData(pos);
    }
    private void OnMouseExit()
    {
        _glosario.hideData();
    }
}
