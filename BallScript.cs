using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed;
    public Transform explosion;
    public GameManager gm;
    public AudioSource jumpSound;
    public AudioSource ExplosionSound;


    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.down * 100);
    }


    void Update() {
        if (gm.gameOver) {
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0f;
            this.transform.position = new Vector3(0, 0, 0);
        } else {
            Debug.Log("START");
            rb.gravityScale = 1.2f;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bottom")) {
            Debug.Log("Ball hit the bottom of the screen!");
            gm.GameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Box")) {
            Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(newExplosion.gameObject, 1f);
            gm.UpdateScore(1);
            Destroy(other.gameObject);
            ExplosionSound.Play();
        }
        if (other.gameObject.CompareTag("Line")) {
            Destroy(other.gameObject);
            jumpSound.Play();
        }
        
    }
}
