using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign1 : MonoBehaviour
{
    [SerializeField] private PlayerInteract sign;
    [SerializeField] private PlayerMovement player;
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
        sign.TalkI("Ấn A D hoặc < > để di chuyển + Chuột để tương tác (Sau dùng nhiều) + Ưu tiên dùng A D", "Sign", true, true);
        player.interact = false;
        player.rb.bodyType = RigidbodyType2D.Static;
    }

    public void TalkOut()
    {
        player.interact = true;
        player.rb.bodyType = RigidbodyType2D.Dynamic;
        sign.TalkI("");
        this.gameObject.SetActive(false);
    }
}
