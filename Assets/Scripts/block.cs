using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class block : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 1;
    public int points;
    public GameObject[] boost;

    // Particles system
    public ParticleSystem collisionParticleSystem;
    public SpriteRenderer sr;
    public bool once = true;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ball" && once)
        {
            health--;

            if (health <= 0) {
                // Particles
                var em = collisionParticleSystem.emission;
                var dur = collisionParticleSystem.duration;

                em.enabled = true;

                UnityEngine.Debug.Log("Playing Particle");
                collisionParticleSystem.Play();
                UnityEngine.Debug.Log("Played");

                once = false;

                /*var instance = Instantiate(sr, transform.position, transform.rotation);
                Destroy(instance.gameObject, dur);
                Destroy(gameObject);*/

                Destroy(sr);
                //Invoke(nameof(DestroyObj), dur);

                Destroy(gameObject);
                ScoreManager.instance.addPoints(points);

                int score = ScoreManager.instance.getPoints();
                System.Random random = new System.Random();
              
                if(random.Next(100) >= 0)
                {
                    GameObject booster = Instantiate(boost[random.Next(boost.Length)]);
                    booster.transform.position = gameObject.transform.position;
                }


                void DestroyObj()
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
