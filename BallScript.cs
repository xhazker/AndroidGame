using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public bool inPlay;
    public float moveSpeed;
    public Transform explosion;
    public GameManager gm;


    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.down * 100);
    }


    void Update() {
        if (gm.gameOver) {
            return;
        }

        if (Input.GetButtonDown("Jump") && !inPlay) {
            inPlay = true;
            rb.AddForce(Vector2.up * moveSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bottom")) {
            Debug.Log("Ball hit the bottom of the screen!");
            gm.GameOver();
            inPlay = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Box")) {
            Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(newExplosion.gameObject, 1f);
            gm.UpdateScore(1);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Line")) {

            Destroy(other.gameObject);
        }
    }
}
