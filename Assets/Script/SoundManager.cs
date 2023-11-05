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

    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>();
        press = Resources.Load<AudioClip>("press");
        quit = Resources.Load<AudioClip>("quit");
        home = Resources.Load<AudioClip>("home");
        ready = Resources.Load<AudioClip>("ready");
        confirm = Resources.Load<AudioClip>("confirm");
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


}
