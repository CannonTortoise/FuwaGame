using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlatform : MonoBehaviour {

    public int timesCanCollide = 1; //可碰撞次数
    private void Start()
    {
        if (timesCanCollide <= 0)
            timesCanCollide = 1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
            timesCanCollide--;
        if (timesCanCollide == 0)
            Destroy(this.gameObject);
    }
}
