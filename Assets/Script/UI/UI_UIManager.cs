using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_UIManager : MonoBehaviour
{
    public GameObject avatarChooseUI;
    public GameObject bladeChooseUI;
    public GameObject weightChooseUI;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        avatarChooseUI.SetActive(finalUIState == UIState.chooseAvatar);
        bladeChooseUI.SetActive(finalUIState == UIState.chooseBlade);
        weightChooseUI.SetActive(finalUIState == UIState.chooseWeight);
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

    }

    IEnumerator ChangeState()
    {
        if (finalUIState == UIState.chooseWeight)
        {
            currentUIState1 = UIState.none;
            currentUIState2 = UIState.none;
            finalUIState = UIState.gaming;
        }

        if (finalUIState == UIState.chooseBlade)
        {
            currentUIState1 = UIState.none;
            currentUIState2 = UIState.none;
            finalUIState = UIState.chooseWeight;
        }

        if (finalUIState == UIState.chooseAvatar)
        {
            currentUIState1 = UIState.none;
            currentUIState2 = UIState.none;
            finalUIState = UIState.chooseBlade;
        }


        yield return null;
    }
}
