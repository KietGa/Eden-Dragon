using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Saw : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private int dmg;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private GameObject hitEffect;
    void Update()
    {
        transform.Rotate(0, 0, speed * 360 * Time.deltaTime);
    }
         
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
