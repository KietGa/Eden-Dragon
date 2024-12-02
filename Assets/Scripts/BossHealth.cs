using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [Header("HealthBar")]
    [SerializeField] private float enemyMaxHP;
    private float enemyHP;
    public bool isDead = false;
    private bool isRage = false;
    private Animator anim;
    [SerializeField] private Text bossHP;
    private MeleeEnemy boss;
    private EnemyPatrol enemyPatrol;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject rageMode;

    private void Awake()
    {
        enemyHP = enemyMaxHP;
        anim = GetComponent<Animator>();
        boss = GetComponent<MeleeEnemy>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (enemyHP <= 0 && !isDead)
        {
            anim.SetTrigger("die");
            isDead = true;
        }
        if (enemyHP <= 100 && !isRage)
        {
            bossHP.text = "Boss HP: " + enemyHP;
            rageMode.SetActive(true);
            spriteRenderer.color = Color.yellow;
            boss.atkCD = 1;
            boss.dmg = 2;
            enemyPatrol.speed = 10;
            enemyPatrol.idleDuration = 1;
            isRage = true;
            Invoke(nameof(OffRage), 2);
            bossHP.text = "Boss HP: " + enemyHP;
        }
        else
        {
            bossHP.text = "Boss HP: " + enemyHP;
        }
    }

    private void OffRage()
    {
        rageMode.SetActive(false);
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
