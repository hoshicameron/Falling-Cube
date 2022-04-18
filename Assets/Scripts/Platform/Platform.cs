using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float boundY = 6.0f;
    [SerializeField] private float force = 100f;
    [SerializeField] private bool movingPlatformLeft, movingPlatformRight, isBreakable, isSpike, isPlatform;

    private Animator anim = null;
    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        if (isBreakable) anim = GetComponent<Animator>();
    }

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(GameManager.Instance.IsGameRunning)
            Move();
    }

    private void Move()
    {
        rigidbody2D.MovePosition(rigidbody2D.position+Vector2.up * moveSpeed*Time.fixedDeltaTime);

        if(rigidbody2D.position.y>boundY)
            gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(isBreakable)
            anim.SetTrigger("Break");
    }

    private void OnCollisionStay2D(Collision2D other)
    {

        var body = other.gameObject.GetComponent<Rigidbody2D>();
        if (movingPlatformLeft)
        {
            body.AddForce(Vector2.left*force);
        }
        else if (movingPlatformRight)
        {
            body.AddForce(Vector2.right*force);
        }
    }

    public void DisableGameObject()
    {
        gameObject.SetActive(false);
        GetComponent<AudioSource>().Play();
    }
}//Class
