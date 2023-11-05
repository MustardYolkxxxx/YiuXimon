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

    public UI_AvatarChoose1 avatarChooseUI1;
    public UI_AvatarChoose2 avatarChooseUI2;

    public UI_BladeChoose1 bladeChooseUI1;
    public UI_BladeChoose2 bladeChooseUI2;

    public UI_WeightChoose1 weightChooseUI1;
    public UI_WeightChoose2 weightChooseUI2;

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
            avatarChooseUI1.currentChooseState = UI_AvatarChoose1.ChooseState.stop;
            avatarChooseUI2.currentChooseState = UI_AvatarChoose2.ChooseState.stop;
            StartCoroutine(ChangeState());
        }
        if (currentUIState1 == UIState.chooseWeight && currentUIState2 == UIState.chooseWeight)
        {
            bladeChooseUI1.currentChooseState = UI_BladeChoose1.ChooseState.stop;
            bladeChooseUI2.currentChooseState = UI_BladeChoose2.ChooseState.stop;
            StartCoroutine(ChangeState());
        }
        if (currentUIState1 == UIState.readyPhase && currentUIState2 == UIState.readyPhase)
        {
            weightChooseUI1.currentChooseState = UI_WeightChoose1.ChooseState.stop;
            weightChooseUI2.currentChooseState = UI_WeightChoose2.ChooseState.stop;
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
            finalUIState = UIState.startLogo;
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
