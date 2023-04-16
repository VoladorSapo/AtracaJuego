using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        //pauseMenu = this.gameObject;
        pauseMenu = GameObject.Find("PauseMenu");
        print("helou helou" + name);
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale > 0)
            {
                Pausar();
            }
            else
            {
                DesPausar();
            }
        }
    }
    public void Pausar()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
    public void DesPausar()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);

    }
}
