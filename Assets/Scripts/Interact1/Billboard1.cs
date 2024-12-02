using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Billboard1 : MonoBehaviour
{
    [SerializeField] GameObject load;
    [SerializeField] GameObject off;
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
        off.SetActive(false);
        load.SetActive(true);
        SceneManager.LoadScene(1);
    }
}
