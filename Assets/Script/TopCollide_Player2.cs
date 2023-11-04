using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCollide_Player2 : MonoBehaviour
{
    public Collider2D col;
    //public Rigidbody2D parentRb;
    public Transform parentTrans;
    public Vector2 forceDirect;
    public float initialForce;
    public float force;
    public float forceDownSpeed;

    public float collideTime;
    public bool isCollide;

    public enum CollideState2
    {
        none,
        collide,
        collideBack,
    }

    public CollideState2 currentCollideState;
    // Start is called before the first frame update
    void Start()
    {
        force = initialForce; ;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCollideState == CollideState2.collide)
        {
            StartCoroutine(CollideBack());
        }


        CheckForce();
    }

    IEnumerator CollideBack()
    {
        currentCollideState = CollideState2.collideBack;
        float time = 0;
        while (time < collideTime)
        {
            parentTrans.position = Vector3.Lerp(parentTrans.position, -forceDirect.normalized * force, Time.deltaTime * force);
            yield return null;
            time += Time.deltaTime;
        }
        currentCollideState = CollideState2.none;
    }

    void CheckForce()
    {
        if (force < 0)
        {
            isCollide = false;
            force = initialForce; ;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            
            forceDirect = collision.transform.position - parentTrans.position;
            currentCollideState = CollideState2.collide;
        }
    }
}
