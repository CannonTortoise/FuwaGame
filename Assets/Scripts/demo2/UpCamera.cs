using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//相机跟随 挂在相机上
public class UpCamera : MonoBehaviour
{
    public Transform target;            //跟随的目标
    public float speed;                 //相机移动的速度
    private float maxy;                 //目标的最高点

    void Update()
    {
        float posy = transform.position.y;  //相机的当前y轴位置
        if (target.position.y > maxy)
            maxy = target.position.y;
        //当相机高度低于目标最高点高度，向上移动相机
        if (maxy > posy)
            posy = Mathf.Lerp(posy, maxy, speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, posy, transform.position.z);   //改变相机的位置
    }
}
