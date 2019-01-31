using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

    public float speed;
    public Texture2D cursor;

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseDrag()
    {
        Cursor.visible = false;
        float distance = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        transform.position = new Vector3(transform.position.x + distance * speed * Time.deltaTime, transform.position.y, transform.position.z);
    }

    private void OnMouseUp()
    {
        Cursor.visible = true;
    }

    
}
