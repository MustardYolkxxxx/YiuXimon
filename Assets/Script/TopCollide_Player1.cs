using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCollide_Player1 : MonoBehaviour
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

    public float targetRotateSpeed;

    public float maxControlForce;
    public float originControlForce=1;
    public float controlForce;

    public TopMove_Player1 moveScr;

    public GameManager gameManagerScr;

    public GameObject hitEffect;
    public enum CollideState
    {
        none,
        collide,
        collideBack,
    }

    public CollideState currentCollideState;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScr = FindObjectOfType<GameManager>();
        controlForce = originControlForce;
        force = initialForce; ;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCollideState == CollideState.collide)
        {
           StartCoroutine(CollideBack());
        }
        maxControlForce = gameManagerScr.weightForce1;
        controlForce = originControlForce + maxControlForce;

        force = initialForce - gameManagerScr.weightForce1 / 5;
        CheckForce();
    }

    IEnumerator CollideBack()
    {
        currentCollideState= CollideState.collideBack;
        float time = 0;
        while (time<collideTime)
        {
            Vector3 targetPos = new Vector3( parentTrans.position.x - (targetRotateSpeed / controlForce) * forceDirect.normalized.x, 
                parentTrans.position.y - (targetRotateSpeed / controlForce)*forceDirect.normalized.y,0);
            parentTrans.position = Vector3.Lerp(parentTrans.position, targetPos , Time.deltaTime * force);
            //parentTrans.position = Vector3.Lerp(parentTrans.position, -forceDirect.normalized * (targetRotateSpeed/controlForce), Time.deltaTime * force);
            Debug.Log("Player1"+-forceDirect.normalized * (targetRotateSpeed / controlForce));
            yield return null;
            time += Time.deltaTime;
        }
        moveScr.currentMoveSpeed = 0;
        moveScr.currentMoveSpeedHorizontal= 0;
        currentCollideState = CollideState.none;
    }

    void CheckForce()
    {
        if(force<0)
        {
            isCollide = false;
            force = initialForce;;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player2"))
        {

            SoundManager.PlayFightClip();
            Instantiate(hitEffect, collision.transform.position, Quaternion.identity);
            forceDirect = collision.transform.position-parentTrans.position;
            targetRotateSpeed = collision.gameObject.GetComponent<TopRotate_Player2>().rotateSpeed;
            currentCollideState = CollideState.collide;
        }
    }
}
