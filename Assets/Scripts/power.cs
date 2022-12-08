using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power : MonoBehaviour
{

    public GameObject ball;
    private bool getB = false;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "MoreBalls":
               GameObject a = Instantiate(ball);
                a.transform.position = gameObject.transform.position;
                a.GetComponent<Ball>().Shot(new Vector2(1, 4));
                Destroy(collision.gameObject);
                break;
            case "Longer":
               
                Ball[] balls = gameObject.GetComponentsInChildren<Ball>();

                foreach (Ball b in balls)
                {
                    b.transform.parent= null;
                }
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + 1f, 0.4095f, 1f);
                foreach (Ball b in balls)
                {
                    b.transform.parent = gameObject.transform;
                }
                Destroy(collision.gameObject);
                break;
            case "GetBall":
                getB = true;
                Destroy(collision.gameObject);
                break;
        }

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball" && getB)
        {
            getB = false;
            collision.gameObject.GetComponent<Ball>().getBall(gameObject);
         
        }
    }


}
