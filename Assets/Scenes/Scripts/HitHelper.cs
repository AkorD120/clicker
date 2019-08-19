using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHelper : MonoBehaviour
{
    GameHelper _gameHelper;
    PlayerControl _playerControl;


    // Start is called before the first frame update
    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();
        _playerControl = GameObject.FindObjectOfType<PlayerControl>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (_gameHelper.PauseGame)
            return;

        GetComponent<HealthHelper>().GetHit(_gameHelper.PlayerDamage);
        _playerControl.RunAttack();
    }
}
