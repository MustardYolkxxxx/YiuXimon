using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BladeChoose2 : MonoBehaviour
{
    public UI_UIManager uiManagerScr;
    public GameObject[] bladeObjects;
    public int bladeIndex;
    public GameObject mask;
    public GameManager gameManagerScr;

    public Animator readyButtonAni;
    public Animator leftButtonAni;
    public Animator rightButtonAni;
    public enum ChooseState
    {
        choosing,
        finish,
        stop,
    }

    public ChooseState currentChooseState;

    //public Image bladeImage;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScr = FindObjectOfType<GameManager>();
        uiManagerScr = FindObjectOfType<UI_UIManager>();
        //bladeImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentChooseState == ChooseState.choosing)
        {
            PressCheck();
        }
        if (currentChooseState == ChooseState.stop)
        {
            
        }
        else
        {
            CheckSpace();
        }
        //for(int i =0;i < bladeObjects.Length; i++)
        //{
        //    bladeObjects[i].SetActive(i==bladeIndex);
        //}
        mask.SetActive(currentChooseState == ChooseState.finish || currentChooseState == ChooseState.stop);
    }

    void PressCheck()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (bladeIndex == 0)
            {
                leftButtonAni.SetTrigger("press");
            }
            else
            {
                leftButtonAni.SetTrigger("press");
                bladeObjects[bladeIndex].GetComponent<UI_SlideAni>().SlideRightDisappear();
                bladeIndex--;
                bladeObjects[bladeIndex].GetComponent<UI_SlideAni>().SlideLeft();
                //if(bladeIndex> 0)
                //{
                //    bladeObjects[bladeIndex - 1].GetComponent<UI_SlideAni>().SlideLeftDisappear();
                //}

            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (bladeIndex == bladeObjects.Length - 1)
            {
                rightButtonAni.SetTrigger("press");
            }
            else
            {
                rightButtonAni.SetTrigger("press");
                bladeObjects[bladeIndex].GetComponent<UI_SlideAni>().SlideLeftDisappear();
                bladeIndex++;
                bladeObjects[bladeIndex].GetComponent<UI_SlideAni>().SlideRight();
                //if (bladeIndex <bladeObjects.Length-1)
                //{
                //    bladeObjects[bladeIndex - 1].GetComponent<UI_SlideAni>().SlideRightDisappear();
                //}
            }
        }

    }
    public void CheckSpace()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (currentChooseState == ChooseState.choosing)
            {
                uiManagerScr.currentUIState2 = UI_UIManager.UIState.chooseWeight;
                readyButtonAni.SetTrigger("press");
                gameManagerScr.ChangeSpeedDownRate(2, bladeIndex);
                gameManagerScr.ChangeMaxSpeed(2, bladeIndex);
                gameManagerScr.ChangeSpeedUpRate(2, bladeIndex);
                currentChooseState = ChooseState.finish;
            }
            else if (currentChooseState == ChooseState.finish)
            {
                uiManagerScr.currentUIState2 = UI_UIManager.UIState.none;
                readyButtonAni.SetTrigger("press");

                currentChooseState = ChooseState.choosing;
            }
        }
    }
}
