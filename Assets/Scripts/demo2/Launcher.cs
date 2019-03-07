using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {

    public float rotateSpeed;
    public float launchSpeed;
    public float maxAngle;
    public GameObject ball;
    //public GameObject launch;
    public GameObject click;
    public Sprite afterLaunch;
    //public GameObject plank;
    private bool launchBegin;
    private int dir;
    private bool valid;

	void Awake () {
        launchBegin = false;
        valid = true;
        dir = 1;
        ball = GameObject.FindWithTag("Player");
        ResetBall();
        click.SetActive(false);
    }
    private void Update()
    {
        if (launchBegin) {
            ToolManager.Instance.withLuncher = true;
            click.SetActive(true);
            Vector3 rotate = Vector3.zero;
            rotate.z = dir * Time.deltaTime * rotateSpeed;
            GetComponentsInParent<Transform>()[1].Rotate(rotate);
            float anglez = GetComponentsInParent<Transform>()[1].eulerAngles.z;
            if (!(anglez < maxAngle || anglez > 360 - maxAngle)) 
                dir = -dir;
            if (Input.GetMouseButtonDown(0))
            {
                ToolManager.Instance.PlayAudio(2);
                launchBegin = false;
                //plank.SetActive(true);
                ball.transform.SetParent(null);
                if (anglez <= 90)
                    ball.GetComponent<Rigidbody2D>().velocity = launchSpeed * new Vector2(-1,Mathf.Tan((90 - anglez) * Mathf.PI / 180)).normalized;
                else if(anglez >= 270)
                    ball.GetComponent<Rigidbody2D>().velocity = launchSpeed * new Vector2(1, Mathf.Tan((anglez - 270) * Mathf.PI / 180)).normalized;
                ball.GetComponent<CapsuleCollider2D>().enabled = true;
                //GetComponent<BoxCollider2D>().enabled = false;
                ball.GetComponent<Rigidbody2D>().gravityScale = 1;
                //Invoke("re_gravity", 1.0f);
                ResetBall();
                ToolManager.Instance.withLuncher = false;
                //Destroy(launch);//consider why we need this "DESTROY"
                click.SetActive(false);
                GetComponent<SpriteRenderer>().sprite = afterLaunch;
                valid = false;
            }
        }

    }
    
    private void ResetBall()
    {
        ball.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (valid) {
            launchBegin = true;
            ball.transform.parent = transform.parent;
            ball.transform.localPosition = new Vector3(0, 2, 0);
            ball.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody2D>().gravityScale = 0;
            ball.GetComponent<CapsuleCollider2D>().enabled = false;
            //plank.SetActive(false);
        }
    }

    private void re_gravity() {
        ball.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
