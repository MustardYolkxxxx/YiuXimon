using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_UIManager : MonoBehaviour
{
    public GameObject avatarChooseUI;
    public GameObject bladeChooseUI;
    public GameObject weightChooseUI;

    public GameObject player1;
    public GameObject player2;

    public GameManager gameManagerScr;
    public enum UIState
    {
        none,
        chooseAvatar,
        chooseBlade,     
        chooseWeight,
        readyPhase,
        startLogo,
        gaming,
        gameover,
    }

    public UIState currentUIState1;
    public UIState currentUIState2;
    public UIState finalUIState;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScr = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        avatarChooseUI.SetActive(finalUIState == UIState.chooseAvatar);
        bladeChooseUI.SetActive(finalUIState == UIState.chooseBlade);
        weightChooseUI.SetActive(finalUIState == UIState.chooseWeight);

        //if (player1 != null && player2 != null)
        //{
        //    player1.SetActive(finalUIState == UIState.gaming);
        //    player2.SetActive(finalUIState == UIState.gaming);
        //}
        if (finalUIState == UIState.startLogo)
        {
            StartCoroutine(StartGame());
        }
            //weightChooseUI.SetActive(finalUIState == UIState.chooseWeight);
            ChangeCurrentState();
    }
    
    void ChangeCurrentState()
    {
        if(currentUIState1== UIState.chooseBlade&& currentUIState2 == UIState.chooseBlade)
        {
            StartCoroutine(ChangeState());
        }
        if (currentUIState1 == UIState.chooseWeight && currentUIState2 == UIState.chooseWeight)
        {
            StartCoroutine(ChangeState());
        }
        if (currentUIState1 == UIState.readyPhase && currentUIState2 == UIState.readyPhase)
        {
            StartCoroutine(ChangeState());
        }

    }
    IEnumerator StartGame()
    {
        finalUIState = UIState.gaming;
        yield return null;
        gameManagerScr.CreatePlayer1();
        gameManagerScr.CreatePlayer2();
        
    }
    IEnumerator ChangeState()
    {
        if (finalUIState == UIState.chooseWeight)
        {
            currentUIState1 = UIState.none;
            currentUIState2 = UIState.none;

            yield return new WaitForSeconds(1);
            finalUIState = UIState.gaming;
        }

        if (finalUIState == UIState.chooseBlade)
        {
            currentUIState1 = UIState.none;
            currentUIState2 = UIState.none;
            yield return new WaitForSeconds(1);
            finalUIState = UIState.chooseWeight;
        }

        if (finalUIState == UIState.chooseAvatar)
        {
            currentUIState1 = UIState.none;
            currentUIState2 = UIState.none;
            yield return new WaitForSeconds(1);
            finalUIState = UIState.chooseBlade;
        }


        yield return null;
    }
}
