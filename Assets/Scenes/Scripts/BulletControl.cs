using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public int Damage { get; set; }


    HealthHelper _healthHelper;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_healthHelper == null)
            _healthHelper = GameObject.FindObjectOfType<HealthHelper>();
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,
                _healthHelper.transform.position,
                Time.deltaTime * 8.5f);

            if (Vector2.Distance(transform.position, _healthHelper.transform.position) < 0.1f)
            ///Попал
            {
                _healthHelper.GetHit(Damage);

                Destroy(gameObject);
            }
        }
    }
}
