using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//相机跟随 挂在相机上
public class MovingCamera : MonoBehaviour
{
    public Transform target;            //跟随的目标
    public float maxBorderDistance;     //相机与跟随对象的最大距离
    public float speed;                 //相机移动的速度

    void Update()
    {
        float posx = transform.position.x;  //相机的当前位置

        //如果相机与角色的横向距离超过了最大范围，则将平滑移动到目标点的x
        if (Mathf.Abs(posx - target.position.x) > maxBorderDistance)
            posx = Mathf.Lerp(posx, target.position.x, speed * Time.deltaTime);

        transform.position = new Vector3(posx, transform.position.y, transform.position.z);   //改变相机的位置
    }
}
