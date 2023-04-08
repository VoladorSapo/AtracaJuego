using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasDisplay : MonoBehaviour
{
    public Color startColor;
    public Color endColor;
    [Range(0,10)]
    float speed=1;
    Renderer ren;
    void Awake()
    {
        ren= GetComponent<Renderer>();
        ren.material.color=startColor;
    }

    void Update()
    {
        ren.material.color = Color.Lerp(startColor,endColor,Mathf.PingPong(Time.time*speed, 1));
    }
}
