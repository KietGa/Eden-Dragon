using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("HealthBar")]
    [SerializeField] private float enemyMaxHP;
    private float enemyHP;
    private bool isDead = false;
    private Animator anim;

    private void Awake()
    {
        enemyHP = enemyMaxHP;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (enemyHP <= 0 && !isDead)
        {
            anim.SetTrigger("die");
            isDead = true;
        }
    }

    public void LostHP(int dmg)
    {
        anim.SetTrigger("hurt");
        enemyHP -= dmg;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
