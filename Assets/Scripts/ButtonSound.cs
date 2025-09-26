using System.Collections;
using UnityEngine;
using UnityEngine.Events;  // UnityAction용

public class ButtonSound : MonoBehaviour
{
    public AudioClip clip;
    public float volume = 1f;

    public void PlaySound()
    {
        if (clip == null) return;

        GameObject go = new GameObject("OneShotSFX");
        AudioSource src = go.AddComponent<AudioSource>();
        src.playOnAwake = false;
        src.spatialBlend = 0f;   // 2D
        src.volume = volume;
        src.clip = clip;
        src.Play();

        DontDestroyOnLoad(go);               // 씬 넘어가도 유지
        Destroy(go, clip.length + 0.05f);    // 재생 끝나면 정리
    }
}