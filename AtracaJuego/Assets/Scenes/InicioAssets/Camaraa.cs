using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camaraa : MonoBehaviour
{
   
    void Start()
    {
        
    }

 
    void Update()
    {
        transform.position += new Vector3(Time.deltaTime*3,0,0);
    }
}
