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
        SceneManager.LoadScene("EndScene");
    }
}
