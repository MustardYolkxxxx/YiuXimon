using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_AvatarChoose2 : MonoBehaviour
{
    public UI_UIManager uiManagerScr;
    public GameObject[] avatarObjects;
    public int avatarIndex;

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

        if (currentChooseState == ChooseState.stop)
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
            if (avatarIndex == 0)
            {
                leftButtonAni.SetTrigger("press");
            }
            else
            {
                leftButtonAni.SetTrigger("press");
                avatarObjects[avatarIndex].GetComponent<UI_SlideAni>().SlideRightDisappear();
                avatarIndex--;
                avatarObjects[avatarIndex].GetComponent<UI_SlideAni>().SlideLeft();
                //if(bladeIndex> 0)
                //{
                //    bladeObjects[bladeIndex - 1].GetComponent<UI_SlideAni>().SlideLeftDisappear();
                //}

            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SoundManager.PlaypressClip();
            if (avatarIndex == avatarObjects.Length - 1)
            {
                rightButtonAni.SetTrigger("press");
            }
            else
            {
                rightButtonAni.SetTrigger("press");
                avatarObjects[avatarIndex].GetComponent<UI_SlideAni>().SlideLeftDisappear();
                avatarIndex++;
                avatarObjects[avatarIndex].GetComponent<UI_SlideAni>().SlideRight();
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
                uiManagerScr.currentUIState2 = UI_UIManager.UIState.chooseBlade;
                readyButtonAni.SetTrigger("press");
                gameManagerScr.ChangeAvatar(2, avatarIndex);
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
