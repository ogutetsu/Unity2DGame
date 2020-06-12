using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MinaMenu : MonoBehaviour
{
    
    public void StartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
