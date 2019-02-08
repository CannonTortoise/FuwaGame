using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {

    public float fuelSpeed = 4.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ToolManager.Instance.withFuel == true)
        {
            // 使用上下方向键或者W、S键来控制前进后退
            float verticalDistance = Input.GetAxis("Vertical") * fuelSpeed * Time.deltaTime;
            //使用左右方向键或者A、D键来控制左右旋转
            float horizontalDistance = Input.GetAxis("Horizontal") * fuelSpeed * Time.deltaTime;
            transform.Translate(horizontalDistance, 0, 0); //沿着Y轴移动
            transform.Translate(0, verticalDistance, 0); //沿着x轴移动


        }
    }
}
