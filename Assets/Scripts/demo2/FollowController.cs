using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//板子跟随鼠标移动
public class FollowController : MonoBehaviour {

    public Transform plank;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        plank.position = new Vector3(mousePos.x, mousePos.y, plank.position.z);
    }
}
