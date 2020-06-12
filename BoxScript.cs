using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform explosion;
    public Vector2 direction;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        transform.Translate(direction.normalized * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bottom"))
        {
            Transform newExplosion = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(newExplosion.gameObject, 1f);
            Destroy(gameObject);
        }
    }
}
