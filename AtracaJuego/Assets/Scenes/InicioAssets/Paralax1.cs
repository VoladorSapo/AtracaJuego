using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax1 : MonoBehaviour {
    
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;
    private float run = 0;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    void FixedUpdate()
    {
        
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, (float)13.833, transform.position.z);
        transform.position += new Vector3(run, 0, 0);
        run += 1/8;
        
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
 
    }
}
