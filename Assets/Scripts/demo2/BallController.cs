using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    const int CoinScore = 100;
    const float StartHeight = 0;
    const float EndHeight = 100;
    public Vector2 middleVelocity;
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
        if(Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.L) || Input.GetKeyDown(KeyCode.L) && Input.GetKey(KeyCode.A))
            GetComponent<Rigidbody2D>().velocity = middleVelocity;
        else if (Input.GetKeyDown(KeyCode.A)) 
            GetComponent<Rigidbody2D>().velocity = leftVelocity;
        else if(Input.GetKeyDown(KeyCode.L))
            GetComponent<Rigidbody2D>().velocity = rightVelocity;

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
