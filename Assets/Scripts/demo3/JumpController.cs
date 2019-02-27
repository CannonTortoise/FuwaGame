using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpController : MonoBehaviour
{
    public float verticalVelocity;
    public float horizontalVelocity;
    public Color pressColor;
    public int stepIncrement;

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

    void Awake()
    {
        lstep = 100;
        mstep = 100;
        rstep = 100;
        ltext = GameObject.Find("LStep").GetComponent<Text>();
        mtext = GameObject.Find("MStep").GetComponent<Text>();
        rtext = GameObject.Find("RStep").GetComponent<Text>();
        lbutton = GameObject.Find("LButton").GetComponent<Image>();
        mbutton = GameObject.Find("MButton").GetComponent<Image>();
        rbutton = GameObject.Find("RButton").GetComponent<Image>();
        leftVelocity = new Vector2(-horizontalVelocity, verticalVelocity);
        midVelocity = new Vector2(0, verticalVelocity);
        rightVelocity = new Vector2(horizontalVelocity, verticalVelocity);
        lc = GameObject.Find("Controller").GetComponent<LevelController>();
    }

    void Update()
    {
        ltext.text = lstep.ToString();
        mtext.text = mstep.ToString();
        rtext.text = rstep.ToString();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            mbutton.color = pressColor;
            if (mstep > 0) {
                mstep--;
                GetComponent<Rigidbody2D>().velocity = midVelocity;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lbutton.color = pressColor;
            if (lstep > 0)
            {
                lstep--;
                GetComponent<Rigidbody2D>().velocity = leftVelocity;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rbutton.color = pressColor;
            if (rstep > 0)
            {
                rstep--;
                GetComponent<Rigidbody2D>().velocity = rightVelocity;
            }
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
            lc.ResetLevel();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LEnergy")
        {
            Destroy(collision.gameObject);
            lstep += stepIncrement;
        }
        else if (collision.gameObject.tag == "MEnergy")
        {
            Destroy(collision.gameObject);
            mstep += stepIncrement;
        }
        else if (collision.gameObject.tag == "REnergy")
        {
            Destroy(collision.gameObject);
            rstep += stepIncrement;
        }
        else if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
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
        else if (collision.gameObject.tag == "Death")
        {
            lc.ResetLevel();
        }
    }

    public void SetSteps(int l, int m , int r) {
        lstep = l;
        mstep = m;
        rstep = r;
    }
}
