using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TutorialConfirm : MonoBehaviour
{
    public UI_UIManager uiManagerScr;
    public Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        uiManagerScr = FindObjectOfType<UI_UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.Return)) 
        {
            SoundManager.PlayconfirmClip();
            ani.SetTrigger("press");
            uiManagerScr.finalUIState = UI_UIManager.UIState.startLogo;
        }
    }
}
