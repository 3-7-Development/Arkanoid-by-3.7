using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Shot(Vector2 force)
    {
        transform.parent = null;
        rb.simulated = true;
        rb.velocity = force.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bottom")
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }
}
