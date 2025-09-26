using System.Collections;
using UnityEngine;
using UnityEngine.Events;  // UnityAction용

public class ButtonSound : MonoBehaviour
{
    public AudioClip clip;            // 버튼 효과음
    private AudioSource audioSource;  // 재생기
    public float delay = 0.2f;        // 씬 전환 지연 시간
    public UnityEvent onDelayedClick; // 지연 후 실행할 이벤트 (씬 전환 함수 넣기)

    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
    }

    // 버튼 OnClick에 이 함수 하나만 연결
    public void PlaySoundAndDelay()
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
        StartCoroutine(DelayInvoke());
    }

    IEnumerator DelayInvoke()
    {
        yield return new WaitForSecondsRealtime(delay);
        onDelayedClick.Invoke();  // 설정된 씬 전환 함수 실행
    }
}