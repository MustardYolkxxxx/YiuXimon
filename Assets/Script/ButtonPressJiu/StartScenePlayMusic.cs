using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScenePlayMusic : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayStartSound()
    {
        SoundManager.PlaypressClip();
    }

    // Update is called once per frame
    public void PlayQuitSound()
    {
        SoundManager.PlayquitClip();
    }
}
