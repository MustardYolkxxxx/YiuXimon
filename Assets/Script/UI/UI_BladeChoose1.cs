using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BladeChoose1 : MonoBehaviour
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
    }

    public ChooseState currentChooseState;
    //public Image bladeImage;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScr= FindObjectOfType< GameManager >();
        uiManagerScr = FindObjectOfType<UI_UIManager>();
        //bladeImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentChooseState == ChooseState.choosing)
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
        if(Input.GetKeyDown(KeyCode.A)) 
        {
            if(bladeIndex== 0)
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
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (bladeIndex == bladeObjects.Length-1)
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

        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            readyButtonAni.SetTrigger("press");
            uiManagerScr.currentUIState1 = UI_UIManager.UIState.chooseWeight;
            gameManagerScr.ChangeSpeedUpRate(1,bladeIndex);
            gameManagerScr.ChangeMaxSpeed(1,bladeIndex);
            currentChooseState = ChooseState.finish;
        }
    }
}
