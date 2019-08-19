using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuControl : MonoBehaviour
{
    public Text LevelUI;
    public Text ScoreUI;
    public Text GoldUI;
    public Text RubyUI;
    public Text MonsterUI;
    public Text BossUI;

    GameHelper _gameHelper;

    // Start is called before the first frame update
    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ShowScore(int gold, int ruby, int monster, int boss, int level)
    {
        GoldUI.text = gold.ToString();
        RubyUI.text = ruby.ToString();
        MonsterUI.text = monster.ToString();
        BossUI.text = boss.ToString();
        LevelUI.text = "Level " + level.ToString();

        int Score = 0;

        Score = (int)((gold + ruby * 180) * (Mathf.PI / 2) * level);

        SettingClass.Score += Score;

        ScoreUI.text = Score.ToString();
    }


    public void ButtonNext_click()
    {
        Time.timeScale = 1; ///Pause
        _gameHelper.PauseGame = false;
        gameObject.SetActive(false);
    }
}
