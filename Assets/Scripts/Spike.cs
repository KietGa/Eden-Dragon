using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private int dmg;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private GameObject hitEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            healthBar.LostHP(dmg);
            hitSound.Play();
            hitEffect.SetActive(true);
            Invoke(nameof(EndEffect), 2);
        }
    }

    private void EndEffect()
    {
        hitEffect.SetActive(false);
    }
}
