using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_AvatarChoose1 : MonoBehaviour
{
    public UI_UIManager uiManagerScr;
    public GameObject[] avatarObjects;
    public int avatarIndex;

    public GameObject mask;
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

        mask.SetActive(currentChooseState== ChooseState.finish);

        //for(int i =0;i < bladeObjects.Length; i++)
        //{
        //    bladeObjects[i].SetActive(i==bladeIndex);
        //}

    }

    void PressCheck()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (avatarIndex == 0)
            {

            }
            else
            {
                avatarObjects[avatarIndex].GetComponent<UI_SlideAni>().SlideRightDisappear();
                avatarIndex--;
                avatarObjects[avatarIndex].GetComponent<UI_SlideAni>().SlideLeft();
                //if(bladeIndex> 0)
                //{
                //    bladeObjects[bladeIndex - 1].GetComponent<UI_SlideAni>().SlideLeftDisappear();
                //}

            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (avatarIndex == avatarObjects.Length - 1)
            {

            }
            else
            {
                avatarObjects[avatarIndex].GetComponent<UI_SlideAni>().SlideLeftDisappear();
                avatarIndex++;
                avatarObjects[avatarIndex].GetComponent<UI_SlideAni>().SlideRight();
                //if (bladeIndex <bladeObjects.Length-1)
                //{
                //    bladeObjects[bladeIndex - 1].GetComponent<UI_SlideAni>().SlideRightDisappear();
                //}
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            uiManagerScr.currentUIState1 = UI_UIManager.UIState.chooseBlade;
            currentChooseState = ChooseState.finish;
        }
    }
}
