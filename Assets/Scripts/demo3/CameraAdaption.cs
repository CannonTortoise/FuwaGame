using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//根据分辨率调整使相机宽度不变
public class CameraAdaption : MonoBehaviour {

    private float defaultOrthographicsSize = 5f;
    private float defalutAspectRatio = 0.5625f;

    // Use this for initialization
    void Start()
    {
        float width = Screen.width;
        float height = Screen.height;
        float aspectRatio = width / height;
        GetComponent<Camera>().orthographicSize = defaultOrthographicsSize * defalutAspectRatio / aspectRatio;

    }
}
