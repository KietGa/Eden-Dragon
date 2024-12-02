using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    [SerializeField] private float atkCD;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int dmg;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    public AudioSource hitSound;
    public GameObject hitEffect;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    private float cdTimer = Mathf.Infinity;

    private Animator anim;
    private EnemyPatrol enemyPatrol;
    [SerializeField] private HealthBar playerHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    // Update is called once per frame
    void Update()
    {
        cdTimer += Time.deltaTime;

        if (PlayerInSight() && playerHealth.playerHP > 0)
        {
            if (cdTimer > atkCD)
            {
                cdTimer = 0;
                anim.SetTrigger("rangeAttack");
            }
        }


        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void RangedAttack()
    {
        cdTimer = 0;
        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<EnemyProjectile>().ActiveProjectile();
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

    private void OffHitActive()
    {
        hitEffect.SetActive(false);
    }
}
