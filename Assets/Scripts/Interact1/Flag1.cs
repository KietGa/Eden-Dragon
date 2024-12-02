using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag1 : MonoBehaviour
{
    [SerializeField] private PlayerInteract flag;
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
        flag.TalkI("Làng Xúc Vật", "Flag", true, true);
        player.interact = false;
        player.rb.bodyType = RigidbodyType2D.Static;
    }

    public void TalkOut()
    {
        player.interact = true;
        player.rb.bodyType = RigidbodyType2D.Dynamic;
        flag.TalkI();
        this.gameObject.SetActive(false);
    }
}
