using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackGoundMusic : MonoBehaviour
{

    public AudioSource audioSourceBack;
    // Start is called before the first frame update
    void Start()
    {
        audioSourceBack = GameObject.Find("BackGroundSound").GetComponent<AudioSource>();
        StartCoroutine(ChangeBackMusic());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeBackMusic()
    {
        yield return new WaitForSeconds(1);
        audioSourceBack.clip = SoundManager.gameEndBGM;
        audioSourceBack.Play();
    }


}
