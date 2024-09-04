using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolim : MonoBehaviour
{
    private Animator anim;
    public float jumpforce;
    void start()
    {
        anim = GetComponent<Animator>();    }
      void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
        anim.SetTrigger("jump");
        }
    }
}
