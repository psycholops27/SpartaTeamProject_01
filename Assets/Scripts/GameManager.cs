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
    bool isGameOver = false;   // ★ 추가

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
        if (isGameOver) return;                 // ★ 추가
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
        if (isGameOver) return;                 // ★ 추가 //return 중복 방지
        isGameOver = true;                      // ★ 추가
        Time.timeScale = 0.0f;
        TimeTxt.gameObject.SetActive(false);
        PopUP.SetActive(true);
        FailTxt.SetActive(true);
        FailBtn.SetActive(true);
        // BGM 끄기
        AudioManager am = FindObjectOfType<AudioManager>();
        if (am != null)
        {
            AudioSource bgmSource = am.GetComponent<AudioSource>();
           if (bgmSource != null && bgmSource.isPlaying) bgmSource.Stop(); // ← 추가 가드
        }

        // 게임 오버 효과음
        audioSource.PlayOneShot(Gameoverclip);
    }
}
