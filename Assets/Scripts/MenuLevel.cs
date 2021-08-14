using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuLevel : MonoBehaviour
{
    public Button[] buttons;

    void Start()
    {
        foreach (Button item in buttons)
        {
            item.interactable = false;
        }
        for (int i = 0; i < GameManager.GM.levelUnlocked; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void ButtonLevel(string n)
    {
        SceneManager.LoadScene(n);
    }
}
