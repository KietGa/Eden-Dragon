using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timer = 0;
    private float condition = 15;
    [SerializeField] private GameObject[] objects;
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >  condition)
        {
            int i = Random.Range(0, objects.Length);
            if (!objects[i].activeInHierarchy)
            {
                objects[i].SetActive(true);
            }
            condition += 15;
        }
    }
}
