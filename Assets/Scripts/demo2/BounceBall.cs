using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBall : MonoBehaviour {

    public Vector2 leftVelocity;
    public Vector2 rightVelocity;
    private Vector2 m_preVelocity = Vector2.zero;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "lplank")
            GetComponent<Rigidbody2D>().velocity = leftVelocity;
        else if (collision.gameObject.name == "rplank")
            GetComponent<Rigidbody2D>().velocity = rightVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
            Destroy(collision.gameObject);
    }
}
