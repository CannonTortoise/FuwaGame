using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStatus : MonoBehaviour {

    private int status;         //当前所在的平台 0是平台1 1是平台2
    private float interval;     //平台间的固定距离

    public float speed;         //匀速向右的速度
    public Transform platform1; //平台1
    public Transform platform2; //平台2
    public Sprite sprite;       //平台的sprite
    public float min;           //浮动距离的下界
    public float max;           //浮动距离的上界

    void Start () {
        interval = sprite.bounds.size.x;
        status = 0;
    }

    private void FixedUpdate()
    {
        //匀速向右移动
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int i = status;     //碰撞前的状态

        if (collision.gameObject.name == "Platform1")
            status = 0;
        else if (collision.gameObject.name == "Platform2")
            status = 1;

        int j = status;     //碰撞后的状态
        float rd = Random.Range(min, max); //平台间的浮动距离

        //从平台1跳到了平台2    则移动平台1
        if (i == 0 && j == 1)
            platform1.position = new Vector2(platform2.position.x + interval + rd, platform1.position.y);

        //从平台2跳到了平台1    则移动平台2
        if (i == 1 && j == 0)
            platform2.position = new Vector2(platform1.position.x + interval + rd, platform1.position.y);

    }
}
