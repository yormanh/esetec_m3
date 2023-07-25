using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyResources : MonoBehaviour
{
    public static MyResources Singleton; //Instance

    private string _language;

    public string Language
    { 
        get
        {
            string language = PlayerPrefs.GetString("Language");
            _language = language;

            //if (string.IsNullOrEmpty(_language))
            //    _language = "spanish";
            //return _language;
            
            return string.IsNullOrEmpty(_language) ? "spanish" : _language;
        }

        set
        {
            _language = value;
            PlayerPrefs.SetString("Language", _language);
            LoadLanguage();
        }
    }

    void Awake()
    {
        Singleton = this;
        LoadLanguage();
    }

    
    void Update()
    {
        
    }

    public void LoadLanguage()
    {
        TextManager.LoadLanguage(this.Language);
    }
}
