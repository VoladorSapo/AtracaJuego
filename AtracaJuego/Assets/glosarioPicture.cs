using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class glosarioPicture : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
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
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("dkfshk");
        _glosario.showData(pos);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("papulince");
        _glosario.hideData();
    }
}
