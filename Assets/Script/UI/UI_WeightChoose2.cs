using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_WeightChoose2 : MonoBehaviour
{
    public UI_UIManager uiManagerScr;
    public GameObject[] weightObjects;
    public int weightIndex;

    public Animator readyButtonAni;
    public Animator leftButtonAni;
    public Animator rightButtonAni;

    public GameManager gameManagerScr;
    public enum ChooseState
    {
        choosing,
        finish,
        stop,
    }

    public ChooseState currentChooseState;
    public GameObject mask;
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
        if(currentChooseState == ChooseState.stop)
        {
            
        }
        else
        {
            CheckSpace();
        }
        
        mask.SetActive(currentChooseState == ChooseState.finish || currentChooseState == ChooseState.stop);
        //for(int i =0;i < bladeObjects.Length; i++)
        //{
        //    bladeObjects[i].SetActive(i==bladeIndex);
        //}

    }

    void PressCheck()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SoundManager.PlaypressClip();
            if (weightIndex == 0)
            {
                leftButtonAni.SetTrigger("press");
            }
            else
            {
                leftButtonAni.SetTrigger("press");
                weightObjects[weightIndex].GetComponent<UI_SlideAni>().SlideRightDisappear();
                weightIndex--;
                weightObjects[weightIndex].GetComponent<UI_SlideAni>().SlideLeft();
                //if(bladeIndex> 0)
                //{
                //    bladeObjects[bladeIndex - 1].GetComponent<UI_SlideAni>().SlideLeftDisappear();
                //}

            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SoundManager.PlaypressClip();
            if (weightIndex == weightObjects.Length - 1)
            {
                rightButtonAni.SetTrigger("press");
            }
            else
            {
                rightButtonAni.SetTrigger("press");
                weightObjects[weightIndex].GetComponent<UI_SlideAni>().SlideLeftDisappear();
                weightIndex++;
                weightObjects[weightIndex].GetComponent<UI_SlideAni>().SlideRight();
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
            SoundManager.PlaypressClip();
            if (currentChooseState == ChooseState.choosing)
            {
                uiManagerScr.currentUIState2 = UI_UIManager.UIState.readyPhase;
                readyButtonAni.SetTrigger("press");
                gameManagerScr.ChangeWeightForce(2, weightIndex);
                gameManagerScr.ChangeWeight(2, weightIndex);
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
