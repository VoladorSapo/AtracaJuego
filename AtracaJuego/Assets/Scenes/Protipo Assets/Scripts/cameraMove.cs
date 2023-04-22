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
    private float shakePower, shakeTimeRemaining, shakeFadeTime;
    public float fuerzaVibracion = 0.8f;
    public float tiempoVibracion = 0.4f;    
    Grid _grid;
    Camera cam;
    [SerializeField] Tilemap ground;
    [SerializeField] gameController _gamecontroller;
    Vector3 startpos;
    public float[] limitesx;
    public float[] limitesy;
    // Start is called before the first frame update
    void Start()
    {
        _grid = GameObject.Find("Grid").GetComponent<Grid>();
        ground = GameObject.Find("Ground").GetComponent<Tilemap>();
        _gamecontroller = GameObject.Find("Controller").GetComponent<gameController>();
        cam = GetComponent<Camera>();
        startpos = transform.position;
        print(ground.cellBounds);
        limitesx = new float[] { _grid.CellToWorld(ground.cellBounds.min).x + (cam.orthographicSize * Screen.width / Screen.height), _grid.CellToWorld(ground.cellBounds.max).x - (cam.orthographicSize * Screen.width / Screen.height) };
        limitesy = new float[] { _grid.CellToWorld(ground.cellBounds.min).y + cam.orthographicSize, _grid.CellToWorld(ground.cellBounds.max).y - cam.orthographicSize };
        //limitesy = new float []{ 2, 2 };
    }
    public void setGame()
    {
        transform.position = startpos;
    }
    // Update is called once per frame
    void Update()
    {
        if (_gamecontroller!=null && !_gamecontroller.Pause) {
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
            if (Input.GetKeyDown(KeyCode.K))
            {
                StartShake(tiempoVibracion, fuerzaVibracion);
            }
        }
    }

    private void LateUpdate(){
        if (shakeTimeRemaining > 0){
            shakeTimeRemaining -= Time.deltaTime;

            float xamount = Random.Range(-1f, 1f) * shakePower;
            float yamount = Random.Range(-1f, 1f) * shakePower;

            transform.position += new Vector3(xamount, yamount, 0f);

            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);
        }
    }
    public void setPosition(Vector3 pos)
    {
        //transform.position = new Vector3(pos.x, pos.y, -10);
    }

    public void StartShake(float length, float power){

        shakeTimeRemaining = length;
        shakePower = power;

        shakeFadeTime = power / length;
    }
}