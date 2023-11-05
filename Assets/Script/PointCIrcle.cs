using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCIrcle : MonoBehaviour
{
    public int score;
    public int count1;
    public int count2;
    public float stayTime1;
    public float stayTime2;

    public GameManager gameManagerScr; 
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScr = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            if (collision.GetComponent<TopRotate_Player1>().rotateSpeed == 0)
            {
                stayTime1 += Time.deltaTime;
                
                //StartCoroutine(CreatePlayer1IE());
                //count1++;      
            }
            else
            {
                stayTime1 = 0;
            }

            if(stayTime1>1)
            {
                gameManagerScr.player1Score += score;
                gameManagerScr.player2Score -= 10;
                collision.GetComponentInParent<TopMove_Player1>().DestroyThis();
            }
        }
        if (collision.CompareTag("Player2"))
        {

            if (collision.GetComponent<TopRotate_Player2>().rotateSpeed == 0)
            {
                stayTime2 += Time.deltaTime;
                
                //StartCoroutine(CreatePlayer2IE());
                //count2++;
            }
            else
            {
                stayTime2 = 0;
            }

            if (stayTime2 > 1)
            {
                gameManagerScr.player2Score += score;
                gameManagerScr.player1Score -= 10;
                
                collision.GetComponentInParent<TopMove_Player2>().DestroyThis();
            }

        }
    }

    
    IEnumerator CreatePlayer1IE()
    {

        yield return new WaitForSeconds(2);
        count1= 0;
        gameManagerScr.CreatePlayer1();
    }
    IEnumerator CreatePlayer2IE()
    {
        yield return new WaitForSeconds(2);
        count2= 0;
        gameManagerScr.CreatePlayer2();
    }
}
