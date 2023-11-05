using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    public GameManager manager;
    public int score=10;
    public GameObject destroyEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            Instantiate(destroyEffect,collision.transform.position,Quaternion.identity);
            manager.player2Score += score;
            collision.gameObject.GetComponentInParent<TopMove_Player1>().DestroyThis();
            StartCoroutine(CreatePlayer1IE());
        }

        if (collision.gameObject.CompareTag("Player2"))
        {
            Instantiate(destroyEffect, collision.transform.position, Quaternion.identity);
            manager.player1Score += score;
            collision.gameObject.GetComponentInParent<TopMove_Player2>().DestroyThis();
            StartCoroutine(CreatePlayer2IE());
        }
    }

    IEnumerator CreatePlayer1IE()
    {
        
        yield return new WaitForSeconds(2);
        manager.CreatePlayer1();
    }
    IEnumerator CreatePlayer2IE()
    {
        yield return new WaitForSeconds(2);
        manager.CreatePlayer2();
    }
}
