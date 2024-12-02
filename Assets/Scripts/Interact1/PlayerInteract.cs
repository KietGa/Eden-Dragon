using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private GameObject textBox;
    [SerializeField] private GameObject backButton;
    [SerializeField] private Text playerText;
    [SerializeField] public Text owlName;
    [SerializeField] private Text owlText;
    [SerializeField] private LayerMask interactLayer;

    private BoxCollider2D coll;
    public float time = 0;
    private bool check = true;
    public bool owl1 = false;

    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (check)
        {
            Talk("Mãi mới đi làm về");
            if (time > 2)
            {
                Talk("Phải về làm ván gem phát");
            }
            if (time > 9)
            {
                Talk("Mọi người đâu rồi ta ?");
            }
            if (time > 11)
            {
                check = false;
            }
        }
        else if (!check && owl1)
        {
            TalkI("Oh Dragon Boiz, may wa", "Mr.Owl", true);
            if (time > 2)
            {
                TalkI();
                Talk("Chuyện gì đang xảy ra vậy, Mr.Owl ?");
            }
            if (time > 4)
            {
                TalkI("Nói ở đây không tiện theo ta về căn cứ rồi ta sẽ kể cho cậu", "Mr.Owl", true);
            }
            if (time > 6)
            {
                TalkI();
                owl1 = false;
            }
        }
        else
        {
            Talk("");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D[] collarr = Physics2D.OverlapBoxAll(coll.bounds.center, coll.bounds.size, interactLayer);
            foreach (Collider2D o in collarr)
            {
                if (o.TryGetComponent(out Owl owl))
                {
                    owl.Talk1();
                }
                if (o.TryGetComponent(out Sign1 sign1))
                {
                    sign1.Talk1();
                }
                if (o.TryGetComponent(out Sign2 sign2))
                {
                    sign2.Talk1();
                }
                if (o.TryGetComponent(out Billboard1 bb))
                {
                    bb.Talk1();
                }
                if (o.TryGetComponent(out Flag1 f))
                {
                    f.Talk1();
                }
                if (o.TryGetComponent(out RoadSign1 rs))
                {
                    rs.Talk1();
                }
            }
        }
    }

    public void Talk(string pText = "")
    {
        playerText.text = pText;
    }

    public void TalkI(string nText = "", string nName = "", bool status1 = false, bool status2 = false)
    {
        owlText.text = nText;
        owlName.text = nName;
        textBox.SetActive(status1);
        backButton.SetActive(status2);
    }
}
