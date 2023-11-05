using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_StartTime : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public UI_UIManager uiManagerScr;

    public int time = 3;
    // Start is called before the first frame update
    void Start()
    {
        uiManagerScr = FindObjectOfType<UI_UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartIECountDown()
    {
        StartCoroutine(StartTime());
    }
    IEnumerator StartTime()
    {
        SoundManager.PlayreadyClip2();
        yield return new WaitForSeconds(0.3f);
        timeText.text = time.ToString();
        time = 2;
        yield return new WaitForSeconds(1);
        timeText.text = time.ToString();
        time = 1;
        yield return new WaitForSeconds(1);
        timeText.text = time.ToString();

        yield return new WaitForSeconds(1);
        uiManagerScr.finalUIState = UI_UIManager.UIState.readyGo;
    }
}
