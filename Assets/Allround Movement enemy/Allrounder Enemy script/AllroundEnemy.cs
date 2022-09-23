using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllroundEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private bool groundDetected;
   // [SerializeField]
   // private bool wallDetected;
    [SerializeField]
    private Transform groundPositionChecker;
   // [SerializeField]
  //  private Transform wallPositionChecker;
    [SerializeField]
    private float groundCheckDistance;
    [SerializeField]
    private float wallCheckDistance;
    [SerializeField]
    private LayerMask whatIsGround;
    private bool hasTurned;
    private float addZaxis;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hasTurned = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckGrndOrWall();
    }
    private void FixedUpdate()
    {
        Movement();
    }
    void CheckGrndOrWall()
    {
        groundDetected = Physics2D.Raycast(groundPositionChecker.position, -transform.up,groundCheckDistance, whatIsGround);
       // wallDetected = Physics2D.Raycast(wallPositionChecker.position, transform.right, wallCheckDistance, whatIsGround);

        if (!groundDetected)
        {
            if (hasTurned == false)
            {
                addZaxis -= 90;
                transform.eulerAngles = new Vector3(0, 0, addZaxis);
               
                hasTurned = true;
               
            }
           
        }
        if (groundDetected)
        {
            hasTurned = false;
        }

    }
    void Movement()
    {
        rb.velocity = transform.right * 2;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {


            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundPositionChecker.position, new Vector2(groundPositionChecker.position.x, groundPositionChecker.position.y - groundCheckDistance));
       // Gizmos.DrawLine(wallPositionChecker.position, new Vector2(wallPositionChecker.position.x + wallCheckDistance, wallPositionChecker.position.y)); 
    }
}
