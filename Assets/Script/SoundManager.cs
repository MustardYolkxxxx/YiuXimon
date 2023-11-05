using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class   SoundManager : MonoBehaviour
{
    public static AudioSource audioSource;
    public static AudioClip press;
    public static AudioClip quit;
    public static AudioClip home;
    public static AudioClip ready;
    public static AudioClip confirm;
    public static AudioClip countdown;
    public static AudioClip timeOut;
    public static AudioClip press2;
    public static AudioClip fight;
    public static AudioClip rotate;

    public static AudioClip battleBGM;
    public static AudioClip gameEndBGM;
    public void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        press = Resources.Load<AudioClip>("press");
        quit = Resources.Load<AudioClip>("quit");
        home = Resources.Load<AudioClip>("home");
        ready = Resources.Load<AudioClip>("ready");
        confirm = Resources.Load<AudioClip>("confirm");
        countdown = Resources.Load<AudioClip>("countdown");
        timeOut = Resources.Load<AudioClip>("TimeUp");
        press2 = Resources.Load<AudioClip>("pressO");
        fight=Resources.Load<AudioClip>("fight");
        battleBGM = Resources.Load<AudioClip>("battle");
        gameEndBGM = Resources.Load<AudioClip>("score");
        rotate = Resources.Load<AudioClip>("rotate2");
    }

    public static void PlaypressClip()
    {
        audioSource.PlayOneShot(press);
    }

    public static void PlayquitClip()
    {
        audioSource.PlayOneShot(quit);
    }

    public static void PlayhomeClip()
    {
        audioSource.PlayOneShot(home);
    }

    public static void PlayreadyClip()
    {
        audioSource.PlayOneShot(ready);
    }

    public static void PlayconfirmClip()
    {
        audioSource.PlayOneShot(confirm);
    }

    public static void PlayreadyClip2()
    {
        audioSource.PlayOneShot(countdown);
    }

    public static void PlayGameOver()
    {
        audioSource.PlayOneShot(timeOut);
    }
    public static void PlayPressClip2()
    {
        audioSource.PlayOneShot(press2);
    }

    public static void PlayFightClip()
    {
        audioSource.PlayOneShot(fight);
    }

    public static void PlayRotateClip()
    {
        audioSource.PlayOneShot(rotate);
    }
}
