using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_UIManager : MonoBehaviour
{
    public GameObject avatarChooseUI;
    public GameObject bladeChooseUI;
    public GameObject weightChooseUI;
    public GameObject fightReadyUI;
    public GameObject tutorialUI;
    public GameObject startLogoUI;
    public GameObject gamingInfoUI;

    public GameObject player1;
    public GameObject player2;
    

    public GameManager gameManagerScr;

    public UI_AvatarChoose1 avatarChooseUI1;
    public UI_AvatarChoose2 avatarChooseUI2;

    public UI_BladeChoose1 bladeChooseUI1;
    public UI_BladeChoose2 bladeChooseUI2;

    public UI_WeightChoose1 weightChooseUI1;
    public UI_WeightChoose2 weightChooseUI2;

    public UI_FightReady fightReadyUI1;
    public UI_FightReady figntReadyUI2;

    public UI_StartTime startTimeScr;

    public int count;
    
    public enum UIState
    {
        none,
        chooseAvatar,
        chooseBlade,     
        chooseWeight,
        readyPhase,
        tutorial,
        startLogo,
        readyGo,
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
        fightReadyUI.SetActive(finalUIState == UIState.readyPhase);
        tutorialUI.SetActive(finalUIState == UIState.tutorial);
        startLogoUI.SetActive(finalUIState == UIState.startLogo);
        gamingInfoUI.SetActive(finalUIState == UIState.gaming);

        //if (player1 != null && player2 != null)
        //{
        //    player1.SetActive(finalUIState == UIState.gaming);
        //    player2.SetActive(finalUIState == UIState.gaming);
        //}
        if (finalUIState == UIState.readyGo)
        {
            StartCoroutine(StartGame());
        }


        //weightChooseUI.SetActive(finalUIState == UIState.chooseWeight);
        ChangeCurrentState();
    }

    void ChangeCurrentState()
    {
        if (currentUIState1 == UIState.chooseBlade && currentUIState2 == UIState.chooseBlade)
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
        if (currentUIState1 == UIState.tutorial && currentUIState2 == UIState.tutorial)
        {
            fightReadyUI1.currentChooseState1 = UI_FightReady.ChooseState.stop;
            figntReadyUI2.currentChooseState2 = UI_FightReady.ChooseState.stop;
            StartCoroutine(ChangeState());
        }

        if (finalUIState == UIState.startLogo && count == 0)
        {
            startTimeScr.StartIECountDown();
            count++;
        }
    }


    IEnumerator StartGame()
    {
        finalUIState = UIState.gaming;
        yield return null;
        //gameManagerScr.ChangeSceneBloom(0.6f);
        gameManagerScr.CreatePlayer1();
        gameManagerScr.CreatePlayer2();
        
    }
    IEnumerator ChangeState()
    {
        if (finalUIState == UIState.readyPhase)
        {
            currentUIState1 = UIState.none;
            currentUIState2 = UIState.none;

            yield return new WaitForSeconds(1);
            finalUIState = UIState.tutorial;
        }
        if (finalUIState == UIState.chooseWeight)
        {
            currentUIState1 = UIState.none;
            currentUIState2 = UIState.none;

            yield return new WaitForSeconds(1);
            finalUIState = UIState.readyPhase;
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
