using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float dmg;
    [SerializeField] private HealthBar php;
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    [SerializeField] private RangeEnemy re;
    private float lifetime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            php.LostHP(2);
            re.hitSound.Play();
            re.hitEffect.SetActive(true);
            Invoke(nameof(OffHitActive), 2);
        }
        gameObject.SetActive(false);
    }
    private void OffHitActive()
    {
        re.hitEffect.SetActive(false);
    }

    public void ActiveProjectile()
    {
        lifetime = 0;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
        {
            gameObject.SetActive(false);
        }
    }
}
