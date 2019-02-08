using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour {
   public bool withMagnet = false; //小球对磁铁物品的状态，后续可以传递给UI等等
    public float magnetTime = 3.0f;  //磁铁持续时间
    public float magnetRange = 3.0f; // 磁铁持续范围
    private GameObject magcollider;

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
    public  void IniEnvironment()
    {
        
    }
    // Use this for initialization
    void Start () {
        withMagnet = false;
        magcollider = GameObject.Find("MagObject");
        
            
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        _instance = this;
        
    }

}
