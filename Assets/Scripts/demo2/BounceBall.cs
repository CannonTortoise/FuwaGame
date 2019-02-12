using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BounceBall : MonoBehaviour
{

    const int CoinScore = 5;
    public Transform plank;
    public Vector2 leftVelocity;
    public Vector2 rightVelocity;
    private GameObject ball;
    void Awake()//初始化
    {
        ball = GameObject.FindGameObjectWithTag("Player");
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
            PlayerPrefs.SetInt("score", score);
            GameObject.Find("Score").GetComponent<Text>().text = "Score: " + System.Convert.ToString(score);
        }
        else if (collision.gameObject.tag == "Magnet")
        {
            Destroy(collision.gameObject);
            ToolManager.Instance.GetMagnet();
        }
        else if (collision.gameObject.tag == "Fuel")
        {
            Destroy(collision.gameObject);
            ToolManager.Instance.GetFuel();
        }
        else if (collision.gameObject.tag == "BallScale")
        {
            Destroy(collision.gameObject);
            //GameObject.FindGameObjectWithTag("Player").gameObject.transform.localScale = new Vector3(0.3f, 0.5f, 1.0f);
            ToolManager.Instance.GetBallScale();
        }
        else if (collision.gameObject.tag == "Invincibility")
        {
            Destroy(collision.gameObject);
            ToolManager.Instance.GetInvincibility();
        }
    }

   
    
}