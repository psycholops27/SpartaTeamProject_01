using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBtn : MonoBehaviour
{
    public void ToStart()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Credit()
    {
        SceneManager.LoadScene("CreditScene");
    }
}
