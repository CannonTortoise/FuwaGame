﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JumpController : MonoBehaviour
{
    const string spritePath = "Sprites\\";
    private Sprite idlesprite;
    private SpriteRenderer sr;
    public float jumpshowTime=0.2f;


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
    private ParticleSystem confettiFX;

    //public GameObject timer;
    public Flicker flicker;
    const float magnetTime = 3.0f;  //磁铁持续时间
    const float scaleTime = 3.0f;
    const float incincibleTime = 8.0f;
    const float bombBallTime = 4.0f;
    const float fuelTime = 10.0f;  //小球获得燃料充能时间

    void Awake()
    {
        lstep = 100;
        mstep = 100;
        rstep = 100;
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
        confettiFX = GameObject.Find("ConfettiBlastRainbow").GetComponentInChildren<ParticleSystem>();
        confettiFX.Stop();
    }
    private void ResetIdleSprite()
    {
        sr.sprite = idlesprite;
    }

    private void CheckDeath()
    {
        if (lstep == 0 && rstep == 0 && mstep == 0)
        {
            lc.ResetLevel();
        }
    }

    void Update()
    {
        ltext.text = lstep.ToString();
        mtext.text = mstep.ToString();
        rtext.text = rstep.ToString();


        if (Input.GetKeyDown(KeyCode.UpArrow) && ToolManager.Instance.withFuel==false && ToolManager.Instance.withLuncher == false)
        {
            mbutton.color = pressColor;
            if (mstep > 0) {
                mexplodeFX.Play();
                ToolManager.Instance.PlayAudio(0); //播放“嘿”
                mstep--;
                GetComponent<Rigidbody2D>().velocity = midVelocity;
                //CheckDeath();
                sr.sprite = Resources.Load("jump", typeof(Sprite)) as Sprite;
                Invoke("ResetIdleSprite", jumpshowTime);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && ToolManager.Instance.withFuel == false && ToolManager.Instance.withLuncher == false)
        {
            lbutton.color = pressColor;
            if (lstep > 0)
            {
                lexplodeFX.Play();
                ToolManager.Instance.PlayAudio(0); //播放“嘿”
                lstep--;
                GetComponent<Rigidbody2D>().velocity = leftVelocity;
                //CheckDeath();
                sr.sprite = Resources.Load("jump", typeof(Sprite)) as Sprite;
                Invoke("ResetIdleSprite", jumpshowTime);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && ToolManager.Instance.withFuel == false && ToolManager.Instance.withLuncher == false)
        {
            rbutton.color = pressColor;
            if (rstep > 0)
            {
                rexplodeFX.Play();
                ToolManager.Instance.PlayAudio(0); //播放“嘿”
                rstep--;
                GetComponent<Rigidbody2D>().velocity = rightVelocity;
                //CheckDeath();
                sr.sprite = Resources.Load("jump", typeof(Sprite)) as Sprite;
                Invoke("ResetIdleSprite", jumpshowTime);
            }
        }
        else if (GetComponent<Rigidbody2D>().velocity.y < -0.1f && ToolManager.Instance.withFuel == false)
        {
           
            sr.sprite = Resources.Load("fall", typeof(Sprite)) as Sprite;
        }
        else if (GetComponent<Rigidbody2D>().velocity.y ==0 && ToolManager.Instance.withFuel == false)
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
        if (collision.gameObject.tag == "Death")
        {
            flicker.ResetTimer();
            lc.ResetLevel();
        }
        else if (collision.gameObject.tag == "Return")
        {
            SceneManager.LoadScene("start");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LevelBoundary")
        {
            confettiFX.Play();
            ToolManager.Instance.PlayAudio(3);
            lc.NextLevel();
            collision.gameObject.tag = "Untagged";
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, verticalVelocity/2); ;
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
        else if (collision.gameObject.tag == "Obstacle")
        {
            ToolManager.Instance.PlayAudio(1);
        }
        else if (collision.gameObject.tag == "Magnet")
        {
            Destroy(collision.gameObject);
            //timer.GetComponent <Timer>().Begin(magnetTime);
            //flicker.Begin(magnetTime);
            ToolManager.Instance.GetMagnet();
        }
        else if (collision.gameObject.tag == "Fuel")
        {
            Destroy(collision.gameObject);
            //timer.GetComponent<Timer>().Begin(fuelTime);
            //flicker.Begin(fuelTime);
            ToolManager.Instance.GetFuel(ToolManager.Instance.fuelTime);
        }
        else if (collision.gameObject.tag == "BallScale")
        {
            Destroy(collision.gameObject);
            //timer.GetComponent<Timer>().Begin(scaleTime);
            //flicker.Begin(scaleTime);
            ToolManager.Instance.GetBallScale();
        }
        else if (collision.gameObject.tag == "Invincibility")
        {
            Destroy(collision.gameObject);
            //timer.GetComponent<Timer>().Begin(incincibleTime);
            flicker.Begin(incincibleTime);
            ToolManager.Instance.GetInvincibility();
        }
        else if (collision.gameObject.tag == "BombBall")
        {
            Destroy(collision.gameObject);
            //timer.GetComponent<Timer>().Begin(bombBallTime);
            //flicker.Begin(bombBallTime);
            ToolManager.Instance.GetBombBall();
        }
        else if (collision.gameObject.tag == "Death" && ToolManager.Instance.withInvincibility == false && this.transform.parent == null)
        {
            flicker.ResetTimer();
            lc.ResetLevel();
        }
    }

    public void SetSteps(int l, int m , int r) {
        lstep = l;
        mstep = m;
        rstep = r;
    }
}
