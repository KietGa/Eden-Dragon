using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird3 : MonoBehaviour
{
    [SerializeField] private PlayerInteract2 bird;
    [SerializeField] private GameObject tb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tb.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tb.SetActive(false);
    }
    public void Talk1()
    {
        bird.bird1 = true;
        bird.time = 0;
    }
}
