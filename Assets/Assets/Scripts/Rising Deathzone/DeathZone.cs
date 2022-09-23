using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    
    public Transform pos1, pos2;
    public float platSpeed;
   




    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, pos2.position, platSpeed * Time.deltaTime);

        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
