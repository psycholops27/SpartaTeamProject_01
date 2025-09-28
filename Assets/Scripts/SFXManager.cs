using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    public AudioClip CardOpenFX;
    public AudioClip MatchFX;
    public AudioClip UnmatchFX;
    public AudioClip Click;

    public AudioClip GameClear;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCardOpen()
    {
        audioSource.PlayOneShot(CardOpenFX);
    }

    public void PlayMatched()
    {
        audioSource.PlayOneShot(MatchFX);
    }

    public void PlayUnmatched()
    {
        audioSource.PlayOneShot(UnmatchFX);
    }
    public void BtnClick()
    {
        audioSource.PlayOneShot(Click);
    }

    public void PlayGameClear()
    { 
        audioSource?.PlayOneShot(GameClear);
    }
}
