using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class turnButtonsController : MonoBehaviour
{
    [SerializeField] Button skipButton;
    [SerializeField] Button moveButton;
    [SerializeField] Button outButton;
    [SerializeField] Button attackButton;
    [SerializeField] PlayerBase currentplayer;
    // Start is called before the first frame update
    void Start()
    {
        hideButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showButtons(PlayerBase newplayer, int type,bool canMove,bool canAttack)
    {
        currentplayer = newplayer;
        switch (type)
        {
            case 0:
                moveButton.interactable = false;
                attackButton.interactable = false;
                outButton.interactable = false;
                break;
            case 1:

                moveButton.interactable = false;
                attackButton.interactable = canAttack;
                outButton.interactable = true;
                break;
            case 2:
                moveButton.interactable = canMove;
                attackButton.interactable = false;
                outButton.interactable = true;

                break;
        }
        attackButton.gameObject.SetActive(true);
        moveButton.gameObject.SetActive(true);
        outButton.gameObject.SetActive(true);
        skipButton.gameObject.SetActive(true);
    }
    public void hideButtons()
    {
        attackButton.gameObject.SetActive(false);
        moveButton.gameObject.SetActive(false);
        outButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(false);
    }
    public void pressModeButton(int mode)
    {
        currentplayer.ChangeMapShown(mode);
    }
    public void nextTurn()
    {
        currentplayer.getSPM().endTurn();
        hideButtons();
    }
}
