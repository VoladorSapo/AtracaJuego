using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    [SerializeField] gameController _gameController;
    public void Awake(){
        _gameController=GameObject.Find("Controller").GetComponent<gameController>();
        Animator anim=this.GetComponent<Animator>();
        //anim.SetBool("Started",false);
        anim.SetBool("Started",true);
    }

    private void Start(){
        /*
        Debug.LogWarning("ijfe"+anim.GetBool("Started"));
        if(!anim.GetBool("Started")){
            
        }else{

        }*/
    }
    public void PassNext(){
        _gameController.loadNext();
    }
}
