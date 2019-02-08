using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour {

    public float speed = 1;
    private int moveDir = -1;
    private Vector2 nextPos;

    private void Start()
    {
        nextPos = transform.position;
    }

    private void Update()
    {
        nextPos.x = Time.deltaTime * speed * moveDir + nextPos.x;
        transform.position = nextPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle") {
            moveDir = -moveDir;
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        }
    }
}
