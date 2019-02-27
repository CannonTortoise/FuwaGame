using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    [System.Serializable]
    public struct Step
    {
        public int lstep;
        public int mstep;
        public int rstep;
    }
    [System.Serializable]
    public struct CameraRange
    {
        public float min;
        public float max;
    }

    public int totalLevel;
    private int currentLevel;
    public Vector2[] resetPos;
    public Step[] levelStep;
    public CameraRange[] cameraRange;
    private JumpController jc;
    private CameraFollow cf;
    private GameObject levelPrefab;


    void Start () {
        cf = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        jc = GameObject.Find("Ball").GetComponent<JumpController>();
        ChangeLevel(0);
    }

    public void ChangeLevel(int i) {
        currentLevel = i;
        jc.SetSteps(levelStep[currentLevel].lstep, levelStep[currentLevel].mstep, levelStep[currentLevel].rstep);
        levelPrefab = (GameObject)Resources.Load("Level" + currentLevel);
        cf.SetRange(cameraRange[currentLevel].min, cameraRange[currentLevel].max);
    }

    public void NextLevel()
    {
        ChangeLevel(currentLevel+1);
    }

    public void ResetLevel()
    {
        string levelname = "Level" + currentLevel + "(Clone)";
        Destroy(GameObject.Find(levelname));
        Instantiate(levelPrefab);
        GameObject ball = GameObject.Find("Ball");
        ball.transform.position = resetPos[currentLevel];
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        jc.SetSteps(levelStep[currentLevel].lstep, levelStep[currentLevel].mstep, levelStep[currentLevel].rstep);
    }
}
