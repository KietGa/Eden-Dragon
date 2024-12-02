using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField] private HealthBar hp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hp.LostHP(-1);
        Destroy(gameObject);
    }
}
