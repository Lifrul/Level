using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    public float speed;
    public float slimeImpact;
    Vector2 lastVelocity;

    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.y < 0f)
        {
            rb.velocity += Vector2.up   * -speed;
        }

        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            anim.SetBool("isFalling", false);
        }
        var direction = lastVelocity.normalized;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Slime")
        {
            var curSpeed = lastVelocity.magnitude;
            var direction = lastVelocity.normalized;
            rb.velocity = direction * Mathf.Max(curSpeed / slimeImpact, 0f);
        }
    }
}
