using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog
{
    public int character;
    public string txt;
    public int speed;
    public Dialog(string _txt, int _char, int _spd)
    {
        txt = _txt;
        character = _char;
        speed = _spd;
    }
}
