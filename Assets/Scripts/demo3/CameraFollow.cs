using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;    //跟随目标
    public float maxDistance;   //相机与目标的相对范围
    public float speed;         //相机移动的平滑度
    private float _min;         //边界最大值
    private float _max;         //边界最小值


    void Update()
    {

        float y = transform.position.y;
        //如果相机与角色的x轴距离超过了最大范围则将x平滑的移动到目标点的x
        if (Mathf.Abs(y - target.position.y) > maxDistance)
        {
            y = Mathf.Lerp(y, target.position.y, speed * Time.deltaTime);
        }
        float cameraHalfHeight = GetComponent<Camera>().orthographicSize;//视窗水平方向一半的大小
        y = Mathf.Clamp(y, _min + cameraHalfHeight, _max - cameraHalfHeight);//限定x值
        transform.position = new Vector3(transform.position.x, y, transform.position.z);//改变相机的位置
    }

    public void SetRange(float min, float max) {
        _min = min;
        _max = max;
    }
}
