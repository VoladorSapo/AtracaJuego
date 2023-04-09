using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public void PressButton()
    {
        SceneManager.LoadScene(1);
    }
}
