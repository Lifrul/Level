using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeFall : MonoBehaviour
{

    public float speed, dieTime;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //drops the rock downward
        rb.velocity = transform.up * speed * -1;
        //starts the countdown for the rocks destruction
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(dieTime);
        Destroy(gameObject);
    }
}
