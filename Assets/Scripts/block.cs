using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class block : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 1;
    public int points;
    public GameObject[] boost;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ball")
        {
            health--;

            if (health <= 0) { 
                Destroy(gameObject);
                ScoreManager.instance.addPoints(points);

                int score = ScoreManager.instance.getPoints();
                System.Random random = new System.Random();
              
                if(random.Next(100) >= 0)
                {
                    GameObject booster = Instantiate(boost[random.Next(boost.Length)]);
                    booster.transform.position = gameObject.transform.position;
                }
                


            }
        }
    }
}
