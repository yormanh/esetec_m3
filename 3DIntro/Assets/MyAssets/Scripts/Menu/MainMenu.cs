using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] RectTransform mainPanel;

    
    public void Start()
    {
        CambiarIdiomaTextos();
    }

    public void SelectLanguage(string language)
    {
        MyResources.Singleton.Language = language;
        CambiarIdiomaTextos();
    }

    void CambiarIdiomaTextos()
    {
        string baseTexto = "Canvas/MainPanel/BotonesPanel/";
        GameObject.Find(baseTexto +"Play/Text").
            GetComponent<TextMeshProUGUI>().
            //GetComponent<Text>().
            text = TextManager.GetText("Jugar");

        GameObject.Find(baseTexto + "Creditos/Text").
            GetComponent<TextMeshProUGUI>().
            //GetComponent<Text>().
            text = TextManager.GetText("Creditos");

        GameObject.Find(baseTexto +"Salir/Text").
    GetComponent<TextMeshProUGUI>().
    //GetComponent<Text>().
    text = TextManager.GetText("Salir");



    }

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
