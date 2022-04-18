using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private float moveSpeed = 10;
   [SerializeField] private GameObject startLabel = null;
   [SerializeField] private bool touchControl = false;

   private Rigidbody2D rigidbody2D;
   private AudioSource audioSource;
   private float xInput;
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
         StartGame();
      }
   }

   public void StartGame()
   {
      GameManager.Instance.IsGameRunning = true;
      startLabel.SetActive(false);
      rigidbody2D.gravityScale = 5;
   }

   private void FixedUpdate()
   {
      if(!GameManager.Instance.IsGameRunning)   return;

      if (!touchControl)
      {
         xInput = Input.GetAxis("Horizontal");
         rigidbody2D.velocity = new Vector2(xInput * moveSpeed, rigidbody2D.velocity.y);
      } else
      {
         rigidbody2D.velocity = new Vector2(xInput * moveSpeed, rigidbody2D.velocity.y);
      }
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      if(!AudioManager.Instance.IsSoundFxMuted())
         audioSource.Play();
   }

   public void BeginTouchLeft()
   {
      print("BeginLeft");
      xInput = -1;
   }

   public void EndTouchLeft()
   {
      print("EndLeft");
      xInput = 0;
   }

   public void BeginTouchRight()
   {
      print("BeginRight");
      xInput = 1;
   }

   public void EndTouchRight()
   {
      print("EndRight");
      xInput = 0;
   }

}//Class
