using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBall : MonoBehaviour {

    public Transform plank;
    public Vector2 leftVelocity;
    public Vector2 rightVelocity;
    void Awake()//初始化
    {
        ToolManager.Instance.IniEnvironment();//调用一下，初始化ToolManager
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "lplank")
        {
            float contact_posy = collision.contacts[0].point.y;
            if(contact_posy > plank.position.y)
                GetComponent<Rigidbody2D>().velocity = leftVelocity;
        }
        else if (collision.gameObject.name == "rplank") {
            float contact_posy = collision.contacts[0].point.y;
            if (contact_posy > plank.position.y)
                GetComponent<Rigidbody2D>().velocity = rightVelocity;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
            Destroy(collision.gameObject);
        else if (collision.gameObject.tag == "Magnet")
        {
            Destroy(collision.gameObject);
            ToolManager.Instance.GetMagnet();
        }
            
    }
}
