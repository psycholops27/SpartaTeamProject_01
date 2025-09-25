using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBtn : MonoBehaviour
{
    
    public void ToTitle()
    {      
        SceneManager.LoadScene("TitleScene");
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ToCredit()
    {
        SceneManager.LoadScene("CreditScene");
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
