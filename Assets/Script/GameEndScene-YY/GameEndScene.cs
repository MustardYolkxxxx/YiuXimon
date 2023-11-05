using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndScene : MonoBehaviour
{   public bool player1Win = false;
    public bool Draw = false;
    public GameObject EndPic;
    public Transform player1WinPosition;
    public Transform player2WinPosition;
    public float speed = 1.0f;
    public float delay = 2.0f;
    public Vector3 winScale = new Vector3(1.4f, 1.4f, 1f);
    public Vector3 loseScale = new Vector3(.7f, .7f, 1f);
    public GameObject player1; 
    public GameObject player2; 
    public GameObject player1winText;
    public GameObject player2winText;
    public GameObject drawText;
    public GameObject ScoreText;
    public GameObject DrawButton;
    public bool loadNextSceneED = false;
    public string sceneNameToLoad;

    public Player1ScoreNumber Player1Score;
    public Player2ScoreNumber Player2Score;





    // Start is called before the first frame update
    void Start()
    {
        player1winText.SetActive(false);
        player2winText.SetActive(false);
        drawText.SetActive(false);
        DrawButton.SetActive(false);
        StartCoroutine(DelayedStart());
    }
    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(delay);
        loadNextSceneED = true;
        ScoreText.SetActive(false);
        if(Draw)
        {
            drawText.SetActive(true);
            DrawButton.SetActive(true);

}
StartCoroutine(MoveObject());
    }
    IEnumerator MoveObject()
    {
        while (!Draw) // 只要不是平局就持续运行循环
        {
            // 根据 player1Win 的值来确定目标位置并调整比例
            if (player1Win)
            {
                Vector2 targetPosition = player1WinPosition.position;
                EndPic.transform.position = Vector2.Lerp(EndPic.transform.position, targetPosition, speed * Time.deltaTime);
                player1.transform.localScale = Vector3.Lerp(player1.transform.localScale, winScale, speed * Time.deltaTime);
                player2.transform.localScale = Vector3.Lerp(player2.transform.localScale, loseScale, speed * Time.deltaTime);
                player1winText.SetActive(true);
            }
            else
            {
                Vector2 targetPosition = player2WinPosition.position;
                EndPic.transform.position = Vector2.Lerp(EndPic.transform.position, targetPosition, speed * Time.deltaTime);
                player2.transform.localScale = Vector3.Lerp(player2.transform.localScale, winScale, speed * Time.deltaTime);
                player1.transform.localScale = Vector3.Lerp(player1.transform.localScale, loseScale, speed * Time.deltaTime);
                player2winText.SetActive(true);
            }

            yield return null;
        }
    }

    void Update()
    {
        int P1score = Player1Score.Player1Score;
        int P2score = Player2Score.Player2Score;
        if (P1score > P2score) 
        {
            player1Win = true;
        }
        if(P2score > P1score)
        {
            player1Win = false;
        }
        if (P1score == P2score)
        {
            Draw = true;
        }

            if (loadNextSceneED) 
        {
            if (Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(sceneNameToLoad);
            }
        }

    }
}
