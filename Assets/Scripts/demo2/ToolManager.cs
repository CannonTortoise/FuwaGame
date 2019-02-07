using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour {
    public GameObject ball;
   public bool withMagnet = false; //小球对磁铁物品的状态，后续可以传递给UI等等
    public float magnetTime = 3.0f;  //磁铁持续时间
    public float magnetRange = 3.0f; // 磁铁持续范围,现在的这个东西在coinmove里体现
    private GameObject magcollider;

    public float fuelTime = 3.0f;  //小球获得燃料充能时间
    public bool withFuel = false;
    //public float fuelSpeed = 4.0f; //手动小球的速度,现在这一项在小球的里面调

    //提供外界访问方式
    private static ToolManager _instance;
    public static ToolManager Instance
    {
        get
        {
            return _instance;
        }
    }
    
    public void ResetMagnet( )  //复位磁铁状态
    {
            withMagnet = false;
        return ;
    }
    public void GetMagnet() //设置进入磁铁状态
    {
        withMagnet = true;
        Invoke("ResetMagnet", magnetTime);
    }
   
    public void GetFuel()  //获得燃料充能状态
    {
        ball.GetComponent<Rigidbody2D>().gravityScale = 0;
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        withFuel = true;
        Invoke("ResetFuel", fuelTime);
        //to do :显示给玩家燃料充能即将耗尽
        return;
    }
    private void ResetFuel()
    {
        withFuel = false;
        ball.GetComponent<Rigidbody2D>().gravityScale = 1; //这个数值后面可以再调整
    }





    // Use this for initialization
    void Start () {
        ball = GameObject.FindGameObjectWithTag("Player");
        withMagnet = false;
    
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _instance = this;
        
    }

}
