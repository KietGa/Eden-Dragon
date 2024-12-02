using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerInteract2 : MonoBehaviour
{
    [SerializeField] private GameObject textBox;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject playerButton;
    [SerializeField] private GameObject enemyButton;
    [SerializeField] private GameObject trapButton;
    private PlayerMovement pm;
    [SerializeField] private Text playerText;
    [SerializeField] public Text owlName;
    [SerializeField] private Text owlText;
    [SerializeField] private LayerMask interactLayer;

    private BoxCollider2D coll;
    public float time = 0;
    private bool check = true;
    public bool owl1 = false;
    public bool bird1 = false;
    public bool pen1 = false;
    private int scene;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene().buildIndex; 
        coll = GetComponent<BoxCollider2D>();
        pm = GetComponent<PlayerMovement>();
        Talk();
        TalkI();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (scene == 1)
        {
            if (check)
            {
                FirstDialog1();
            }
            else if (!check && owl1)
            {
                OwlDiaLog1();
            }
        }
        else if (scene == 2)
        {
            if (check)
            {
                FirstDialog2();
            }
            else if (!check && owl1)
            {
                OwlDiaLog2();
            }
            else if (!check && bird1)
            {
                BirdDiaLog1();
            }
        }
        else if (scene == 3)
        {
            if (check)
            {
                FirstDialog3();
            }
            else if (!check && owl1)
            {
                OwlDiaLog3();
            }
            else if (!check && bird1)
            {
                BirdDiaLog2();
            }
            else if (!check && pen1)
            {
                PenguinDialog1();
            }
        }
        else if (scene == 4)
        {
            if (check)
            {
                FirstDialog4();
            }
            else if (!check && owl1)
            {
                OwlDiaLog4();
            }
            else if (!check && bird1)
            {
                BirdDiaLog3();
            }
            else if (!check && pen1)
            {
                PenguinDialog1();
            }
        }
        else if (scene == 5)
        {
            if (check)
            {
                FirstDialog5();
            }
            else if (!check && owl1)
            {
                OwlDiaLog5();
            }
            else if (!check && bird1)
            {
                BirdDiaLog4();
            }
            else if (!check && pen1)
            {
                PenguinDialog1();
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
                if (o.TryGetComponent(out Owl2 owl))
                {
                    owl.Talk1();
                }
                if (o.TryGetComponent(out Owl3 ow))
                {
                    ow.Talk1();
                }
                if (o.TryGetComponent(out Bird3 bi))
                {
                    bi.Talk1();
                }
                if (o.TryGetComponent(out Billboard2 b))
                {
                    b.Talk1();
                }
                if (o.TryGetComponent(out Flag3 s))
                {
                    s.Talk1();
                }
                if (o.TryGetComponent(out Flag4 s1))
                {
                    s1.Talk1();
                }
                if (o.TryGetComponent(out Flag5 s2))
                {
                    s2.Talk1();
                }
                if (o.TryGetComponent(out Penguin2 p2))
                {
                    p2.Talk1();
                }
                if (o.TryGetComponent(out Flag6 p3))
                {
                    p3.Talk1();
                }
                if (o.TryGetComponent(out Flag7 p7))
                {
                    p7.Talk1();
                }
            }
        }
    }

    public void Talk(string pText = "")
    {
        playerText.text = pText;
    }

    public void TalkI(string nText = "", string nName = "", bool status1 = false, bool status2 = false, bool status3 = false, bool status4 = false, bool status5 = false)
    {
        owlText.text = nText;
        owlName.text = nName;
        textBox.SetActive(status1);
        backButton.SetActive(status2);
        playerButton.SetActive(status3);
        enemyButton.SetActive(status4);
        trapButton.SetActive(status5);
    }

    private void FirstDialog1()
    {
        Talk("Ok đã về căn cứ");
        if (time > 1)
        {
            Talk("Giờ thì hỏi Mr.Owl chuyện gì đã xảy ra nào");
        }
        if (time > 2.5f)
        {
            check = false;
        }
    }

    private void FirstDialog2()
    {
        Talk("Gem có vẻ ez quá nhỉ");
        if (time > 1)
        {
            Talk("Mình cảm giác như mình là main vậy");
        }
        if (time > 2)
        {
            check = false;
        }
    }

    private void FirstDialog3()
    {
        Talk("Kiga là ai nhỉ ?");
        if (time > 1)
        {
            Talk();
            check = false;
        }
    }
    private void FirstDialog4()
    {
        Talk("Màn trước mệt vãi");
        if (time > 1)
        {
            Talk();
            check = false;
        }
    }

    private void FirstDialog5()
    {
        Talk("This is Final");
        if (time > 1)
        {
            Talk();
            check = false;
        }
    }

    private void OwlDiaLog1()
    {
        TalkI("Nhóc làm tốt đấy ta cứ tưởng ngủm củ tỏi rồi cơ", "Mr.Owl", true);
        if (time > 2)
        {
            TalkI();
            Talk("Là sao ạ ?");
        }
        if (time > 4)
        {
            Talk();
            TalkI("Ừ thì ngắn gọn là chúng ta bị con người bắt làm thịt giờ nhiệm vụ của mày là cứu mọi người", "Mr.Owl", true);
        }
        if (time > 8)
        {
            TalkI();
            Talk("Bác ơi cháu chịu thôi");
        }
        if (time > 12)
        {
            Talk();
            TalkI("Ừ huce, bây giờ á, mày phải đi cứu con tao xong con tao sẽ có cách giúp mày mạnh hơn", "Mr.Owl", true);
        }
        if (time > 14)
        {
            TalkI();
            Talk("Ơ...");
        }
        if (time > 16)
        {
            Talk();
            TalkI("Ơ con cẹc, biến", "Mr.Owl", true);
        }
        if (time > 16)
        {
            TalkI();
            owl1 = false;
        }
    }

    private void OwlDiaLog2()
    {
        TalkI("Nhóc làm tốt đấy ta cứ tưởng ngủm củ tỏi rồi cơ", "Mr.Owl", true);
        if (time > 2)
        {
            TalkI();
            Talk("???");
        }
        if (time > 4)
        {
            Talk();
            TalkI("Ok ta joke tí căng thẳng thế", "Mr.Owl", true);
        }
        if (time > 7)
        {
            TalkI();
            Talk("Deo hài");
        }
        if (time > 9)
        {
            Talk();
            TalkI("Ừ huce, bây giờ mày có thể sang Baby Bird lấy năng lực", "Mr.Owl", true);
        }
        if (time > 12)
        {
            TalkI();
            Talk("Ngol");
        }
        if (time > 14)
        {
            Talk();
            TalkI("Còn nữa, giờ mày sẽ cứu Nerd Penguin, thằng đấy sẽ giúp mày 'thông minh' hơn", "Mr.Owl", true);
        }
        if (time > 18)
        {
            TalkI();
            Talk("Thông minh?");
        }
        if (time > 20)
        {
            Talk();
            owl1 = false;
        }
    }

    private void OwlDiaLog3()
    {
        TalkI("Ok giờ team ta đã đủ đội hình", "Mr.Owl", true);
        if (time > 2)
        {
            TalkI();
            Talk("Bác không định cứu thêm ai à");
        }
        if (time > 4)
        {
            Talk();
            TalkI("Cứu thế thôi không nhiều miệng ăn wa thì chết đói cả lũ", "Mr.Owl", true);
        }
        if (time > 7)
        {
            TalkI();
            Talk("Cũng hợp lý nhỉ");
        }
        if (time > 9)
        {
            Talk();
            TalkI("Anyway, ta có quà cho ngươi không biết ngươi có để ý không", "Mr.Owl", true);
        }
        if (time > 12)
        {
            TalkI();
            Talk("Qùa gì thế bác ?");
        }
        if (time > 14)
        {
            Talk();
            TalkI("Ngươi có thêm 1 tim đó", "Mr.Owl", true);
        }
        if (time > 16)
        {
            TalkI();
            Talk("OMG cảm ơn bác");
        }
        if (time > 18)
        {
            Talk();
            TalkI("Đừng quên nói chuyện với thằng Nerd Penguin, nó có nhiều thông tin hữu ích lắm", "Mr.Owl", true);
        }
        if (time > 21)
        {
            TalkI();
            owl1 = false;
        }
    }

    private void OwlDiaLog4()
    {
        TalkI("Ok chúc mừng cậu đã đi được hơn nửa chặng đường rồi", "Mr.Owl", true);
        if (time > 2)
        {
            TalkI();
            Talk("Wow bác thấy cháu pro ko ?");
        }
        if (time > 4)
        {
            Talk();
            TalkI("Haha cũng bình thường bác mà là nhân vật chính thì game này end lâu rồi", "Mr.Owl", true);
        }
        if (time > 7)
        {
            TalkI();
            Talk("Gvs");
        }
        if (time > 9)
        {
            Talk();
            TalkI("Nốt ải này là sẽ tới trùm cuối cố gắng lên nhóc", "Mr.Owl", true);
        }
        if (time > 12)
        {
            TalkI();
            Talk("Ok bác ko vấn đề");
        }
        if (time > 14)
        {
            Talk();
            owl1 = false;
        }
    }

    private void OwlDiaLog5()
    {
        TalkI("Đây là kết thúc nhỉ ?", "Mr.Owl", true);
        if (time > 2)
        {
            TalkI();
            Talk("Vâng");
        }
        if (time > 4)
        {
            Talk();
            TalkI("Chúng ta đã đi 1 chặng đường dài.. hoặc cũng ko dài lắm", "Mr.Owl", true);
        }
        if (time > 7)
        {
            TalkI();
            Talk("???");
        }
        if (time > 9)
        {
            Talk();
            TalkI("Nếu ngươi để ý thì ta tặng ngươi 2 món quà cuối là thêm 1 tim và 1 đồng hồ đếm giờ hãy tận dụng nó", "Mr.Owl", true);
        }
        if (time > 13)
        {
            TalkI();
            Talk("Ok tôi sẽ cố hết sức");
        }
        if (time > 14)
        {
            Talk();
            owl1 = false;
        }
    }

    private void BirdDiaLog1()
    {
        TalkI("Bầu trời hôm nay đẹp nhỉ?", "Baby Bird", true);
        if (time > 2)
        {
            TalkI();
            Talk("???");
        }
        if (time > 4)
        {
            Talk();
            TalkI("Đám mây trắng đầy màu sắc", "Baby Bird", true);
        }
        if (time > 6)
        {
            TalkI();
            Talk("Ummm, năng lực của tao đâu ?");
        }
        if (time > 8)
        {
            Talk();
            TalkI("Trong khu vực sắp tới sẽ bắt đầu xuất hiện kẻ địch, thế nên tôi sẽ cho anh năng lực để tấn công", "Baby Bird", true);
        }
        if (time > 11)
        {
            TalkI();
            Talk("Sugoi!");
        }
        if (time > 12)
        {
            Talk();
            TalkI("Click chuột trái để bắn", "Baby Bird", true);
        }
        if (time > 14)
        {
            TalkI();
            Talk("VCL ngol!");
        }
        if (time > 16)
        {
            Talk();
            bird1 = false;
        }
    }

    private void BirdDiaLog2()
    {
        TalkI("Wao, cậu còn sống sao ? Thấy kĩ năng tôi trao cậu ok không ?", "Baby Bird", true);
        if (time > 2)
        {
            TalkI();
            Talk("Kĩ năng quá tuyệt vời luôn");
        }
        if (time > 4)
        {
            Talk();
            TalkI("Ok tuyệt hôm nay tôi sẽ dạy cậu khả năng nhảy kép", "Baby Bird", true);
        }
        if (time > 6)
        {
            TalkI();
            Talk("Oắc nghe chán thế ?");
        }
        if (time > 8)
        {
            Talk();
            TalkI("Ấn 2 lần W hoặc ^ để nhảy kép", "Baby Bird", true);
        }
        if (time > 11)
        {
            TalkI();
            Talk("Ok Cool");
        }
        if (time > 13)
        {
            Talk();
            bird1 = false;
        }
    }

    private void BirdDiaLog3()
    {
        TalkI("Ok tôi hôm nay sẽ vào chủ đề chính luôn", "Baby Bird", true);
        if (time > 2)
        {
            TalkI();
            Talk("Ok");
        }
        if (time > 4)
        {
            Talk();
            TalkI("Cậu sẽ được kĩ năng trái táo bá đạo", "Baby Bird", true);
        }
        if (time > 6)
        {
            TalkI();
            Talk("Oắc là sao?");
        }
        if (time > 8)
        {
            Talk();
            TalkI("Bây giờ trên map sẽ xuất hiện những trái táo, khi cậu ăn cậu sẽ hồi lại máu", "Baby Bird", true);
        }
        if (time > 12)
        {
            TalkI();
            Talk("Wao nai sư anh gà ơi");
        }
        if (time > 13)
        {
            Talk();
            TalkI("Tao là Bird không phải là gà", "Baby Bird", true);
        }
        if (time > 15)
        {
            TalkI();
            bird1 = false;
        }
    }

    private void BirdDiaLog4()
    {
        TalkI("Chúc mừng cậu đã đến ải cuối", "Baby Bird", true);
        if (time > 2)
        {
            TalkI();
            Talk("Cũng nhờ ơn anh 1 phần và trình tôi 9 phần");
        }
        if (time > 4)
        {
            Talk();
            TalkI("Ok sao cũng được nay tôi sẽ cho cậu kĩ năng cuối cùng", "Baby Bird", true);
        }
        if (time > 6)
        {
            TalkI();
            Talk("!!");
        }
        if (time > 8)
        {
            Talk();
            TalkI("Unti Siêu cầu lửa ấn chuột phải để sử dụng, deal 10 dmg nhưng mà cd là 15s", "Baby Bird", true);
        }
        if (time > 12)
        {
            TalkI();
            Talk("VL được anh ơi");
        }
        if (time > 13)
        {
            Talk();
            TalkI("Gud Luck", "Baby Bird", true);
        }
        if (time > 15)
        {
            TalkI();
            bird1 = false;
        }
    }

    private void PenguinDialog1()
    {
        TalkI("Tôi có thể giúp gì cho cậu ?", "Nerd Penguin", true, true, true, true, true);
        pm.interact = false;
        pm.rb.bodyType = RigidbodyType2D.Static;
    }
}
