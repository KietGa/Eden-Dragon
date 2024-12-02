using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("HealthBar")]
    private Image playerCurrentHPBar;
    protected float playerMaxHP;
    public float playerHP;
    private bool isDead = false;
    private int scence;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject bgmusic;
    [SerializeField] private PlayerMovement player;

    private void Awake()
    {
        scence = SceneManager.GetActiveScene().buildIndex;
        playerCurrentHPBar = GetComponent<Image>();
        if (scence == 0 || scence == 1 || scence == 2)
        {
            playerMaxHP = 3;
        }
        if (scence == 3 || scence == 4)
        {
            playerMaxHP = 4;
        }
        if (scence == 5)
        {
            playerMaxHP = 5;
        }
        playerHP = playerMaxHP;
        isDead = false;
    }

    private void Update()
    {
        playerCurrentHPBar.fillAmount = Mathf.Clamp(playerHP / 10f, 0, 1);
        if (playerHP <= 0 && !isDead)
        {
            player.anim.SetTrigger("die");
            bgmusic.SetActive(false);
            isDead = true;
            player.interact = false;
            player.rb.bodyType = RigidbodyType2D.Static;
            gameOver.SetActive(true);
        }
    }

    public void LostHP(int dmg)
    {
        playerHP -= dmg;

    }
}
