using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndScene : MonoBehaviour
{   public bool player1Win = false;
    public bool Draw = true;
    public GameObject EndPic;
    public Transform player1WinPosition;
    public Transform player2WinPosition;
    public float speed = 1.0f;
    public float delay = 2.0f;
    public Vector3 winScale = new Vector3(1.4f, 1.4f, 1f);
    public Vector3 loseScale = new Vector3(.7f, .7f, 1f);
    private Vector3 originalScale; 
    public GameObject player1; 
    public GameObject player2; 
    public GameObject player1winText;
    public GameObject player2winText;
    public GameObject drawText;
    public GameObject ScoreText;



    // Start is called before the first frame update
    void Start()
    {
        player1winText.SetActive(false);
        player2winText.SetActive(false);
        drawText.SetActive(false);
        originalScale = player1.transform.localScale;
        StartCoroutine(DelayedStart());
    }
    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(delay);
        ScoreText.SetActive(false);
        if(Draw)
        {
            drawText.SetActive(true);
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
}
