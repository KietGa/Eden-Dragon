using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerInteract3 : MonoBehaviour
{
    [SerializeField] private GameObject textBox;
    [SerializeField] private GameObject backButton;
    [SerializeField] private Text playerText;
    [SerializeField] public Text birdName;
    [SerializeField] private Text birdText;
    [SerializeField] private LayerMask interactLayer;

    private BoxCollider2D coll;
    public float time = 0;
    public bool bird1 = false;
    public bool pen1 = false;
    private int scene;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        coll = GetComponent<BoxCollider2D>();
        Talk();
        TalkI();
    }

    void Update()
    {
        time += Time.deltaTime;

        if (bird1 && scene == 1)
        {
            Talk1();
        }
        if (pen1 && scene == 2)
        {
            Talk2();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D[] collarr = Physics2D.OverlapBoxAll(coll.bounds.center, coll.bounds.size, interactLayer);
            foreach (Collider2D o in collarr)
            {
                if (o.TryGetComponent(out Flag2 fl))
                {
                    fl.Talk1();
                }
                if (o.TryGetComponent(out Sign3 s))
                {
                    s.Talk1();
                }
                if (o.TryGetComponent(out Bird1 b))
                {
                    b.Talk1();
                }
                if (o.TryGetComponent(out Flag4 f))
                {
                    f.Talk2();
                }
                if (o.TryGetComponent(out Billboard2 bi))
                {
                    bi.Talk2();
                }
                if (o.TryGetComponent(out Penguin p))
                {
                    p.Talk1();
                }
                if (o.TryGetComponent(out Flag5 p1))
                {
                    p1.Talk2();
                }
                if (o.TryGetComponent(out Flag6 p2))
                {
                    p2.Talk2();
                }
                if (o.TryGetComponent(out Flag7 p3))
                {
                    p3.Talk2();
                }
                if (o.TryGetComponent(out Billboard5 bb))
                {
                    bb.Talk1();
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
        birdText.text = nText;
        birdName.text = nName;
        textBox.SetActive(status1);
        backButton.SetActive(status2);
    }

    private void Talk1()
    {
        TalkI("Anh là ai thế", "Baby Bird", true);
        if (time > 2)
        {
            TalkI();
            Talk("Tao là Dragon Hero, tao bị Mr.Owl ép đến đây để cứu mày");
        }
        if (time > 5)
        {
            Talk();
            TalkI("Ok thé thôi", "Baby Bird", true);
        }
        if (time > 7)
        {
            TalkI();
            Talk("Này nhóc, ông ta nói mày có thể giúp tao mạnh hơn nhưng mà nhìn mày yếu vl");
        }
        if (time > 11)
        {
            Talk();
            TalkI("Haha, anh chỉ cần cho tôi ăn là tôi sẽ giúp anh bá đạo và quan trọng nhất là mỗi khi xong 1 nhiệm vụ tôi sẽ tặng anh" +
                " một sức mạnh mới", "Baby Bird", true);
        }
        if (time > 16)
        {
            TalkI();
            Talk("Sugoi sugoi, ok về tét luôn cho lóng");
        }
        if (time > 18)
        {
            Talk();
            bird1 = false;
        }
    }

    private void Talk2()
    {
        TalkI("E = MC^2", "Nerd Penguin", true);
        if (time > 2)
        {
            TalkI();
            Talk("?");
        }
        if (time > 3)
        {
            Talk();
            TalkI("Cậu có phải Dragon Boiz ko?", "Nerd Penguin", true);
        }
        if (time > 5)
        {
            TalkI();
            Talk("Oắc, hau tờ phắc diu nâu ?!");
        }
        if (time > 7)
        {
            Talk();
            TalkI("Bởi vì tao là một thẳng Nerd", "Nerd Penguin", true);
        }
        if (time > 9)
        {
            TalkI();
            Talk("Nhưng mà chúng ta đã gặp nhau deo đâu tao thấy mày giống Stalker hơn");
        }
        if (time > 12)
        {
            Talk();
            TalkI("Umm, thật ra là tao thông đồng với 1 thẳng tên là Kiga, nó cho tao biết hết thông tin ý mà", "Nerd Penguin", true);
        }
        if (time > 14.5f)
        {
            TalkI();
            Talk("?!");
        }
        if (time > 15.5f)
        {
            TalkI();
            TalkI("Quan hệ là trí tuệ mà mày ko biết sao?", "Nerd Penguin", true);
        }
        if (time > 17)
        {
            TalkI();
            TalkI("VL lộ hết bí mật quân sự quốc gia rồi, hên cho mày là nhân vật liên quan cốt truyện ko bố mày cho mày cút luôn", "Kiga", true);
        }
        if (time > 21)
        {
            TalkI();
            Talk("Thằng nào vậy ? Mà thôi kệ về đã");
        }
        if (time > 24)
        {
            Talk();
            bird1 = false;
        }
    }
}
