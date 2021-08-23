using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuLevel : MonoBehaviour
{
    public Button[] buttons;

    public TMP_Text namaPemain , coinText;

    void Start()
    {
        namaPemain.text = GameManager.GM.data.namaPemain;

        foreach (Button item in buttons)
        {
            item.interactable = false;
        }
        for (int i = 0; i < GameManager.GM.data.levelUnlocked; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void ButtonLevel(string n)
    {
        SceneManager.LoadScene(n);
    }

    void Update()
    {
        coinText.text = GameManager.GM.data.coin.ToString();
    }
}
