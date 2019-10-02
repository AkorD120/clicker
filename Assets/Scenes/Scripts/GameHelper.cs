using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{
    public Transform StartPosirion;
    public Text PlayerDamageUI;
    public Text PlayerGoldUI;
    public Text PlayerRubyUI;
    public Text HPValueUI;
    public Text GameTimeText;
    public Slider BarHealthUI;
    public GameObject GoldPrefab;
    public GameObject RubyPrefab;
    public EndMenuControl EndMenuControl;
    public GameObject[] MonsterPrefabs;

    const int Freequency = 3;

    public int Level = 1;
    public int PlayerGold = 0;
    public int PlayerRuby = 0;
    public int PlayerDamage = 10;
    public int GameTime = 15;

    int _curentTime;
    int _count;
    int _countBoss;
    int TotalGold = 0;
    int TotalRuby = 0;

    public bool PauseGame { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        SpawnMonsters();

        InvokeRepeating("Timer", 0, 1);
    }

    void Timer()
    {
        _curentTime++;

        GameTimeText.text = $"{(GameTime - _curentTime).ToString()} s  X{Level}";

        if (_curentTime >= GameTime)
        ///End the Game
        {
            GameTime += 20;
            //Time.timeScale = 0; ///Pause
            //PauseGame = true;
            //EndMenuControl.gameObject.SetActive(true);
            //EndMenuControl.ShowScore(TotalGold, TotalRuby, _count, _countBoss, Level);
            Level++;
        }
    }

    public void Settings()
    {
        Time.timeScale = 0; ///Pause
        PauseGame = true;
        EndMenuControl.gameObject.SetActive(true);
        EndMenuControl.ShowScore(TotalGold, TotalRuby, _count, _countBoss, Level);
        //Level++;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerGoldUI.text = PlayerGold.ToString();
        PlayerRubyUI.text = PlayerRuby.ToString();
        PlayerDamageUI.text = PlayerDamage.ToString();
    }

    public void TakeGold(int gold)
    {
        PlayerGold += gold;
        TotalGold += gold;

        GameObject goldObj = Instantiate(GoldPrefab) as GameObject;
        Destroy(goldObj, 1);
        SpawnMonsters();
    }

    public void TakeRuby(int ruby)
    {
        _countBoss++;

        PlayerRuby += ruby;
        TotalRuby += ruby;

        GameObject rubyObj = Instantiate(RubyPrefab) as GameObject;
        Destroy(rubyObj, 2);
    }

    public void SpawnMonsters()
    {
        _count++;

        int randomMaxValue = _count / Freequency + 1;

        if (randomMaxValue >= MonsterPrefabs.Length)
            randomMaxValue = MonsterPrefabs.Length;

        int index = Random.Range(0, randomMaxValue); //futer random

        GameObject monsterObj = Instantiate(MonsterPrefabs[index])
            as GameObject;

        monsterObj.transform.position = StartPosirion.position;
    }
}
