using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Foods : MonoBehaviour
{
    private int foods;
    [SerializeField] private Text foodText;

    private void Awake()
    {
        foods = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            foods++;
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        foodText.text = "Foods: " + foods;
    }
}
