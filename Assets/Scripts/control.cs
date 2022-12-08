using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody2D rb;
    private Vector2 force = new Vector2(2,4);
   public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, 0.0f);
        if(transform.childCount > 0 && Input.GetButtonDown("Jump"))
        {
            Ball[] ball = rb.GetComponentsInChildren<Ball>();
            
            foreach(Ball a in ball)
            {
                a.Shot(force);
            }
          
        }
    }
}
