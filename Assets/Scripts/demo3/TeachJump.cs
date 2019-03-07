using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeachJump : MonoBehaviour
{
    const string spritePath = "Sprites\\";
    private Sprite idlesprite;
    private SpriteRenderer sr;
    public float jumpshowTime = 0.2f;


    public float verticalVelocity;
    public float horizontalVelocity;
    public Color pressColor;
    public int stepIncrement;
    public int coinIncrement;

    //三种跳跃的速度
    private Vector2 midVelocity;
    private Vector2 leftVelocity;
    private Vector2 rightVelocity;

    //三种跳跃的次数
    private int lstep;
    private int mstep;
    private int rstep;
    private Text ltext;
    private Text mtext;
    private Text rtext;

    //三种跳跃的按钮
    private Image lbutton;
    private Image mbutton;
    private Image rbutton;

    private LevelController lc;
    //音效
    //public AudioSource hei;  //音效“嘿”

    private ParticleSystem lexplodeFX;
    private ParticleSystem mexplodeFX;
    private ParticleSystem rexplodeFX;
    

    void Awake()
    {
        Time.timeScale = 1;
        lstep = 99;
        mstep = 99;
        rstep = 99;
        ltext = GameObject.Find("LText").GetComponent<Text>();
        mtext = GameObject.Find("MText").GetComponent<Text>();
        rtext = GameObject.Find("RText").GetComponent<Text>();
        lbutton = GameObject.Find("LButton").GetComponent<Image>();
        mbutton = GameObject.Find("MButton").GetComponent<Image>();
        rbutton = GameObject.Find("RButton").GetComponent<Image>();
        leftVelocity = new Vector2(-horizontalVelocity, verticalVelocity);
        midVelocity = new Vector2(0, verticalVelocity);
        rightVelocity = new Vector2(horizontalVelocity, verticalVelocity);
        lc = GameObject.Find("Controller").GetComponent<LevelController>();
        sr = gameObject.transform.GetComponent<SpriteRenderer>();
        idlesprite = Resources.Load("turtle", typeof(Sprite)) as Sprite;
        sr.sprite = idlesprite;
        lexplodeFX = GameObject.Find("LExplodeFX").GetComponentInChildren<ParticleSystem>();
        lexplodeFX.Stop();
        mexplodeFX = GameObject.Find("MExplodeFX").GetComponentInChildren<ParticleSystem>();
        mexplodeFX.Stop();
        rexplodeFX = GameObject.Find("RExplodeFX").GetComponentInChildren<ParticleSystem>();
        rexplodeFX.Stop();
    }

    private void ResetIdleSprite()
    {
        sr.sprite = idlesprite;
    }


    void Update()
    {
        ltext.text = lstep.ToString();
        mtext.text = mstep.ToString();
        rtext.text = rstep.ToString();


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            mbutton.color = pressColor;
            if (mstep > 0)
            {
                mexplodeFX.Play();
                mstep--;
                GetComponent<Rigidbody2D>().velocity = midVelocity;
                sr.sprite = Resources.Load("jump", typeof(Sprite)) as Sprite;
                Invoke("ResetIdleSprite", jumpshowTime);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lbutton.color = pressColor;
            if (lstep > 0)
            {
                lexplodeFX.Play();
                lstep--;
                GetComponent<Rigidbody2D>().velocity = leftVelocity;
                sr.sprite = Resources.Load("jump", typeof(Sprite)) as Sprite;
                Invoke("ResetIdleSprite", jumpshowTime);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rbutton.color = pressColor;
            if (rstep > 0)
            {
                rexplodeFX.Play();
                rstep--;
                GetComponent<Rigidbody2D>().velocity = rightVelocity;
                sr.sprite = Resources.Load("jump", typeof(Sprite)) as Sprite;
                Invoke("ResetIdleSprite", jumpshowTime);
            }
        }
        else if (GetComponent<Rigidbody2D>().velocity.y < -0.1f)
        {

            sr.sprite = Resources.Load("fall", typeof(Sprite)) as Sprite;
        }
        else if (GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            ResetIdleSprite();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
            mbutton.color = Color.white;
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
            lbutton.color = Color.white;
        else if (Input.GetKeyUp(KeyCode.RightArrow))
            rbutton.color = Color.white;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Return")
        {
            SceneManager.LoadScene("level2.0");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LEnergy")
        {
            Destroy(collision.gameObject);
            rstep += stepIncrement;
        }
        else if (collision.gameObject.tag == "MEnergy")
        {
            Destroy(collision.gameObject);
            mstep += stepIncrement;
        }
        else if (collision.gameObject.tag == "REnergy")
        {
            Destroy(collision.gameObject);
            lstep += stepIncrement;
        }
        else if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            int type = Random.Range(0, 3);
            //print(type);
            if (type == 0)
            {
                lstep += coinIncrement;
            }
            if (type == 1)
            {
                mstep += coinIncrement;
            }
            if (type == 2)
            {
                rstep += coinIncrement;
            }
        }
    }
}
