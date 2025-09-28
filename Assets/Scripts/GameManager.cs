using System.Collections; // ClearRoutine을 사용하기 위해서는 꼭 필요한 코드
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
// 카드 매칭, 시간, 게임 클리어/게임 오버, 팝업 관리
{
    public static GameManager Instance;

    public Card firstCard;
    public Card secondCard;
    public int CardCount = 0;

    public Text TimeTxt;
    float time = 0.0f;

    public GameObject PopUP;
    public GameObject Success;
    public GameObject Fail;

    public bool isMatched = false;
    public bool isUnmatched = false;
    public bool isClear = false;
    public bool isGameOver = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        Time.timeScale = 1.0f;
        TimeTxt.gameObject.SetActive(true);
        PopUP.SetActive(false);
        Success.SetActive(false);
        Fail.SetActive(false);
    }

    void Update()
    {
        time += Time.deltaTime;
        TimeTxt.text = time.ToString("N2");
        if (time >= 45.0f)
        {
            GameOver();
        }
    }

    public void Matching() // 카드 매칭 관리
    {
        if (firstCard.idx == secondCard.idx)
        {
            SFXManager.Instance.PlayMatched();
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            CardCount -= 2;
            isMatched = true;
            if (CardCount == 0)
            {
                Clear();
            }
        }
        else
        {
            SFXManager.Instance.PlayUnmatched();
            firstCard.CloseCard();
            secondCard.CloseCard();
            isUnmatched = true;
        }

        firstCard = null;
        secondCard = null;
    }

    public void Clear()
    {
        if (isClear) return;
        StartCoroutine(ClearRoutine());
    }

    IEnumerator ClearRoutine()
    {
        isClear = true;
        SFXManager.Instance.PlayGameClear();
        BgmManager.Instance.ChangeMusic(); // Clear 됐다는 사실을 BgmManager한테 알려줘야 함

        yield return null;

        Time.timeScale = 0.0f;
        TimeTxt.gameObject.SetActive(false);
        PopUP.SetActive(true);
        Success.SetActive(true);
    }

    public void GameOver()
    {

        if (isGameOver) return;
        StartCoroutine (GameOverRoutine());
    }


    IEnumerator GameOverRoutine()
    {
        isGameOver = true;
        BgmManager.Instance.ChangeMusic();

        yield return null;

        Time.timeScale = 0.0f;
        TimeTxt.gameObject.SetActive(false);
        PopUP.SetActive(true);
        Fail.SetActive(true);

    }
}
