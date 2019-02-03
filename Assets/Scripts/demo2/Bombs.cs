using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs : MonoBehaviour {

    private Vector2 startPos;
    private GameObject bomb;
    private GameObject parent;
    private void Start()
    {
        startPos = transform.position;
        bomb = (GameObject)Resources.Load("Bomb");
        parent = GameObject.Find("Bombs");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle") {
            Destroy(this.gameObject);
            Instantiate(bomb, startPos, new Quaternion(),parent.transform);
        }
    }

}
