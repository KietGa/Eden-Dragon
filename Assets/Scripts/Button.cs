using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject active;
    [SerializeField] private GameObject deactive;
    [SerializeField] private int scene;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Text loadText;

    public void LoadSave()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLevel()
    {
        if (loadText.text == "EDENDRAGON")
        {
            SceneManager.LoadScene(1);
            active.SetActive(true);
            deactive.SetActive(false);
        }
        if (loadText.text == "STAGETWO")
        {
            SceneManager.LoadScene(2);
            active.SetActive(true);
            deactive.SetActive(false);
        }
        if (loadText.text == "KIGA")
        {
            SceneManager.LoadScene(3);
            active.SetActive(true);
            deactive.SetActive(false);
        }
        if (loadText.text == "CHEATCODE")
        {
            SceneManager.LoadScene(4);
            active.SetActive(true);
            deactive.SetActive(false);
        }
        if (loadText.text == "FINALBOSS")
        {
            SceneManager.LoadScene(5);
            active.SetActive(true);
            deactive.SetActive(false);
        }
    }

    public void ActiveButton()
    {
        active.SetActive(true);
        deactive.SetActive(false);
    }

    public void BackButton()
    {
        deactive.SetActive(false);
    }

    public void BackMenuButton()
    {
        player.interact = true;
        player.rb.bodyType = RigidbodyType2D.Dynamic;
        deactive.SetActive(false);
    }

    public void OnlyActiveButton()
    {
        active.SetActive(true);
    }

    public void StartButton()
    {
        active.SetActive(true);
        deactive.SetActive(false);
        PlayerPrefs.SetInt("playerStartHP", 3);
        PlayerPrefs.SetInt("Owl", 1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void ScenceButton()
    {
        SceneManager.LoadScene(scene);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
