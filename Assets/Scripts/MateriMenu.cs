using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MateriMenu : MonoBehaviour
{
    public static MateriMenu MM;

    public GameObject[] panels;

    void Awake()
    {
        if(MM == null)
        {
            MM = this;
        }
        else
        {
            return;
        }
    }

    void Start()
    {
        foreach (GameObject g in panels)
        {
            g.SetActive(false);
        }
        panels[0].SetActive(true);
    }

    public void menuButton(int n)
    {
        if(n == panels.Length)
        {
            SceneManager.LoadScene(0);
        }
        foreach (GameObject g in panels)
        {
            g.SetActive(false);
        }
        panels[n].SetActive(true);
    }

    public void KeMenu()
    {
        SceneManager.LoadScene(0);
    }
}
