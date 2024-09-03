using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlataform : MonoBehaviour
{
    public float fallingTime;
    private TargetJoint2D target;
    private BoxCollider2D box;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        box = GetComponent<BoxCollider2D>();
    }

      void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           Invoke("Falling", fallingTime);
        }
    }
    void Falling()
    {
        target.enableCollision = false;
        box.isTrigger = true;
    }
}
