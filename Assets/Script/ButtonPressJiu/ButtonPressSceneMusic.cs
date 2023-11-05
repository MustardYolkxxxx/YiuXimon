using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressSceneMusic : MonoBehaviour
{
    // Start is called before the first frame update
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
        SoundManager.PlaypressClip();
        }   
    }

}
