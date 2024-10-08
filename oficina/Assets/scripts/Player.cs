using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D rig;
    public float JumpForce;
    public bool isJumping;
    public bool doubleJumping;
    private Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }
    private void FixedUpdate(){
        Move();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
        if(Input.GetAxis("Horizontal")> 0f){
        anime.SetBool("walk", true);
        transform.eulerAngles = new Vector3(0f,0f,0f);
        }
          if(Input.GetAxis("Horizontal")< 0f){
        anime.SetBool("walk", true);
        transform.eulerAngles = new Vector3(0f,180f,0f);
        }
         if(Input.GetAxis("Horizontal") == 0f){
        anime.SetBool("walk", false);
        }
    }
    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
         {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            doubleJumping = true;
            anime.SetBool("jump", true);
         }
            else{
                if(doubleJumping){
                     rig.AddForce(new Vector2(0f, JumpForce * 0.9f), ForceMode2D.Impulse);
                     doubleJumping = false;
                     anime.SetBool("jump", false);
                }

            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
           isJumping  = false;
           anime.SetBool("jump", false);
        }
        if(collision.gameObject.tag == "spike")
        {
           GameController.instance.ShowGameOver();
           Destroy(gameObject);
        }
    }
     void OnCollisionExit2D(Collision2D collision)
    {
         if(collision.gameObject.layer == 8)
        {
           isJumping  = true;
        }
    }
}
