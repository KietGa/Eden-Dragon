using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSign1 : MonoBehaviour
{
    [SerializeField] private PlayerInteract rs;
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
        rs.TalkI("5m nữa là đến Làng Xúc Vật", "Road Sign", true, true);
        player.interact = false;
        player.rb.bodyType = RigidbodyType2D.Static;
    }

    public void TalkOut()
    {
        player.interact = true;
        player.rb.bodyType = RigidbodyType2D.Dynamic;
        rs.TalkI();
        this.gameObject.SetActive(false);
    }
}
