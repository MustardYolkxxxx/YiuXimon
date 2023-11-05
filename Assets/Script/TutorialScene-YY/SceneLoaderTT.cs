using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderTT : MonoBehaviour
{
    public bool loadNextSceneTT = false;
    public string sceneNameToLoad;
    public bool returnPressedTT = false;
    public bool spacePressedTT = false;
    public float delay = 1.0f;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressedTT = true;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            returnPressedTT = true;
        }

        if (returnPressedTT || spacePressedTT)
        {
            StartCoroutine(NextScene());
        }

        if (loadNextSceneTT)
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(delay);
        loadNextSceneTT = true;
    }
}
