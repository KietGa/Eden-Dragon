using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCD;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    private float cdTime = Mathf.Infinity;
    private Animator anim;
    private PlayerMovement player;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        cdTime += Time.deltaTime;

        if (Input.GetMouseButton(0) && cdTime > attackCD && player.CanAttack())
        {
            Attack();
        }
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cdTime = 0;

        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}