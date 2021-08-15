using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Button[] buttons;

    public GameObject[] panels;

    void Start()
    {
        foreach (Button i in buttons)
        {
            i.interactable = false;
        }
        SetPanelActive(0);
    }

    void SetPanelActive(int n)
    {
        foreach (GameObject g in panels)
        {
            g.SetActive(false);
        }
        panels[n].SetActive(true);
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
            SetPanelActive(1);
        }
        else if(n == "materi")
        {
            //SetPanelActive(0);
        }
        else if(n == "tentang")
        {
            SetPanelActive(2);
        }
        else if(n == "keluar")
        {
            SetPanelActive(3);
        }
        else if(n == "ya")
        {
            Application.Quit();
        }
        else if(n == "tidak")
        {
            SetPanelActive(0);
        }
        else if(n == "kembali")
        {
            SetPanelActive(0);
        }
    }
}
