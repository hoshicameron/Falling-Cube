using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private float moveSpeed = 10;
   [SerializeField] private GameObject startLabel = null;

   private Rigidbody2D rigidbody2D;
   private AudioSource audioSource;
   private void Start()
   {
      rigidbody2D = GetComponent<Rigidbody2D>();
      audioSource = GetComponent<AudioSource>();

      rigidbody2D.gravityScale = 0;
      rigidbody2D.velocity=Vector2.zero;
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         GameManager.Instance.IsGameRunning = true;
         startLabel.SetActive(false);
         rigidbody2D.gravityScale = 5;
      }
   }

   private void FixedUpdate()
   {
      if(!GameManager.Instance.IsGameRunning)   return;

      float xInput = Input.GetAxis("Horizontal");
      rigidbody2D.velocity=new Vector2(xInput*moveSpeed,rigidbody2D.velocity.y);
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      if(!AudioManager.Instance.IsSoundFxMuted())
         audioSource.Play();
   }
}//Class
