using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderSS : MonoBehaviour
{
    public string sceneNameToLoad;
    
    public void gamePlay()
    {
        SceneManager.LoadScene(sceneNameToLoad);
    }

    public void gameQuit()
    {
       Application.Quit();
    }
}
