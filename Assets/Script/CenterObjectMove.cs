using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterObjectMove : MonoBehaviour
{
    public TopMove_Player1 player1Scr;
    public TopMove_Player2 player2Scr;

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player1Scr = FindObjectOfType<TopMove_Player1>();
        player2Scr = FindObjectOfType<TopMove_Player2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player1Scr != null && player2Scr != null)
        {
            float x = (player1Scr.transform.position.x + player2Scr.transform.position.x) / 2;
            float y = (player1Scr.transform.position.y + player2Scr.transform.position.y) / 2;
            Vector3 center = new Vector3(x, y, 0);
            transform.position = Vector3.Lerp(transform.position, center, Time.deltaTime * moveSpeed);
        }
    }

    public void FindPlayer()
    {
        if (player1Scr == null)
        {
            player1Scr = FindObjectOfType<TopMove_Player1>();
        }
        if (player2Scr == null)
        {
            player2Scr = FindObjectOfType<TopMove_Player2>();
        }


    }
}
