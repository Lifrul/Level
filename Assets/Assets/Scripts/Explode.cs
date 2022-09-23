using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField]
    private float fireSpeed;
 
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * fireSpeed * Time.deltaTime, Space.Self); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, .1f);
    }
}
