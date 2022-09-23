using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leaper : MonoBehaviour
{
    bool isTriggered;
    public float speed;
    public float launchX;
    public float launchY;
    public float xDirection;
    public Rigidbody2D rb;
    Vector2 lastVelocity;

    // Start is called before the first frame update
    void Start()
    {
        isTriggered = false;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        var direction = transform.right * launchX + Vector3.up * launchY;
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.tag == "Player" && isTriggered == false)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            var direction = transform.right*launchX*xDirection + Vector3.up * launchY;
            GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
            
                
                isTriggered = true;
        }

       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
          
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        if (collision.gameObject.tag == "Wall")
        {
            var curSpeed = lastVelocity.magnitude;
             var direction = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
          
             rb.velocity = direction * Mathf.Max(curSpeed/4, 0f);
           
        }

    }

   
}
