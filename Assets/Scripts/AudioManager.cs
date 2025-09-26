using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip Mainclip;
    public AudioClip Failclip;
    AudioSource audioSource;

    public static bool isGameOver = false; // 추가

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();// AudioSource 컴포넌트 가져오기
        audioSource.clip = this.Mainclip;// 재생할 오디오 클립 설정
        audioSource.Play();
    }

    public void PlayFailClip()
    {
        audioSource.Stop();// 현재 재생 중인 오디오가 있으면 중지
        audioSource.clip = this.Failclip;// 실패 오디오 클립 설정
        audioSource.Play();
    }
}