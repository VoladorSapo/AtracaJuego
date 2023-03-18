using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlayerManager : MonoBehaviour
{
    public bool Player1=false;
    public bool Player2=false;
    public bool Player3=false;
    public bool Player4=false;
    public bool Player5=false;

    void Update(){
        //Por si ocurre algún error se autoselecciona Player1
        if(!Player1 && !Player2 && !Player3 && !Player4 && !Player5){
            Player1=true;
        }
    }
}
