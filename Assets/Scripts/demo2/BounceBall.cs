using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BounceBall : MonoBehaviour
{

    const int CoinScore = 100;
    const float StartHeight = 0;
    const float EndHeight = 100;
    public Transform plank;
    public float verticalVelocity;
    public float horizontalVelocity;
    private GameObject ball;

    void UpdateScore(int score)
    {
        PlayerPrefs.SetInt("score", score);
        GameObject.Find("Score").GetComponent<Text>().text = "Score: " + System.Convert.ToString(score);
    }

    void Awake()//初始化
    {
        ball = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        int height = (int)((GameObject.Find("Ball").GetComponent<Transform>().position.y - StartHeight) * 100);
        int max_height = PlayerPrefs.GetInt("max height");
        if (max_height < height)
        {
            int score = PlayerPrefs.GetInt("score") + height - max_height;
            this.UpdateScore(score);
            PlayerPrefs.SetInt("max height", height);
            GameObject.Find("Height").GetComponent<Text>().text = "Height: " + System.Convert.ToString(height);
            float percent = (GameObject.Find("Ball").GetComponent<Transform>().position.y - StartHeight) / (EndHeight - StartHeight);
            GameObject.Find("HeightSlider").GetComponent<Slider>().value = percent;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "lplank")
        {
            
            Vector2 leftVelocity = new Vector2(-horizontalVelocity, verticalVelocity);
            
            float contact_posy = collision.contacts[0].point.y;
            if (contact_posy > plank.position.y)
                GetComponent<Rigidbody2D>().velocity = leftVelocity;
        }
        else if (collision.gameObject.name == "rplank")
        {
            Vector2 rightVelocity = new Vector2(horizontalVelocity, verticalVelocity);
            float contact_posy = collision.contacts[0].point.y;
            if (contact_posy > plank.position.y)
                GetComponent<Rigidbody2D>().velocity = rightVelocity;
        }
        else if (collision.gameObject.name == "mplank")
        {
            Vector2 midVelocity = new Vector2(0, verticalVelocity);
            float contact_posy = collision.contacts[0].point.y;
            if (contact_posy > plank.position.y)
                GetComponent<Rigidbody2D>().velocity = midVelocity;
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
        else if (collision.gameObject.tag == "BombBall")
        {
            Destroy(collision.gameObject);
            ToolManager.Instance.GetBombBall();
        }
    }

   
    
}