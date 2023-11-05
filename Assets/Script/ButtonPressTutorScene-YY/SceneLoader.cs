using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public bool loadNextScene = false;
    public string sceneNameToLoad;
    public bool returnPressed = false;
    public bool spacePressed = false;
    public float delay = 1.0f;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressed = true;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            returnPressed = true;
        }

        if(returnPressed&&spacePressed) 
        {
            StartCoroutine(NextScene());
        }

        if (loadNextScene) 
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(delay);
        loadNextScene= true;
    }
}
