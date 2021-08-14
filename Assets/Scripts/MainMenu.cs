using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Button[] buttons;

    void Start()
    {
        foreach (Button i in buttons)
        {
            i.interactable = false;
        }
    }

    public void InputNama(string nama)
    {
        foreach (Button i in buttons)
        {
            i.interactable = true;
        }
    }

    public void MenuButton(string n)
    {
        if(n == "menu")
        {
            SceneManager.LoadScene(1);
        }
        else if(n == "tujuan")
        {

        }
        else if(n == "materi")
        {
            
        }
        else if(n == "credits")
        {
            
        }
        else if(n == "quit")
        {
            Application.Quit();
        }
    }
}
