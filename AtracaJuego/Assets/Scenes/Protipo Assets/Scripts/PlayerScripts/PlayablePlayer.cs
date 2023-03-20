using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayablePlayer : PlayerBase
{
    [SerializeField] private int MaxDistance = 5;

        
     public override void Update()
     {
        if (SPM.currentPlayer == teamNumb && SPM.Activated && !moving)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (GC.isWakable(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                {
                    Move(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }

            }
        }
        base.Update();
    }

    void OnMouseDown()
    {
        if (SPM.Activated)
        {
            SPM.ChangePlayer(teamNumb);
        }
    }
}
