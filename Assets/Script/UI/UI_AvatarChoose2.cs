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
    public enum ChooseState
    {
        choosing,
        finish,
    }

    public ChooseState currentChooseState;
    public GameObject mask;
    //public Image bladeImage;
    // Start is called before the first frame update
    void Start()
    {
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

        mask.SetActive(currentChooseState == ChooseState.finish);
        //for(int i =0;i < bladeObjects.Length; i++)
        //{
        //    bladeObjects[i].SetActive(i==bladeIndex);
        //}

    }

    void PressCheck()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
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

        if (Input.GetKeyDown(KeyCode.Return))
        {
            uiManagerScr.currentUIState2 = UI_UIManager.UIState.chooseBlade;
            readyButtonAni.SetTrigger("press");
            currentChooseState = ChooseState.finish;
        }
    }
}
