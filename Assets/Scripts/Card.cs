using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
// 카드 정보 및 카드 오픈/클로즈/파괴 관리
{
    public static Card Instance;

    public int idx=0;
    public GameObject front;
    public GameObject back;
    public Animator anim;
    public SpriteRenderer FrontImage;

    public void Setting(int number)
    { 
        idx = number;
        FrontImage.sprite = Resources.Load<Sprite>($"member{idx}");
    }

    public void OpenCard()
    {
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        SFXManager.Instance.PlayCardOpen();

        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        else
        {
            GameManager.Instance.secondCard = this;
            GameManager.Instance.Matching();
        }
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.5f);
        
    }

    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }

    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 0.5f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }
}
