using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpButtonControl : MonoBehaviour
{
    public bool IsHero;
    public bool IsRuby;

    public GameObject HeroPrefab;

    public Text DamageText;
    public Text PriceText;

    public int Damage = 10;
    public int Price = 100;

    GameHelper _gameHelper;

    // Start is called before the first frame update
    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();

        if (IsHero == true)
            Damage = HeroPrefab.GetComponent<MinionControl>().Damage;

        DamageText.text = "+" + Damage.ToString();
        PriceText.text = Price.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpClick()
    {
        if (!IsRuby && _gameHelper.PlayerGold >= Price
            ||
            IsRuby && _gameHelper.PlayerRuby >= Price)
        {
            if (!IsRuby)
                _gameHelper.PlayerGold -= Price;
            else
                _gameHelper.PlayerRuby -= Price;

            if (IsHero == false)
                _gameHelper.PlayerDamage += Damage;
            else
            {
                GameObject hero = Instantiate(HeroPrefab) as GameObject;
                Vector3 heroPosition = new Vector3(
                    Random.Range(0.8f, 1.7f),
                    -2.4f,
                    0);
                hero.transform.position = heroPosition;
            }
        }

        //if (IsHero == false)
        //Destroy(gameObject);
    }
}
