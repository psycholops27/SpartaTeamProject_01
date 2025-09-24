using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
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

        if(GameManager.instance.firstCard == null)
        {
            GameManager.instance.firstCard = this;
        }
        else
        {
            GameManager.instance.secondCard = this;
            GameManager.instance.Matched();
        }
    }

    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
    public void CloseCard()
    {
       Invoke("CloseCardInvoke", 0.5f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }
    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 0.5f);
    }


}
