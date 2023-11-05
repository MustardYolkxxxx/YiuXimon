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
}
