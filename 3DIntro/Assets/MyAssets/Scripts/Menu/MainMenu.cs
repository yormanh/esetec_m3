using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] RectTransform mainPanel;

    public void Jugar()
    {
        mainPanel.gameObject.SetActive(false);
        SceneManager.LoadScene("FPS");
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
        
    }
}
