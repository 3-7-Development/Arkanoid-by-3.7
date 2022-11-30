using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class betterbounce : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D bc;
    private void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ball")
        {
            collision.rigidbody.velocity = new Vector2(1.5f*(collision.transform.position.x - transform.position.x) / bc.bounds.size.x, 1.0f).normalized * collision.rigidbody.velocity.magnitude;
        }
    }
    // Update is called once per frame

}
