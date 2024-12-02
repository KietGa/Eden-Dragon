using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int dmg;
    private bool hit;
    private float direction;
    private float lifeTime;
    private BoxCollider2D boxCollider;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit) return;
        float movemenSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movemenSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if (lifeTime > 5) DeActive();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");

        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealth>().LostHP(dmg);
        }
        if (collision.tag == "Boss")
        {
            collision.GetComponent<BossHealth>().LostHP(dmg);
        }
    }

    public void SetDirection(float direction)
    {
        lifeTime = 0;
        this.direction = direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != direction)
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void DeActive()
    {
         gameObject.SetActive(false);
    }
}
