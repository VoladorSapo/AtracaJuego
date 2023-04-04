using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public float borde;
    public float speed;
    Grid _grid;
    public float[] limitesx;
    public float[] limitesy;
    // Start is called before the first frame update
    void Start()
    {
        _grid = GameObject.Find("Grid").GetComponent<Grid>();
        //limitesx = new float []{_grid. };
        //limitesy = new float []{ 2, 2 };
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.mousePosition.x > Screen.width - borde)
        {
            transform.position += new Vector3(speed * Time.deltaTime,0);
        }
        if (Input.mousePosition.y > Screen.height - borde)
        {
            transform.position += new Vector3(0,speed * Time.deltaTime);
        }
        if (Input.mousePosition.x < borde)
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0);
        }
        if (Input.mousePosition.y <  borde)
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime);
        }
        if (transform.position.x > limitesx[1])
        {
            transform.position = new Vector3(limitesx[1], transform.position.y, -10);
        }
        if (transform.position.y > limitesy[1])
        {
            transform.position = new Vector3(transform.position.x,limitesy[1], -10);
        }
        if (transform.position.x < limitesx[0])
        {
            transform.position = new Vector3(limitesx[0], transform.position.y, -10);
        } 
        if (transform.position.y < limitesy[0])
        {
            transform.position = new Vector3(transform.position.x, limitesy[0],-10);
        }
    }
}
