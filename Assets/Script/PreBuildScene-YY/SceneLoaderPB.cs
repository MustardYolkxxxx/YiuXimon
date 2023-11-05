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

        if (returnPressedPB && spacePressedPB)
        {
            StartCoroutine(NextScene());
        }

        if (loadNextScenePB)
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(delay);
        loadNextScenePB = true;
    }
}
