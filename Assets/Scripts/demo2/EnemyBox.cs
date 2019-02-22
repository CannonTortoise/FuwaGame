using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBox : MonoBehaviour
{

    public GameObject enemy;

    // Use this for initialization
    void Start()
    {
        enemy.SetActive(false);
        bool enemyvisible = false;
        //GameObject coin = (GameObject)Resources.Load("Resources/Coin");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 speed = GameObject.Find("Ball").GetComponent<Rigidbody2D>().velocity;
        if (speed.y > 0)
            enemy.SetActive(true);
    }

}
