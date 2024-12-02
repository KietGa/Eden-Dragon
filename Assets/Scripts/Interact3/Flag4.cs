using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag4 : MonoBehaviour
{
    [SerializeField] private PlayerInteract2 pi2;
    [SerializeField] private PlayerInteract3 pi3;
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
        pi2.TalkI("Căn Cứ Con Cú (Save Code: STAGETWO)", "Flag", true, true);
        player.interact = false;
        player.rb.bodyType = RigidbodyType2D.Static;
    }
    public void Talk2()
    {
        pi3.TalkI("Vùng đất link hồn", "Flag", true, true);
        player.interact = false;
        player.rb.bodyType = RigidbodyType2D.Static;
    }

    public void TalkOut()
    {
        player.interact = true;
        player.rb.bodyType = RigidbodyType2D.Dynamic;
        pi2.TalkI("");
        this.gameObject.SetActive(false);
    }

    public void TalkOutt()
    {
        player.interact = true;
        player.rb.bodyType = RigidbodyType2D.Dynamic;
        pi3.TalkI("");
        this.gameObject.SetActive(false);
    }
}
