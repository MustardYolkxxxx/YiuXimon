using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderPB : MonoBehaviour
{
    public bool loadNextScenePB = false;
    public string sceneNameToLoad;
    public bool returnPressedPB = false;
    public bool spacePressedPB = false;
    public float delay = 1.0f;
    public int count;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressedPB = true;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            returnPressedPB = true;
        }

        if (returnPressedPB && spacePressedPB && count == 0)
        {
            StartCoroutine(NextScene());
            count++;
        }

        if (loadNextScenePB)
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }

    IEnumerator NextScene()
    {
        SoundManager.PlayconfirmClip();
        yield return new WaitForSeconds(delay);
        loadNextScenePB = true;
    }
}
