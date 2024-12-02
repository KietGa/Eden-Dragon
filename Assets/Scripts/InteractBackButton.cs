using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBackButton : MonoBehaviour
{
    [SerializeField] private PlayerInteract p;
    [SerializeField] private PlayerInteract2 p2;
    [SerializeField] private PlayerInteract3 p3;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private GameObject textBox;
    [SerializeField] private GameObject[] button;
    public void EndInteract()
    {
        player.interact = true;
        player.rb.bodyType = RigidbodyType2D.Dynamic;
        p.TalkI("");
        this.gameObject.SetActive(false);
    }

    public void EndInteract3()
    {
        player.interact = true;
        player.rb.bodyType = RigidbodyType2D.Dynamic;
        p3.TalkI("");
        this.gameObject.SetActive(false);
    }
    public void EndInteract2()
    {
        p2.pen1 = false;
        player.interact = true;
        player.rb.bodyType = RigidbodyType2D.Dynamic;
        p2.TalkI("");
        foreach (GameObject g in button)
        {
            g.SetActive(false);
        }
        this.gameObject.SetActive(false);
    }
}
