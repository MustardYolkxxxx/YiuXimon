using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_FightReady : MonoBehaviour
{
    public UI_UIManager uiManagerScr;

    public Animator animator1;
    public Animator animator2;
    public enum ChooseState
    {
        choosing,
        finish,
        stop,
    }

    public ChooseState currentChooseState1;
    public ChooseState currentChooseState2;

    public int index;
    public int musicCount;
    // Start is called before the first frame update
    void Start()
    {
        uiManagerScr = FindObjectOfType<UI_UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (index == 1)
        {
            if (currentChooseState1 == ChooseState.stop)
            {
                if (musicCount == 0)
                {
                    SoundManager.PlayconfirmClip();
                    musicCount++;
                }
            }
            else
            {
                CheckPress();
            }
        }
        if (index == 2)
        {
            if (currentChooseState2 == ChooseState.stop)
            {

            }
            else
            {
                CheckPress();
            }
        }
    }

    public void CheckPress()
    {
        if (index == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SoundManager.PlaypressClip();
                if (currentChooseState1 == ChooseState.choosing)
                {
                    uiManagerScr.currentUIState1 = UI_UIManager.UIState.tutorial;
                    animator1.SetTrigger("press");
                    currentChooseState1 = ChooseState.finish;
                }
                else if (currentChooseState1 == ChooseState.finish)
                {
                    uiManagerScr.currentUIState1 = UI_UIManager.UIState.none;
                    animator1.SetTrigger("press");
                    currentChooseState1 = ChooseState.choosing;
                }
            }
        }

        if (index == 2)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SoundManager.PlaypressClip();
                if (currentChooseState2 == ChooseState.choosing)
                {
                    uiManagerScr.currentUIState2 = UI_UIManager.UIState.tutorial;
                    animator2.SetTrigger("press");
                    currentChooseState2 = ChooseState.finish;
                }
                else if (currentChooseState2 == ChooseState.finish)
                {
                    uiManagerScr.currentUIState2 = UI_UIManager.UIState.none;
                    animator2.SetTrigger("press");
                    currentChooseState2 = ChooseState.choosing;
                }
            }

        }

    }


    
}
