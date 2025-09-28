using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BgmManager : MonoBehaviour
{
    public static BgmManager Instance;

    public AudioClip TitleBgm;
    public AudioClip MainBgm;
    public AudioClip SuccessBgm;
    public AudioClip FailBgm;
    public AudioClip CreditBgm;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            audioSource = GetComponent<AudioSource>();
            SceneManager.sceneLoaded += OnSceneLoad;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        PlayBgm(SceneManager.GetActiveScene().name);
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mod)
    {
        PlayBgm(scene.name);
    }

    private void PlayBgm(string sceneName)
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
 
        switch(sceneName)
        {
            case "TitleScene":
                audioSource.clip = this.TitleBgm;
                audioSource.Play();
                break;
            case "MainScene":
                audioSource.clip = this.MainBgm;
                audioSource.Play();
                break;
            case "CreditScene":
                audioSource.clip = this.CreditBgm;
                audioSource.Play();
                break;
        }
    }

    public void ChangeMusic()
    {
        if (GameManager.Instance.isClear)
        {
            audioSource.Stop();
            audioSource.clip = this.SuccessBgm;
            audioSource.Play();
        }

        if(GameManager.Instance.isGameOver)
        {
            audioSource.Stop();
            audioSource.clip = this.FailBgm;
            audioSource.Play();
        }
    }
}
