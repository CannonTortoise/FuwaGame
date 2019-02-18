using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BounceBallForMali : MonoBehaviour
{

    const int CoinScore = 100;
    const float StartHeight = 0;
    const float EndHeight = 100;
    public Transform plank;
    public Vector2 leftVelocity;
    public Vector2 rightVelocity;
    private GameObject ball;

    void UpdateScore(int score)
    {
        PlayerPrefs.SetInt("score", score);
        GameObject.Find("Score").GetComponent<Text>().text = "Score: " + System.Convert.ToString(score);
    }

    void Awake()//初始化
    {
        ball = GameObject.FindGameObjectWithTag("Player");
        UpdateScore(PlayerPrefs.GetInt("score"));
        GameObject.Find("PlayerName").GetComponent<Text>().text = "Name: " + PlayerPrefs.GetString("player name");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "lplank")
        {
            float contact_posy = collision.contacts[0].point.y;
            if (contact_posy > plank.position.y)
                GetComponent<Rigidbody2D>().velocity = leftVelocity;
        }
        else if (collision.gameObject.name == "rplank")
        {
            float contact_posy = collision.contacts[0].point.y;
            if (contact_posy > plank.position.y)
                GetComponent<Rigidbody2D>().velocity = rightVelocity;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            int score;
            score = PlayerPrefs.GetInt("score") + CoinScore;
            this.UpdateScore(score);
        }

    }



}