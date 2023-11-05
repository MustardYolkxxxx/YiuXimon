using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_Timing : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public float time;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {    
        timeText.text = time.ToString("0");
        time -= Time.deltaTime;

        if (time < 0.2&&count==0)
        {
            StartCoroutine(ChangeScene());
            count++;
        }
    }

    IEnumerator ChangeScene()
    {
        SoundManager.PlayGameOver();
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("GameEnd_Scene");
    }
}
