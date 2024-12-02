using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl : MonoBehaviour
{
    [SerializeField] private PlayerInteract owl;
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
        owl.owl1 = true;
        owl.time = 0;
    }
}
