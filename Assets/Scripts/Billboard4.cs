using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Billboard5 : MonoBehaviour
{
    [SerializeField] GameObject load;
    [SerializeField] GameObject off;
    [SerializeField] private GameObject tb;
    [SerializeField] BossHealth health;
    [SerializeField] private GameObject ntdbf;

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
        if (health.isDead)
        {
            off.SetActive(false);
            load.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            ntdbf.SetActive(true);
            Invoke(nameof(OffTB), 2);
        }
    }

    private void OffTB()
    {
        ntdbf.SetActive(false);
    }
}
