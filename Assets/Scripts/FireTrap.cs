using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private float activeDelay;
    [SerializeField] private float activeTime;
    [SerializeField] private int dmg;
    [SerializeField] private HealthBar hp;
    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered;
    private bool active;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!triggered)
            {
                StartCoroutine(ActiveFireTrap());
            }
            if (active)
            {
                hp.LostHP(dmg);
            }
        }
    }

    private IEnumerator ActiveFireTrap()
    {
        triggered = true;
        spriteRend.color = Color.red;
        yield return new WaitForSeconds(activeDelay);
        spriteRend.color = Color.white;
        active = true;
        anim.SetBool("active", true);
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("active", false);
    }
}
