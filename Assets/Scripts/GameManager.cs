using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Card firstCard;
    public Card secondCard;

    public int CardCount = 0;

    public Text TimeTxt;
    float time = 0.0f;

    public GameObject PopUP;
    public GameObject SuccessTxt;
    public GameObject SuccessBtn;
    public GameObject FailTxt;
    public GameObject FailBtn;

    AudioSource audioSource;
    public AudioClip Mainbgmclip;
    public AudioClip Gameoverclip;
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        Time.timeScale = 1.0f;
        TimeTxt.gameObject.SetActive(true);
        PopUP.SetActive(false);
        SuccessBtn.SetActive(false);
        SuccessTxt.SetActive(false);
        FailBtn.SetActive(false);
        FailTxt.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        time += Time.deltaTime;
        TimeTxt.text=time.ToString("N2");
        if (time >= 45.0f)
        {
            GameOver();
        }
    }

    public void Matched()
    {
        if(firstCard.idx == secondCard.idx)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            CardCount -= 2;
            if (CardCount == 0)
            {
                Time.timeScale = 0.0f;
                TimeTxt.gameObject.SetActive(false);
                PopUP.SetActive(true);
                SuccessTxt.SetActive(true);
                SuccessBtn.SetActive(true);
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        PopUP.SetActive(true);
        FailTxt.SetActive(true);
        FailBtn.SetActive(true);
    }
}
