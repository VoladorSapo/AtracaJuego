using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class turnButtonsController : MonoBehaviour
{
    [SerializeField] Button skipButton;
    [SerializeField] Button moveButton;
    [SerializeField] Button outButton;
    [SerializeField] Button attackButton;
    [SerializeField] GameObject skipConfirm;
    [SerializeField] PlayablePlayer currentplayer;

    private PlayablePlayer[] allPlayers;

    // Start is called before the first frame update
    void Start()
    {
        hideButtons();
        Skip(false);
        allPlayers=FindObjectsOfType<PlayablePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showButtons(PlayablePlayer newplayer, int type,bool canMove,bool canAttack)
    {
        print("heybghh");

        currentplayer = newplayer;
        switch (type)
        {
            case 0:
                moveButton.interactable = false;
                attackButton.interactable = false;
                attackButton.transform.GetChild(0).gameObject.SetActive(false);
                outButton.interactable = false;
                break;
            case 1:

                moveButton.interactable = false;
                attackButton.interactable = !newplayer.getAttack();
                attackButton.transform.GetChild(0).gameObject.SetActive(false);
                if (currentplayer.Cooldown > 0)
                {
                    attackButton.transform.GetChild(0).gameObject.SetActive(true);
                    attackButton.GetComponentInChildren<TMP_Text>().text = currentplayer.Cooldown.ToString();
                }
                outButton.interactable = true;
                break;
            case 2:
                print("heybaby");
                moveButton.interactable = !newplayer.getMove();
                attackButton.interactable = false;
                if(currentplayer.Cooldown > 0)
                {
                    attackButton.transform.GetChild(0).gameObject.SetActive(true);
                    attackButton.GetComponentInChildren<TMP_Text>().text = currentplayer.Cooldown.ToString();
                }
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
        print("hakunamatata");
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
        hideButtons();
        Skip(false);
        currentplayer.getSPM().endTurn();
    }
    public void Skip(bool show)
    {
        
        skipConfirm.SetActive(show);
        if(currentplayer!=null){currentplayer.ChangeMapShown(0);}
        
    }
}
