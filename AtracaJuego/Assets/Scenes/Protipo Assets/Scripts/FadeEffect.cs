using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    [SerializeField] gameController _gameController;
    public void Awake(){
        _gameController=GameObject.Find("Controller").GetComponent<gameController>();
    }
    public void PassNext(){
        _gameController.loadNext();
    }
}
