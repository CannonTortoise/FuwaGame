using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private int currentLevel;
    public Vector2[] resetPos;
    private Step[] levelStep;
    public Step[] easyStep;
    public Step[] hardStep;
    public CameraRange[] cameraRange;
    private JumpController jc;
    private CameraFollow cf;
    private GameObject levelPrefab;
    public ParticleSystem[] resetFX;
    private GameObject ball;
    private bool isResetting;   //是否正在重置

    [Header("Difficulty")]
    private bool IsHard = false;  //难度
    public Image easyUI;
    public Image hardUI;
    public Color selectedColor;
    public Color unselectedColor;

    void Start () {
        cf = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        jc = GameObject.Find("Ball").GetComponent<JumpController>();
        ball = GameObject.Find("Ball");

        if (PlayerPrefs.GetInt("Difficulty") == 0)
            IsHard = false;
        else if (PlayerPrefs.GetInt("Difficulty") == 1)
            IsHard = true;

        if (IsHard)
        {
            levelStep = hardStep;
            easyUI.color = unselectedColor;
            hardUI.color = selectedColor;
        }
        else
        {
            levelStep = easyStep;
            easyUI.color = selectedColor;
            hardUI.color = unselectedColor;
        }

        ChangeLevel(PlayerPrefs.GetInt("level"));
        for (int i = 0; i < resetFX.Length; i++)
            resetFX[i].Stop();
        isResetting = false; 
    }

    public void ChooseHard()
    {
        PlayerPrefs.SetInt("Difficulty",1);
        IsHard = true;
        levelStep = hardStep;
        easyUI.color = unselectedColor;
        hardUI.color = selectedColor;
        ResetLevel();
    }

    public void ChooseEasy()
    {
        PlayerPrefs.SetInt("Difficulty", 0);
        IsHard = false;
        levelStep = easyStep;
        easyUI.color = selectedColor;
        hardUI.color = unselectedColor;
        ResetLevel();
    }

    public void ChangeLevel(int i) {
        currentLevel = i;
        GameObject.Find("OneWayFlatform_Level" + currentLevel.ToString()).tag = "Untagged";
        jc.SetSteps(levelStep[currentLevel].lstep, levelStep[currentLevel].mstep, levelStep[currentLevel].rstep);
        levelPrefab = (GameObject)Resources.Load("Level" + currentLevel);
        cf.SetRange(cameraRange[currentLevel].min, cameraRange[currentLevel].max);
        GameObject ball = GameObject.Find("Ball");
        ball.transform.position = resetPos[currentLevel];
        //print(currentLevel);
        //print(ball.transform.position);
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void NextLevel()
    {
        ChangeLevel(currentLevel+1);
    }

    public void ResetLevel()
    {
        if (!isResetting) {
            isResetting = true;
            int randomFX = Random.Range(0, resetFX.Length);
            resetFX[randomFX].Play();
            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            jc.SetSteps(0, 0, 0);
            Invoke("AfterResetLevel", 2.0f);
        }
        
    }

    private void AfterResetLevel()
    {
        ToolManager.Instance.IniToolmanager();
        string levelname = "Level" + currentLevel + "(Clone)";
        Destroy(GameObject.Find(levelname));
        Instantiate(levelPrefab);
        ball.transform.position = resetPos[currentLevel];
        jc.SetSteps(levelStep[currentLevel].lstep, levelStep[currentLevel].mstep, levelStep[currentLevel].rstep);
        isResetting = false;
    }

}
