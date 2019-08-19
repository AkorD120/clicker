using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MinionControl : MonoBehaviour
{
    public GameObject BulletPrefab;

    public int Damage = 10;
    public float AttackSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Attack()
    {
        yield return new WaitForSeconds(AttackSpeed);

        GetComponent<Animator>().SetTrigger("Attack");

        GameObject bullet = Instantiate(BulletPrefab) as GameObject;
        bullet.transform.position = transform.position;
        bullet.GetComponent<BulletControl>().Damage = Damage;

        Destroy(bullet, 0.25f);

        StartCoroutine(Attack());

    }
}
