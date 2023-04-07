using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camaraa : MonoBehaviour
{
    public float speed;
   
    void Start()
    {
        
    }

 
    void Update()
    {
        transform.position += new Vector3(Time.deltaTime*speed,0,0);
    }
}
