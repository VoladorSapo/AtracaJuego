using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using System.Linq;
public class cameraMove : MonoBehaviour
{
    public float borde;
    public float speed;
    Grid _grid;
    Camera cam;
    [SerializeField] Tilemap ground;
    public float[] limitesx;
    public float[] limitesy;
    // Start is called before the first frame update
    void Start()
    {
        _grid = GameObject.Find("Grid").GetComponent<Grid>();
        cam = GetComponent<Camera>();
        print(ground.cellBounds);
        limitesx = new float[] { _grid.CellToWorld(ground.cellBounds.min).x + (cam.orthographicSize * Screen.width / Screen.height), _grid.CellToWorld(ground.cellBounds.max).x - (cam.orthographicSize * Screen.width / Screen.height) };
        limitesy = new float[] { _grid.CellToWorld(ground.cellBounds.min).y + cam.orthographicSize, _grid.CellToWorld(ground.cellBounds.max).y - cam.orthographicSize };
        //limitesy = new float []{ 2, 2 };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mousePosition.x > Screen.width - borde)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0);
        }
        if (Input.mousePosition.y > Screen.height - borde)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime);
        }
        if (Input.mousePosition.x < borde)
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0);
        }
        if (Input.mousePosition.y < borde)
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime);
        }
        if (transform.position.x > limitesx[1])
        {
            transform.position = new Vector3(limitesx[1], transform.position.y, -10);
        }
        if (transform.position.y > limitesy[1])
        {
            transform.position = new Vector3(transform.position.x, limitesy[1], -10);
        }
        if (transform.position.x < limitesx[0])
        {
            transform.position = new Vector3(limitesx[0], transform.position.y, -10);
        }
        if (transform.position.y < limitesy[0])
        {
            transform.position = new Vector3(transform.position.x, limitesy[0], -10);
        }
    }
    public void setPosition(Vector3 pos)
    {
        //transform.position = new Vector3(pos.x, pos.y, -10);
    }
}