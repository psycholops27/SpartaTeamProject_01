using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBtn : MonoBehaviour
{
    public static SceneBtn Instance;

    public void ToTitle()
    {
        SceneManager.LoadScene("TitleScene");
        SFXManager.Instance.BtnClick();
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
        SFXManager.Instance.BtnClick();
    }

    public void ToCredit()
    {
        SceneManager.LoadScene("CreditScene");
        SFXManager.Instance.BtnClick();
    }

    public void GameExit()
    {
        #if UNITY_EDITOR    //유니티 에디터로 실행할 때 (전처리기)
        UnityEditor.EditorApplication.isPlaying = false;
        #else               //빌드 이후 응용 프로그램으로 실행할 때
            Application.Quit();
        #endif
    }
    
}
