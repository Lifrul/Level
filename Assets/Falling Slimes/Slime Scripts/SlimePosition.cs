using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePosition : MonoBehaviour
{
    //drag the game objects into unity for reference positions. 
    public Transform pos1, pos2, rockOrgn;
    //speed of the spawner's movement
    public float speed;
    //the object that will be created
    public GameObject Rock;
    //current time between shots
    float timeBetweeen;
    //starting time between whots
    public float startTimeBetween;
   
    //the postion the the spawner is moving toward
    Vector3 nextPos;


    // Start is called before the first frame update
    void Start()
    {
        
        timeBetweeen = startTimeBetween;
        nextPos = pos1.position;
    }

    // Update is called once per frame
    void Update()
    {
        // will only drop a rock if timeBetween is 0 and floor is destroyed/null. can delete the second condition if you just want to see the pattern.
        if (timeBetweeen <= 0)
        {
            Instantiate(Rock, rockOrgn.position, rockOrgn.rotation);
            timeBetweeen = startTimeBetween;
        }
        else if (timeBetweeen > 0)
        {
            timeBetweeen -= Time.deltaTime;
        }



        // change is the position of the spawner between each other once it reaches the set position
        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        if(transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    //creates a visual line so that you know where the spawners path is
    private void OnDrawGizmos()
    {
        //Draws a line between our two postions. The positions can be moved wherever you wish by drag them in unity
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
