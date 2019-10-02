using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHelper : MonoBehaviour
{
    bool _isDead;

    public int MaxHealth = 100;
    public int Health = 100;
    public int Gold = 10;
    public int RubyChanse;

    GameHelper _gameHelper;


    // Start is called before the first frame update
    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();
        MaxHealth = MaxHealth * _gameHelper.Level;
        _gameHelper.BarHealthUI.maxValue = MaxHealth;
        _gameHelper.BarHealthUI.value = MaxHealth;
        _gameHelper.HPValueUI.text = Health + "/" + MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetHit(int damage)
    {
        if (_isDead == true)
            return;

        int health = Health - damage;

        if (health <= 0)
        {
            _isDead = true;
            _gameHelper.TakeGold(Gold);

            if (Random.Range(0, 100) < RubyChanse)
                _gameHelper.TakeRuby(1);

            Destroy(gameObject);
        }
        else
        {
            GetComponent<Animator>().SetTrigger("Hit");
            Health = health;
            _gameHelper.BarHealthUI.value = Health;
            _gameHelper.HPValueUI.text = Health + "/" + MaxHealth;
        }

        //Debug.Log("Health = " + Health);
    }

}
