using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTileList : MonoBehaviour
{
    public List<string> eventlist;
    public List<int> spawnList;
    public void setgame()
    {
        eventlist = new List<string>();
        spawnList = new List<int>();
    }
   
}
