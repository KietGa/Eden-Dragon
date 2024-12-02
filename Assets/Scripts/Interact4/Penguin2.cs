using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin2 : MonoBehaviour
{
    [SerializeField] private PlayerInteract2 p;
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
        p.pen1 = true;
        p.time = 0;
    }
}
