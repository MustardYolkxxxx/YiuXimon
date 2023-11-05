using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCIrcle : MonoBehaviour
{

    public int score;
    public int count1;
    public int count2;
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

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            if (other.GetComponent<TopRotate_Player1>().rotateSpeed == 0)
            {
                    gameManagerScr.player1Score += score;
                    other.GetComponentInParent<TopMove_Player1>().DestroyThis();
                    //StartCoroutine(CreatePlayer1IE());
                    //count1++;      
               
            }
        }
        if (other.CompareTag("Player2"))
        {

            if (other.GetComponent<TopRotate_Player2>().rotateSpeed == 0)
            {
              
                    gameManagerScr.player2Score += score;
                    other.GetComponentInParent<TopMove_Player2>().DestroyThis();
                    //StartCoroutine(CreatePlayer2IE());
                    //count2++;
                
               
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
